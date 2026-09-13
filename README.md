# dotnet-skel

Clean Architecture .NET 10 skeleton generator.

Pass a project name and get Domain / Application / Infrastructure / API plus one functionality-focused test project, with DI registered under `API/ServiceCollection`.

## Quick start

```bash
git clone https://github.com/munyaimanuwel/dotnet-skel.git
cd dotnet-skel
chmod +x bin/new.sh
./bin/new.sh Acme.Widget
cd acme-widget && dotnet test
```

Creates `./acme-widget` in the current directory (slug = lowercased name, `.` → `-`).

### Options

```bash
./bin/new.sh MyApp --out ~/code              # → ~/code/myapp
./bin/new.sh MyApp --github                  # create public munyaimanuwel/myapp + push (needs gh)
./bin/new.sh MyApp --github --private
```

## What you get

| Path | Purpose |
|------|---------|
| `src/<Name>.Domain/` | Entities + interfaces; **zero** NuGet / project refs |
| `src/<Name>.Application/` | Services, DTOs, interfaces; refs Domain only |
| `src/<Name>.Infrastructure/` | Thin in-memory `IUnitOfWork`; refs Domain + Application |
| `src/<Name>.API/` | ASP.NET Core host; DI via `ServiceCollection/*.cs` |
| `test/<Name>.Tests/` | xUnit functionality tests (refs Application) |
| `.github/workflows/ci.yml` | restore / build / test on PR + main |

Placeholders `__NAME__`, `__NAMESPACE__`, `__SLUG__` are replaced by `bin/new.sh`.

## Design notes

- Target framework: `net10.0`
- Dependencies point inward: Domain ← Application ← Infrastructure; API composes Application + Infrastructure
- DI lives in `API/ServiceCollection/*Extensions.cs`
- No EF / Postgres yet — swap the in-memory unit of work when ready
