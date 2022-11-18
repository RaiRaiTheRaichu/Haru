# Modding

## Introduction

This is a quick rundown how to get a minimal mod working with Haru. It might be
a bit intimidating, but don't worry! I'll walk you through it all. 

## Requirements

- Visual Studio Code
- DotNet 6.0 SDK

## Overview

Here is the minimal project layout:

```
ExampleMod/
  References/
    NLog.Haru.dll
  Hook.cs
  Mod.cs
  Senko.Example.code-workspace
  Senko.Example.csproj
```

- `References`: compiled C# code your mod depend on, like Haru
- `Hook.cs`: code that runs when the mod is loaded in
- `Mod.cs`: your mod's code
- `Senko.Example.code-workspace`: vscode intergration
- `Senko.Example.csproj`: `dotnet 6.0 sdk` build information

## 1. Folder structure

For now, make a new folder for your project: `ExampleMod`. In this folder, Make
the following new empty files:

```
Hook.cs
Mod.cs
Senko.Example.code-workspace
Senko.Example.csproj
```

Then create the folder `Reference` into `ExampleMod` and copy-paste your
`NLog.Haru.dll` into it.

## 2. Hello, mod!

Awesome! Now that the files are there, open `Mod.cs` and copy-paste the code
below into the file:

```cs
// Mod.cs
using Haru.Utils;

class Mod
{
    public static void Run()
    {
        Log.Write("Hello, mod!");
    }
}
```

`Mod.Run()` will be executed as soon as the mod is loaded in. When it's loaded,
it will write `Hello, mod!` into the file `<EFT>/Logs/haru.log`.

## 3. Hook mechanism

Okay, I lied. We need to do a little more work to make the mod visible by the
game. Copy-paste the code below into `Hook.cs`:

```cs
// Hook.cs
using Haru.Utils;
using NLog.Targets;

namespace Senko.Example
{
    [Target("Senko.Example")]
    public sealed class Hook : TargetWithLayout
    {
        public Hook()
        {
            Mod.Run();
        }
    }
}
```

## 4. Build instructions

Before we can actually make a working mod, we first need to tell the dotnet 6.0
sdk how to build it. This is what the `Senko.Example.csproj` is for. Open it up
and copy-paste the code below into the file:

```xml
<!-- Senko.Example.csproj -->
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net472</TargetFramework>
    <AssemblyName>NLog.Senko.Example</AssemblyName>
    <RootNamespace>Senko.Example</RootNamespace>
  </PropertyGroup>

  <ItemGroup>
    <Reference PrivateAssets="All" Private="False" Include="Haru" HintPath="References\NLog.Haru.dll"  />
    <PackageReference Include="Microsoft.NETFramework.ReferenceAssemblies" Version="1.0.3" ExcludeAssets="runtime" PrivateAssets="All" />
    <PackageReference Include="NLog" Version="4.7.15" ExcludeAssets="runtime" PrivateAssets="All" />
  </ItemGroup>

</Project>
```

## 5. Visual Studio Code Support

Now that the sdk knows how to build it, we need to tell vscode how it should
run the build. Copy-paste the code below into `Senko.Example.code-workspace`:

```json
// Senko.Example.code-workspace
{
    "folders": [
        {
            "path": "."
        }
    ],
    "extensions": {
        "recommendations": [
            "ms-dotnettools.csharp"
        ]
    },
    "tasks": {
        "version": "2.0.0",
        "tasks": [
            {
                "label": "dotnet: build release",
                "type": "shell",
                "command": "dotnet build --nologo --configuration Release",
                "group": {
                    "kind": "build",
                    "isDefault": true
                }
            }
        ]
    }
}
```

## 6. Renaming the mod

To make this mod your own, rename the mod to what you want it to be. Simply
change all occurances (file names and text) of `Senko.Example` to your
modname.

## Rename Examples

### Files

```
Senko.Example.csproj
Senko.Example.code-workspace
```

...becomes...

```
Author.ModName.csproj
Author.ModName.code-workspace
```

### Assembly name

```xml
<AssemblyName>NLog.Senko.Example</AssemblyName>
```

...becomes...

```xml
<AssemblyName>NLog.Author.ModName</AssemblyName>
```

### Root namespace

```xml
<RootNamespace>Senko.Example</RootNamespace>
```

...becomes...

```xml
<RootNamespace>Author.ModName</RootNamespace>
```

### Namespace

```cs
namespace Senko.Example
{
    // ...
}
```

...becomes...

```cs
namespace Author.ModName
{
    // ...
}
```

### Target

```cs
[Target("Senko.Example")]
public sealed class Hook : TargetWithLayout
{
    // ...
}
```

...becomes...

```cs
[Target("Author.ModName")]
public sealed class Hook : TargetWithLayout
{
    // ...
}
```

## 7. Time to build

The final result looks like this:

```
ExampleMod/
  References/
    NLog.Haru.dll
  Hook.cs
  Mod.cs
  Author.ModName.code-workspace
  Author.ModName.csproj
```

Now that everything is in place, open `Author.ModName.code-workspace` in vscode
and click `Terminal` > `Run Build Task...`. If everything went right, your mod
will be located inside `<Mod>/bin/Release/net472/` and named
`NLog.Author.ModName.dll`.

## 8. Try it out!

If you have Haru installed, there should be a file named `NLog.dll.nlog` inside
`<EFT>/EscapeFromTarkov_Data/Managed/`. Open this file and change it to the
following:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd"
      xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">

	<targets>
		<target name="Haru" xsi:type="Haru" />
    <target name="Author.ModName" xsi:type="Author.ModName" />
	</targets>

</nlog>
```

Then copy-paste `NLog.ModName.dll` to `<EFT>/EscapeFromTarkov_Data/Managed/`.
Start the game, wait until you're into the main menu and check `haru.log`.
If everything went right, the message will pop up in your log!

## Conclusion

Admittingly it is a fair bit more complex than creating a mod for spt-aki 3.x
but you do get all the benefits from working with C#: autocompletion, proper
warnings and errors for issues, proper data definitions, faster working code
and much more!

Once you're through setting up the project's development environment, writing
the code itself is fairly easy and comparable to spt-aki 3.x.

One of the big benefits from doing modding this way, is that modding for the
server and the client shares alot so you get more room to grow. Another is that
you learn to work in a heavy-duty programming language, and can apply the
skills you learn here at entry-level programming jobs in C#.

I hope you enjoyed it and learned some new things from it!

- Senko-san
