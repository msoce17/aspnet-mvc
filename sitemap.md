# Sitemap i model usmjeravanja

Ovaj dokument prikazuje dostupne URL-ove u aplikaciji, pripadajuće controllere i akcije te view-ove koji se koriste za prikaz sadržaja.

## Napomena o rutiranju

Aplikacija koristi dvije vrste usmjeravanja:
- zadanu konvencionalnu rutu: `{controller=Home}/{action=Index}/{id?}`
- prilagođene atributne rute za odabrane controllere:
  - `EkipaController`
  - `IgracController`
  - `TurnirController`
  - `UtakmicaController`

Zbog toga neki dijelovi aplikacije imaju i prilagođeni URL i zadani URL koji vodi na istu akciju.

## Početna i sustavske stranice

### URL: `/`
- Controller: `HomeController`
- Akcija: `Index`
- View: `Views/Home/Index.cshtml`
- Opis: početna stranica s pregledom glavnih podataka sustava

### URL: `/Home/Index`
- Controller: `HomeController`
- Akcija: `Index`
- View: `Views/Home/Index.cshtml`
- Opis: alternativni URL za početnu stranicu preko default rute

### URL: `/Home/Privacy`
- Controller: `HomeController`
- Akcija: `Privacy`
- View: `Views/Home/Privacy.cshtml`
- Opis: stranica privatnosti

### URL: `/Home/Error`
- Controller: `HomeController`
- Akcija: `Error`
- View: `Views/Shared/Error.cshtml`
- Opis: stranica za prikaz sistemske greške

## Ekipe

### URL: `/ekipe`
- Controller: `EkipaController`
- Akcija: `Index`
- View: `Views/Ekipa/Index.cshtml`
- Opis: popis svih ekipa

### URL: `/Ekipa/Index`
- Controller: `EkipaController`
- Akcija: `Index`
- View: `Views/Ekipa/Index.cshtml`
- Opis: isti sadržaj preko default rute

### URL: `/ekipe/{id}`
- Controller: `EkipaController`
- Akcija: `Details`
- View: `Views/Ekipa/Details.cshtml`
- Opis: detalji pojedine ekipe i pripadajućih igrača

### URL: `/Ekipa/Details/{id}`
- Controller: `EkipaController`
- Akcija: `Details`
- View: `Views/Ekipa/Details.cshtml`
- Opis: isti sadržaj preko default rute

### URL: nepostojeći zapis, npr. `/ekipe/999`
- Controller: `EkipaController`
- Akcija: `Details`
- View: `Views/Shared/NotFound.cshtml`
- Opis: prilagođeni 404 prikaz kada ekipa ne postoji

## Igrači

### URL: `/igraci`
- Controller: `IgracController`
- Akcija: `Index`
- View: `Views/Igrac/Index.cshtml`
- Opis: popis svih igrača

### URL: `/Igrac/Index`
- Controller: `IgracController`
- Akcija: `Index`
- View: `Views/Igrac/Index.cshtml`
- Opis: isti sadržaj preko default rute

### URL: `/igraci/{id}`
- Controller: `IgracController`
- Akcija: `Details`
- View: `Views/Igrac/Details.cshtml`
- Opis: detalji pojedinog igrača

### URL: `/Igrac/Details/{id}`
- Controller: `IgracController`
- Akcija: `Details`
- View: `Views/Igrac/Details.cshtml`
- Opis: isti sadržaj preko default rute

### URL: nepostojeći zapis, npr. `/igraci/999`
- Controller: `IgracController`
- Akcija: `Details`
- View: `Views/Shared/NotFound.cshtml`
- Opis: prilagođeni 404 prikaz kada igrač ne postoji

## Turniri

### URL: `/turniri`
- Controller: `TurnirController`
- Akcija: `Index`
- View: `Views/Turnir/Index.cshtml`
- Opis: popis svih turnira

### URL: `/Turnir/Index`
- Controller: `TurnirController`
- Akcija: `Index`
- View: `Views/Turnir/Index.cshtml`
- Opis: isti sadržaj preko default rute

### URL: `/turniri/{id}`
- Controller: `TurnirController`
- Akcija: `Details`
- View: `Views/Turnir/Details.cshtml`
- Opis: detalji turnira, prijavljene ekipe i utakmice turnira

### URL: `/Turnir/Details/{id}`
- Controller: `TurnirController`
- Akcija: `Details`
- View: `Views/Turnir/Details.cshtml`
- Opis: isti sadržaj preko default rute

