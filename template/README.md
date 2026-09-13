# __NAME__

Clean Architecture .NET 10 solution (Domain / Application / Infrastructure / API + tests).

## Build

```bash
dotnet restore
dotnet build
dotnet test
```

## Run API

```bash
dotnet run --project src/__NAME__.API
```

## Layout

```
src/__NAME__.Domain/          # entities + domain interfaces (no deps)
src/__NAME__.Application/     # services, DTOs
src/__NAME__.Infrastructure/  # in-memory persistence (thin)
src/__NAME__.API/             # host + ServiceCollection DI extensions
test/__NAME__.Tests/
.github/workflows/ci.yml
```

Generated from [dotnet-skel](https://github.com/munyaimanuwel/dotnet-skel).
