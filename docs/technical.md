# Technical

## Haru implementation details

There is a rich development history behind writing EFT server emulators, as
well as many differences in the implementation of Aki and Haru. These are
highlighted in this section as well. It's not meant as an as-vs-them, but to
show the various challenges and different solutions to the same problem.

### NLog exploit

EFT 0.12.12.32.20243 and older allowed for abusing NLog targets by making your
own dll a NLog target without implementing any logging targets, then drop
`NLog.dll.nlog` inside `<gamedir>/EscapeFromTarkov_Data/Managed/` which
contained a reference to your dll.

Now this is no longer an viable because `NLog.dll.nlog` is ignored and
`NLog.config` doesn't see the target. Writing a "proper" target means missing
timing. For code injection, you're required to use an external framework like
BepInEx.

### HTTP communication

Most of EFT's comminucation is over HTTPS protocol, synchronization events are
usually over WSS protocol. Aki wants to comminucate using HTTP without SSL, so
it has to patch this method:

```cs
// Token: 0x06002012 RID: 8210 RVA: 0x001BF6DC File Offset: 0x001BD8DC
public static \uE2c2 CreateFromLegacyParams(\uE2C3 legacyParams)
{
    string[] array = legacyParams.Url.Replace(\uED30.\uE000(11698), "").Split(new char[]
    {
        '/'
    }, 2);
    string backendName = array[0];
    string backendMethod = \uED30.\uE000(31052) + array[1];
    return new \uE2c2
    {
        // code stripped
    };
}
```

The problem here is that names like `\uE2C3` are parsed as `` in instructions.
This means that harmony(x) cannot parse it properly, resulting in invalid
instructions:

```
[Error  : Unity Log] InvalidProgramException:
Invalid IL code in DMD<CreateFromLegacyParams>?1322007296:_::CreateFromLegacyParams ():
IL_0040: call      0x0a000004
```

In order to resolve this, Aki uses deobfuscation on `Assebly-CSharp.dll`. Since
Haru uses HTTPS instead, there is no need for this patch.

### FilesChecker

EFT implements a custom integrity validator (`FilesChecker.dll`). It's not
capable of detecting newly added files, only existing ones included with EFT.

Using deobfuscation or modifying an existing bundle means that
`ConsistencyInfo`'s hash would be invalid. In order to bypass this, you either
change `ConsistencyInfo`'s hash for `Assembly-CSharp.dll` or patch the methods
running `FileChecker.dll` code.

Aki does this by patching `FilesChecker.dll` calls directly, which has the
benefit of working on both 0.12.x and 0.13.x versions. Haru patches
`TarkovApplication`'s base type, which has the benefit of not depending on
`FilesChecker.dll` and completes patching faster but it only works on 0.13.x.

### Anti-cheat

EFT implements BattlEye as it's anti-cheat solution. It is capable of detecting
newly-injected assemblies into the game as long as the namespace doesn't match
with one already in EFT.

Both Aki and Haru patches the battleye validation method used across most
places to always return successfully.

### Zlib compression

A HTTP packet from EFT does not include proper headers (compression headers are
missing). Payload for HTTP and WS is compressed with ZLib (RFC1950). Using
`deflate` in the HTTP header will cause unity to attempt at automatic
decompression which will fail and softlock the game.

Haru doesn't rely on EFT's `SimpleZlib` for (de/in)flation like Aki does, it
instead opts for using `ZOutputStream` directly because EFT's implementation is
flawed. The ArrayPool's buffer is sometimes rented before returning when ran in
async, causing overlap, which results in corrupted data.

### Embedding the server into EFT

I tried this, but it ended up being too much of a hassle so ended up ditching
the idea.

Unity's `System.Security.Cryptography.X509Certificates` doesn't implement
`CertificateRequest` (code stripping? dotnet 462?). It also doesn't support COM
so `CertEnroll` from managed space is not an option. I haven't tried p/invoke
yet with a custom-written C assembly for enrolling certificates. Bundling
openssl is too much of a hassle.

In addition, even with a proper generated certificate the HTTP server didn't
want to bind to it. This resulted in failure of establishing SSL connection.

Another obvious problem is the inability to test the server outside of the
game. Testing suffered a lot more from it than I hoped.

The problems of running external is that EFT's `Newtonsoft.Json` broke
strongname singing, so the check for it has to be disabled. In addition, mods
can no longer use bepinex to mod the server.

### Server architecture