### URL: nepostojeći zapis, npr. `/turniri/999`
- Controller: `TurnirController`
- Akcija: `Details`
- View: `Views/Shared/NotFound.cshtml`
- Opis: prilagođeni 404 prikaz kada turnir ne postoji

## Utakmice

### URL: `/utakmice`
- Controller: `UtakmicaController`
- Akcija: `Index`
- View: `Views/Utakmica/Index.cshtml`
- Opis: popis svih utakmica

### URL: `/Utakmica/Index`
- Controller: `UtakmicaController`
- Akcija: `Index`
- View: `Views/Utakmica/Index.cshtml`
- Opis: isti sadržaj preko default rute

### URL: `/utakmice/{id}`
- Controller: `UtakmicaController`
- Akcija: `Details`
- View: `Views/Utakmica/Details.cshtml`
- Opis: detalji pojedine utakmice

### URL: `/Utakmica/Details/{id}`
- Controller: `UtakmicaController`
- Akcija: `Details`
- View: `Views/Utakmica/Details.cshtml`
- Opis: isti sadržaj preko default rute

### URL: nepostojeći zapis, npr. `/utakmice/999`
- Controller: `UtakmicaController`
- Akcija: `Details`
- View: `Views/Shared/NotFound.cshtml`
- Opis: prilagođeni 404 prikaz kada utakmica ne postoji

## Prijave ekipa

### URL: `/PrijavaEkipe/Index`
- Controller: `PrijavaEkipeController`
- Akcija: `Index`
- View: `Views/PrijavaEkipe/Index.cshtml`
- Opis: popis svih prijava ekipa na turnire

### URL: `/PrijavaEkipe/Details/{id}`
- Controller: `PrijavaEkipeController`
- Akcija: `Details`
- View: `Views/PrijavaEkipe/Details.cshtml`
- Opis: detalji pojedine prijave

### URL: nepostojeći zapis, npr. `/PrijavaEkipe/Details/999`
- Controller: `PrijavaEkipeController`
- Akcija: `Details`
- View: `Views/Shared/NotFound.cshtml`
- Opis: prilagođeni 404 prikaz kada prijava ne postoji

## Stadioni

### URL: `/Stadion/Index`
- Controller: `StadionController`
- Akcija: `Index`
- View: `Views/Stadion/Index.cshtml`
- Opis: popis svih stadiona

### URL: `/Stadion/Details/{id}`
- Controller: `StadionController`
- Akcija: `Details`
- View: `Views/Stadion/Details.cshtml`
- Opis: detalji pojedinog stadiona

### URL: nepostojeći zapis, npr. `/Stadion/Details/999`
- Controller: `StadionController`
- Akcija: `Details`
- View: `Views/Shared/NotFound.cshtml`
- Opis: prilagođeni 404 prikaz kada stadion ne postoji

## Sudci

### URL: `/Sudac/Index`
- Controller: `SudacController`
- Akcija: `Index`
- View: `Views/Sudac/Index.cshtml`
- Opis: popis svih sudaca

### URL: `/Sudac/Details/{id}`
- Controller: `SudacController`
- Akcija: `Details`
- View: `Views/Sudac/Details.cshtml`
- Opis: detalji pojedinog suca

### URL: nepostojeći zapis, npr. `/Sudac/Details/999`
- Controller: `SudacController`
- Akcija: `Details`
- View: `Views/Shared/NotFound.cshtml`
- Opis: prilagođeni 404 prikaz kada sudac ne postoji

## Zajednički view-ovi

Zajednički view-ovi koji se koriste kroz više stranica:
- `Views/Shared/_Layout.cshtml` - glavni layout aplikacije
- `Views/Shared/_Breadcrumbs.cshtml` - prikaz breadcrumb navigacije
- `Views/Shared/NotFound.cshtml` - prilagođeni prikaz kada zapis nije pronađen
- `Views/Shared/Error.cshtml` - prikaz sistemske greške

## Zaključak

Sitemap pokriva sve trenutno dostupne URL-ove u aplikaciji:
- početnu i sistemske stranice
- liste i detalje glavnih entiteta
- prilagođene URL-ove za ekipe, igrače, turnire i utakmice
- fallback prikaz za nepostojeće zapise

Na taj način je jasno vidljivo koji controller, koja akcija i koji view sudjeluju u obradi svakog dostupnog URL-a.
