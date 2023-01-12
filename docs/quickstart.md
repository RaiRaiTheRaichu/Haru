# Quickstart

## Requirements

- [dotnet 6.0 sdk x64](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [bepinex x64](https://github.com/BepInEx/BepInEx/releases/latest)
- escape from tarkov 0.13.0.21531

## Setup

1. download the source code
2. open `<source>/projects/Haru.code-workspace` in vscode
3. copy-paste the files inside the bepinex zip to `<gamedir>`

## Build

1. vscode > terminal > run build task...
2. copy-paste the following to `<gamedir>/EscapeFromTarkov_Data/Managed`:
    - `Core/Haru.Client/bin/Debug/net472/Haru.dll`
    - `Core/Haru.Client/bin/Debug/net472/Haru.Framework.dll`
3. copy-paste the following to `<gamedir>/BepInEx/plugins`:
    - `Core/Haru.Client/bin/Debug/net472/Haru.Client.dll`
    - `Mods/Senko.EftData/bin/Debug/net472/Senko.EftData.dll`

## Run

Start the game with the following launch arguments:

```
EscapeFromTarkov.exe -token=aid -config={"BackendUrl":"url","Version":"live"}
```

- Replace `aid` with your account id (exp.: `senkosan`)
- Replace `url` with the host url (usually `http://127.0.0.1:8000`)