- Server: gets incoming requests
- Router: assigns a Controller to handle a request
- Controller: sends response
- Service: generates data for a response
- Repository: database access
- Database: stores data

## Mod Info

### Senko.EftData

Contains all required data to get into the game and play a basic offline raid.

**live eft path**                             | **filepath**
--------------------------------------------- | --------------------------
`/client/handbook/templates`                  | `templates/handbook.json`
`/client/hideout/production/scavcase/recipes` | `templates/scavcases.json`
`/client/hideout/settings`                    | `settings/hideout.json`
`/client/locale/en`                           | `locale/all-en.json`
`/client/locale/fr`                           | `locale/all-fr.json`
`/client/locale/ge`                           | `locale/all-ge.json`
`/client/locale/ru`                           | `locale/all-ru.json`
`/client/languages`                           | `locale/languages.json`
`/client/menu/locale/en`                      | `locale/menu-en.json`
`/client/menu/locale/fr`                      | `locale/menu-fr.json`
`/client/menu/locale/ge`                      | `locale/menu-ge.json`
`/client/menu/locale/ru`                      | `locale/menu-ru.json`
`/client/settings`                            | `settings/client.json`
`/client/trading/api/tradersettings`          | `templates/traders.json`

### Senko.Langpack

Contains optional languages from EFT (live).

**live eft path**                             | **filepath**
--------------------------------------------- | --------------------------
`/client/locale/ch`                           | `locale/all-ch.json`
`/client/locale/cz`                           | `locale/all-cz.json`
`/client/locale/es`                           | `locale/all-es.json`
`/client/locale/es-mx`                        | `locale/all-es-mx.json`
`/client/locale/hu`                           | `locale/all-hu.json`
`/client/locale/it`                           | `locale/all-it.json`
`/client/locale/jp`                           | `locale/all-jp.json`
`/client/locale/kr`                           | `locale/all-kr.json`
`/client/locale/pl`                           | `locale/all-pl.json`
`/client/locale/po`                           | `locale/all-po.json`
`/client/locale/sk`                           | `locale/all-sk.json`
`/client/locale/tu`                           | `locale/all-tu.json`
`/client/menu/locale/ch`                      | `locale/menu-ch.json`
`/client/menu/locale/cz`                      | `locale/menu-cz.json`
`/client/menu/locale/es`                      | `locale/menu-es.json`
`/client/menu/locale/es-mx`                   | `locale/menu-es-mx.json`
`/client/menu/locale/hu`                      | `locale/menu-hu.json`
`/client/menu/locale/it`                      | `locale/menu-it.json`
`/client/menu/locale/jp`                      | `locale/menu-jp.json`
`/client/menu/locale/kr`                      | `locale/menu-kr.json`
`/client/menu/locale/pl`                      | `locale/menu-pl.json`
`/client/menu/locale/po`                      | `locale/menu-po.json`
`/client/menu/locale/sk`                      | `locale/menu-sk.json`
`/client/menu/locale/tu`                      | `locale/menu-tu.json`

## Resources

### EFT map data locations

`Senko.EftData` always uses the first entry (example: `bigmap1`).

**eft asset bundle**                         | **Type**  | **filename**
-------------------------------------------- | --------- | ------------
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `bigmap1`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `bigmap2`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `bigmap3`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `bigmap4`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `bigmap5`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `bigmap6`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `factory4_day1`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `factory4_day2`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `factory4_day3`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `factory4_day4`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `factory4_day5`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `factory4_day6`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `factory4_night1`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `factory4_night2`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `factory4_night3`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `factory4_night4`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `factory4_night5`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `factory4_night6`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `hideout1`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `hideout2`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `hideout3`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `hideout4`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `hideout5`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `hideout6`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Interchange1`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Interchange2`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Interchange3`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Interchange4`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Interchange5`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Interchange6`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Laboratory1`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Laboratory2`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Laboratory3`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Laboratory4`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Laboratory5`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Laboratory6`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Lighthouse1`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Lighthouse2`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Lighthouse3`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Lighthouse4`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Lighthouse5`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Lighthouse6`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `RezervBase1`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `RezervBase2`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `RezervBase3`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `RezervBase4`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `RezervBase5`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `RezervBase6`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Shoreline1`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Shoreline2`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Shoreline3`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Shoreline4`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Shoreline5`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Shoreline6`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Woods1`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Woods2`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Woods3`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Woods4`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Woods5`
`EscapeFromTarkov_Data\sharedassets2.assets` | TextAsset | `Woods6`
