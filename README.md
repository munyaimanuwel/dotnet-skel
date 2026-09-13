# dotnet-skel

Clean Architecture .NET 8 skeleton generator — Domain / Application / Infrastructure / API + tests.

Mirrors a typical ops-sentinel-style backend layout. Pass a name, get a full solution with DI via API `ServiceCollection` extensions.

## Quick start

```bash
git clone https://github.com/munyaimanuwel/dotnet-skel.git
cd dotnet-skel
chmod +x bin/new.sh
./bin/new.sh Acme.Widget
cd acme-widget && dotnet test
```

### Options

```bash
./bin/new.sh MyApp --out ~/code
./bin/new.sh MyApp --github          # create public munyaimanuwel/myapp + push (needs gh)
./bin/new.sh MyApp --github --private
```

## What you get

| Path | Purpose |
|------|---------|
| `src/<Name>.Domain/` | Entities + interfaces; **zero** NuGet / project refs |
| `src/<Name>.Application/` | Services, DTOs, interfaces; refs Domain only |
| `src/<Name>.Infrastructure/` | Thin in-memory `IUnitOfWork`; refs Domain + Application |
| `src/<Name>.API/` | ASP.NET Core host; DI via `ServiceCollection/*.cs` |
| `test/<Name>.Domain.Tests/` | xUnit smoke |
| `test/<Name>.Application.Tests/` | xUnit smoke |
| `.github/workflows/ci.yml` | restore / build / test on PR + main |

Placeholders `__NAME__`, `__NAMESPACE__`, `__SLUG__` are replaced by `bin/new.sh`.

## Design notes

- DI lives in `API/ServiceCollection/*Extensions.cs` (not Infrastructure `DependencyInjection.cs`).
- No EF / Postgres yet — swap the in-memory unit of work when ready.
- Repo slug = lowercased name with `.` → `-`.
