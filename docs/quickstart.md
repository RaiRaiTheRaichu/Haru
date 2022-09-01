# Quickstart

## Requirements

- dotnet 6.0 sdk
- escape from tarkov 0.12.12.15.17686

## Build

1. download the source code
2. open `<source>/projects/Haru.code-workspace` in vscode
3. vscode > terminal > run build task... > release
4. copy-paste `<source>/projects/bin/release/net472/NLog.Haru.dll` into
   `EscapeFromTarkov_Data/Managed/`

## Run

Start the game with the following launch arguments:

```
EscapeFromTarkov.exe -token=aid -config={"BackendUrl":"url","Version":"live"}
```

- Replace `aid` with your account id (exp.: `senkosan`)
- Replace `url` with the host url (usually `http://127.0.0.1:8000`)
