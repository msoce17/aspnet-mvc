---
name: entity-framework-helper
description: Help update Entity Framework Core models, DbContext configuration, repositories, SQLite connection setup, and migrations in this ASP.NET Core MVC football tournament project. Use when Codex needs to change EF entities in `SustavZaOrganizacijuNogometnihTurnira.Model`, adjust relationships, add or update repository methods, or generate and apply EF migrations.
---

# Entity Framework Helper

Use this skill when changing persistent domain data in this project.

## Project targets

- Entity classes live in `SustavZaOrganizacijuNogometnihTurnira.Model/`
- DbContext lives in `SustavZaOrganizacijuNogometnihTurnira.Model/Data/ApplicationDbContext.cs`
- Repositories live in `SustavZaOrganizacijuNogometnihTurnira.Model/Repositories/`
- Web DI and database startup live in `SustavZaOrganizacijuNogometnihTurnira/Program.cs`
- Connection string lives in `SustavZaOrganizacijuNogometnihTurnira/appsettings.json`
- EF migrations live in `SustavZaOrganizacijuNogometnihTurnira.Model/Data/Migrations/`

## Workflow

1. Read the affected entity or entities first.
2. Keep EF annotations, `virtual` navigation properties, and `ICollection<>` relationships consistent.
3. Update `ApplicationDbContext` when the change affects relationships, precision, seeding, or table configuration.
4. Update the repository methods used by controllers and views.
5. If the UI depends on the new data, update the controller, view model, and Razor view in the same pass.
6. Build the solution after code changes.
7. Generate or update the migration after the model is stable.
8. Apply the migration so the SQLite database matches the code.

## Project conventions

- Keep Croatian domain naming already used in the project.
- Prefer data annotations on entity classes for required fields, lengths, ranges, and foreign keys.
- Use `AsNoTracking()` for read-only repository queries.
- Keep repository methods simple and controller-oriented.
- Seed data is currently defined in `ApplicationDbContext`.
- SQLite is the configured database provider for this repo.

## Common tasks

### Add or change an entity field

- Update the entity class.
- Update any view model that edits or displays the field.
- Update repository mapping if the entity is created or updated manually.
- Add a migration.

### Add a relationship

- Add the foreign key property.
- Add the navigation property on the dependent entity.
- Add the inverse collection or navigation on the principal entity when needed.
- Configure special cases in `OnModelCreating`, especially when multiple foreign keys point to the same table.
- Add a migration.

### Add create or edit support

- Extend the repository with `Add`, `Update`, or existence checks.
- Add GET and POST controller actions with validation.
- Add or update Razor forms.

## Validation

- Run `dotnet build SustavZaOrganizacijuNogometnihTurnira.sln`
- If the app executable is locked because the app is running, use:
  - `dotnet build SustavZaOrganizacijuNogometnihTurnira.sln /p:UseAppHost=false`
- For migrations, use:
  - `dotnet tool run dotnet-ef migrations add <Name> --project SustavZaOrganizacijuNogometnihTurnira.Model --startup-project SustavZaOrganizacijuNogometnihTurnira --output-dir Data\Migrations`
  - `dotnet tool run dotnet-ef database update --project SustavZaOrganizacijuNogometnihTurnira.Model --startup-project SustavZaOrganizacijuNogometnihTurnira`
