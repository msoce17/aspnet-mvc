# Semantički model baze podataka

Ovaj dokument opisuje glavne entitete aplikacije za organizaciju nogometnih turnira, njihova najvažnija svojstva te veze među tablicama i klasama u sustavu.

## Pregled modela

### 1. `Ekipa` / tablica `Ekipe`

Predstavlja nogometnu ekipu koja sudjeluje na turnirima i igra utakmice.

Glavna svojstva:
- `EkipaId` - primarni ključ
- `Naziv` - naziv ekipe
- `Grad` - grad iz kojeg ekipa dolazi
- `DatumOsnutka` - datum osnutka ekipe
- `TrenerIme` - ime trenera
- `BrojIgraca` - broj evidentiranih igrača u ekipi
- `Kontakt` - kontakt podaci ekipe

Veze:
- jedna ekipa ima više igrača: `Ekipa 1-N Igrac`
- jedna ekipa može imati više prijava na turnire: `Ekipa 1-N PrijavaEkipe`
- jedna ekipa može biti domaća ekipa u više utakmica: `Ekipa 1-N Utakmica` preko `DomacaEkipaId`
- jedna ekipa može biti gostujuća ekipa u više utakmica: `Ekipa 1-N Utakmica` preko `GostujucaEkipaId`

### 2. `Igrac` / tablica `Igraci`

Predstavlja pojedinog igrača koji pripada jednoj ekipi.

Glavna svojstva:
- `IgracId` - primarni ključ
- `Ime` - ime igrača
- `Prezime` - prezime igrača
- `BrojDresa` - broj dresa
- `Pozicija` - pozicija u momčadi
- `DatumRodjenja` - datum rođenja
- `Drzava` - država igrača
- `Visina` - visina igrača
- `EkipaId` - strani ključ prema ekipi

Veze:
- više igrača pripada jednoj ekipi: `Igrac N-1 Ekipa`

### 3. `Turnir` / tablica `Turniri`

Predstavlja nogometni turnir na koji se ekipe prijavljuju i unutar kojeg se igraju utakmice.

Glavna svojstva:
- `TurnirId` - primarni ključ
- `Naziv` - naziv turnira
- `DatumPocetka` - datum početka turnira
- `DatumZavrsetka` - datum završetka turnira
- `Tip` - vrsta turnira
- `Opis` - opis turnira
- `MaximalanBrojEkipa` - maksimalan broj prijavljenih ekipa

Napomena:
- svojstvo `Tip` koristi enumeraciju `TipTurnira`
- moguće vrijednosti su:
  - `Friendly`
  - `Kvalifikacijski`
  - `Ligaski`
  - `Kup`

Veze:
- jedan turnir ima više prijava ekipa: `Turnir 1-N PrijavaEkipe`
- jedan turnir ima više utakmica: `Turnir 1-N Utakmica`

### 4. `PrijavaEkipe` / tablica `PrijaveEkipe`

Predstavlja veznu tablicu između ekipe i turnira, odnosno prijavu ekipe na određeni turnir.

Glavna svojstva:
- `PrijavaEkipeId` - primarni ključ
- `DatumPrijave` - datum prijave
- `Potvrdjeno` - oznaka je li prijava potvrđena
- `TurnirId` - strani ključ prema turniru
- `EkipaId` - strani ključ prema ekipi

Veze:
- više prijava pripada jednom turniru: `PrijavaEkipe N-1 Turnir`
- više prijava pripada jednoj ekipi: `PrijavaEkipe N-1 Ekipa`

Ova klasa modelira mnogi-prema-mnogi odnos između `Ekipa` i `Turnir`.

### 5. `Utakmica` / tablica `Utakmice`

Predstavlja pojedinu utakmicu odigranu ili zakazanu unutar turnira.

Glavna svojstva:
- `UtakmicaId` - primarni ključ
- `DatumVrijeme` - datum i vrijeme utakmice
- `GoloviDomace` - broj golova domaće ekipe
- `GoloviGosta` - broj golova gostujuće ekipe
- `Status` - status utakmice
- `Napomena` - dodatna napomena
- `TurnirId` - strani ključ prema turniru
- `DomacaEkipaId` - strani ključ prema domaćoj ekipi
- `GostujucaEkipaId` - strani ključ prema gostujućoj ekipi
- `StadionId` - strani ključ prema stadionu
- `SudacId` - strani ključ prema sucu

Veze:
- više utakmica pripada jednom turniru: `Utakmica N-1 Turnir`
- više utakmica može imati istu domaću ekipu: `Utakmica N-1 Ekipa`
- više utakmica može imati istu gostujuću ekipu: `Utakmica N-1 Ekipa`
- više utakmica može se igrati na istom stadionu: `Utakmica N-1 Stadion`
- više utakmica može suditi isti sudac: `Utakmica N-1 Sudac`

### 6. `Stadion` / tablica `Stadioni`

Predstavlja stadion ili lokaciju na kojoj se igraju utakmice.

Glavna svojstva:
- `StadionId` - primarni ključ
- `Naziv` - naziv stadiona
- `Grad` - grad u kojem se stadion nalazi
- `Kapacitet` - kapacitet stadiona

Veze:
- jedan stadion može imati više utakmica: `Stadion 1-N Utakmica`

### 7. `Sudac` / tablica `Sudci`

Predstavlja suca koji može suditi jednu ili više utakmica.

Glavna svojstva:
- `SudacId` - primarni ključ
- `Ime` - ime suca
- `Prezime` - prezime suca
- `Licenca` - vrsta ili oznaka licence

Veze:
- jedan sudac može suditi više utakmica: `Sudac 1-N Utakmica`

## Sažetak relacija

Glavne relacije u sustavu:
- `Ekipa 1-N Igrac`
- `Ekipa 1-N PrijavaEkipe`
- `Turnir 1-N PrijavaEkipe`
- `Turnir 1-N Utakmica`
- `Stadion 1-N Utakmica`
- `Sudac 1-N Utakmica`
- `Ekipa 1-N Utakmica` kao domaća ekipa
- `Ekipa 1-N Utakmica` kao gostujuća ekipa

Mnogi-prema-mnogi odnos:
- `Ekipa N-N Turnir`, realiziran preko entiteta `PrijavaEkipe`

## Zaključak

Model baze podataka pokriva osnovne funkcionalnosti aplikacije za organizaciju nogometnih turnira:
- evidenciju ekipa i igrača
- evidenciju turnira
- prijavu ekipa na turnire
- raspored i rezultate utakmica
- evidenciju stadiona i sudaca

Struktura modela omogućuje jasno povezivanje svih važnih podataka potrebnih za prikaz listi, detalja i odnosa među zapisima u aplikaciji.
