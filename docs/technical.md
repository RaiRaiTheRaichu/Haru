# Technical

## EFT details

### Security mechanisms

EFT implements BattlEye as it's anti-cheat solution. It is capable of detecting
newly-injected assemblies into the game as long as the namespace doesn't match
with one already in EFT.

In addtion, EFT implements a custom integrity validator (`FilesChecker.dll`).
It's not capable of detecting newly added files.

### Request handling

A HTTP packet from EFT does not include proper headers (compression headers are
missing). Payload for HTTP and WS is compressed with ZLib (RFC1950). Using
`deflate` in the HTTP header will cause unity to attempt at automatic
decompression which will fail and softlock the game.

Most of EFT's comminucation is over HTTPS protocol, synchronization events are
usually over WSS protocol.

## Haru implementation details

### Defeating security mechanisms

EFT 0.12.12.32.20243 and older allowed for abusing NLog targets by making your
own dll a NLog target without implementing any logging targets, then drop
`NLog.dll.nlog` inside `<gamedir>/EscapeFromTarkov_Data/Managed/` which
contained a reference to your dll. Since EFT 0.13.0.x this is no longer an
option. For code injection, you're required to use an external framework like
BepInEx. 

In addition, deobfuscation is required since you have to patch this method to
communicate over HTTP without SSL:

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

Using deobfuscation means that `ConsistencyInfo`'s hash would be invalid. In
order to bypass this, you either change `ConsistencyInfo`'s hash for
`Assembly-CSharp.dll` or patch the methods running `FileChecker.dll` code. This
project does the latter by patching `TarkovApplication`'s base type.

### Deobfuscation

1. Deobfuscate using `de4dot` (set strtok to the token of the deobfuscation function)

```
de4dot-x64.exe Assembly-CSharp.dll
de4dot-x64.exe --un-name "!^<>[a-z0-9]$&!^<>[a-z0-9]__.*$&![A-Z][A-Z]\$<>.*$&^[a-zA-Z_<{$][a-zA-Z_0-9<>{}$.`-]*$" "Assembly-CSharp-cleaned.dll" --strtyp delegate --strtok 0x0600F6FF
```

2. Copy-paste `Assembly-CSharp-cleaned-cleaned.dll` into `<gamedir>/EscapeFromTarkov_Data/Managed/`
3. Open DnSpy > Open `Assembly-CSharp-cleaned-cleaned.dll` > Save Module

### Server implementation

- Server: gets incoming requests
- Router: assigns a Controller to handle a request
- Controller: sends response
- Service: generates data for a response
- Repository: database access
- Database: stores data

### FAQ

> Why doesn't Haru use SimpleZlib for (de)compression?

EFT's implementation is flawed for async operations. The ArrayPool's buffer is
rented before returning, causing overlap, which results in corrupted data.

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
