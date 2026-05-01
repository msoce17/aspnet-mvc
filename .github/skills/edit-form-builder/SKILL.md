---
name: edit-form-builder
description: Build Razor create and edit forms in this ASP.NET Core MVC football tournament project. Use when Codex needs to add GET and POST form actions, a form view model with validation, Razor form views, or controller-to-repository save flows that match the existing project style.
---

# Edit Form Builder

Use this skill when adding a create form, edit form, or both.

## Project targets

- Form-capable controllers live in `SustavZaOrganizacijuNogometnihTurnira/Controllers/`
- Form view models live in `SustavZaOrganizacijuNogometnihTurnira/Models/`
- Repositories used for persistence live in `SustavZaOrganizacijuNogometnihTurnira.Model/Repositories/`
- Razor form views live in `SustavZaOrganizacijuNogometnihTurnira/Views/`
- Shared CSS lives in `wwwroot/css/site.css`

## Workflow

1. Create a dedicated form view model when the form should not bind directly to the EF entity.
2. Add validation attributes and Croatian validation messages.
3. Add the GET action that prepares the blank or prefilled form.
4. Add the POST action with:
   - `ValidateAntiForgeryToken`
   - `ModelState` check
   - repository save logic
   - redirect to details or list page on success
5. Add a strongly typed Razor form using tag helpers.
6. Include validation summary and per-field validation messages.
7. Include `_ValidationScriptsPartial` in the view.

## UI conventions

- Reuse:
  - `page-header`
  - `secondary-action`
  - `primary-action`
  - `action-link`
- Use form-specific wrappers such as:
  - `form-shell`
  - `entity-form`
  - `form-grid`
  - `form-field`
  - `form-input`
  - `form-actions`
- Keep forms readable and beginner-friendly.

## Project conventions

- Keep form labels in Croatian.
- Prefer redirecting to the newly created or updated record details page.
- For edit forms, verify the record exists before saving.
- Use the shared `NotFound` view for missing records.

## Example in this project

A good reference is the added `Ekipa` form flow:
- `EkipaFormViewModel`
- `EkipaController.Create`
- `EkipaController.Edit`
- `Views/Ekipa/Create.cshtml`
- `Views/Ekipa/Edit.cshtml`

## Validation

- Build after changes.
- Test both valid and invalid form submissions.
- Check that validation messages appear.
- Check that successful submit redirects correctly.
