---
name: list-page-builder
description: Build or extend Razor list pages in this ASP.NET Core MVC football tournament project. Use when Codex needs to add a new list-style page, a read-only overview table, filtered entity listing, or a linked overview page that follows the existing layout, breadcrumbs, card, and table patterns in `Views/`.
---

# List Page Builder

Use this skill when creating a new list page or extending an existing index-style page.

## Project targets

- Controllers live in `SustavZaOrganizacijuNogometnihTurnira/Controllers/`
- View models live in `SustavZaOrganizacijuNogometnihTurnira/Models/`
- Razor views live in `SustavZaOrganizacijuNogometnihTurnira/Views/`
- Shared layout patterns live in:
  - `Views/Shared/_Layout.cshtml`
  - `Views/Shared/_Breadcrumbs.cshtml`
  - `wwwroot/css/site.css`

## Workflow

1. Identify whether the page can reuse an existing entity model or needs a dedicated view model.
2. Add a controller action that prepares only the data the page needs.
3. Prefer a dedicated view model when the page combines multiple entities.
4. Render the page with:
   - breadcrumbs
   - a `page-header`
   - a short descriptive paragraph
   - a `table-shell` with `data-table`
   - an `empty-state` when there are no records
5. Link key related records to their details pages.
6. Keep action labels in Croatian and consistent with the rest of the app.

## UI conventions

- Use the existing CSS classes before creating new ones.
- Prefer one clean table over nested cards for overview pages.
- Put the most useful column first, usually a clickable record name.
- Keep the rightmost column for actions such as `Detalji`, `Prijava`, or `Uredi`.
- If the page belongs under another entity, add a secondary back link and breadcrumbs.

## Example in this project

A good pattern is the added tournament teams overview page:
- controller action under `TurnirController`
- dedicated `TurnirTeamsListViewModel`
- Razor view under `Views/Turnir/Teams.cshtml`

## Validation

- Build after changes.
- Open the page and verify:
  - the breadcrumb is correct
  - links resolve
  - the empty state appears when the result set is empty
  - the table remains readable on narrow screens
