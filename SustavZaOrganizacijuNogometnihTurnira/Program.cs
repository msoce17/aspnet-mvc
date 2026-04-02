using System;
using System.Collections.Generic;
using SustavZaOrganizacijuNogometnihTurnira.Model.Enums;
using SustavZaOrganizacijuNogometnihTurnira.Model;

namespace NazivaProjekat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SUSTAV ZA ORGANIZACIJU NOGOMETNIH TURNIRA ===\n");

            // ========== STADIONI ==========
            Stadion stadionMaximir = new Stadion
            {
                StadionId = 1,
                Naziv = "Stadion Maksimir",
                Grad = "Zagreb",
                Kapacitet = 35000
            };

            Stadion stadionOljica = new Stadion
            {
                StadionId = 2,
                Naziv = "Stadion Oljica",
                Grad = "Split",
                Kapacitet = 18000
            };

            Stadion stadionGradski = new Stadion
            {
                StadionId = 3,
                Naziv = "Gradski stadion",
                Grad = "Rijeka",
                Kapacitet = 20000
            };

            List<Stadion> stadioni = new List<Stadion> { stadionMaximir, stadionOljica, stadionGradski };

            // ========== SUDCI ==========
            Sudac sudac1 = new Sudac
            {
                SudacId = 1,
                Ime = "Marko",
                Prezime = "Horvat",
                Licenca = "UEFA-A"
            };

            Sudac sudac2 = new Sudac
            {
                SudacId = 2,
                Ime = "Ivan",
                Prezime = "Milic",
                Licenca = "UEFA-B"
            };

            Sudac sudac3 = new Sudac
            {
                SudacId = 3,
                Ime = "Petar",
                Prezime = "Novak",
                Licenca = "UEFA-A"
            };

            List<Sudac> sudci = new List<Sudac> { sudac1, sudac2, sudac3 };


            // ========== TURNIR 1.==========
            Turnir turnir1 = new Turnir
            {
                TurnirId = 1,
                Naziv = "Ljetni nogometni turnir",
                DatumPocetka = new DateTime(2024, 7, 1),
                DatumZavrsetka = new DateTime(2024, 7, 15),
                Tip = TipTurnira.Kup,
                Opis = "Ljetni kup turnir za amaterske ekipe.",
                MaximalanBrojEkipa = 16
            };

            //EKIPA 1.1
            Ekipa ekipa1_1 = new Ekipa
            {
                EkipaId = 1,
                Naziv = "NK Zagreb",
                Grad = "Zagreb",
                DatumOsnutka = new DateTime(1903, 6, 1),
                TrenerIme = "Ante",
                BrojIgraca = 3,
                Kontakt = "0123456789"
            };

            //Igrači za ekipu 1.1
            Igrac igrac1_1_1 = new Igrac
            {
                IgracId = 1,
                Ime = "Luka",
                Prezime = "Modric",
                Pozicija = "Vezni",
                BrojDresa = 10,
                DatumRodjenja = new DateTime(1985, 9, 9),
                Drzava = "Hrvatska",
                Visina = 1.72m,
                EkipaId = ekipa1_1.EkipaId
            };

            Igrac igrac1_1_2 = new Igrac
            {
                IgracId = 2,
                Ime = "Ivan",
                Prezime = "Rakitic",
                Pozicija = "Vezni",
                BrojDresa = 7,
                DatumRodjenja = new DateTime(1988, 3, 10),
                Drzava = "Hrvatska",
                Visina = 1.84m,
                EkipaId = ekipa1_1.EkipaId
            };

            Igrac igrac1_1_3 = new Igrac
            {
                IgracId = 3,
                Ime = "Dejan",
                Prezime = "Lovren",
                Pozicija = "Obrana",
                BrojDresa = 6,
                DatumRodjenja = new DateTime(1989, 7, 5),
                Drzava = "Hrvatska",
                Visina = 1.88m,
                EkipaId = ekipa1_1.EkipaId
            };

            ekipa1_1.Igraci.Add(igrac1_1_1);
            ekipa1_1.Igraci.Add(igrac1_1_2);
            ekipa1_1.Igraci.Add(igrac1_1_3);


            //EKIPA 1.2
            Ekipa ekipa1_2 = new Ekipa
            {
                EkipaId = 2,
                Naziv = "HNK Split",
                Grad = "Split",
                DatumOsnutka = new DateTime(1912, 4, 16),
                TrenerIme = "Miroslav",
                BrojIgraca = 3,
                Kontakt = "0987654321"
            };

            //Igrači za ekipu 1.2
            Igrac igrac1_2_1 = new Igrac
            {
                IgracId = 4,
                Ime = "Mario",
                Prezime = "Mandzukic",
                Pozicija = "Napad",
                BrojDresa = 9,
                DatumRodjenja = new DateTime(1986, 5, 21),
                Drzava = "Hrvatska",
                Visina = 1.87m,
                EkipaId = ekipa1_2.EkipaId
            };

            Igrac igrac1_2_2 = new Igrac
            {
                IgracId = 5,
                Ime = "Marko",
                Prezime = "Pjaca",
                Pozicija = "Vezni",
                BrojDresa = 8,
                DatumRodjenja = new DateTime(1995, 5, 6),
                Drzava = "Hrvatska",
                Visina = 1.80m,
                EkipaId = ekipa1_2.EkipaId
            };

            Igrac igrac1_2_3 = new Igrac
            {
                IgracId = 6,
                Ime = "Ante",
                Prezime = "Budućnost",
                Pozicija = "Obrana",
                BrojDresa = 5,
                DatumRodjenja = new DateTime(1990, 11, 12),
                Drzava = "Hrvatska",
                Visina = 1.85m,
                EkipaId = ekipa1_2.EkipaId
            };

            ekipa1_2.Igraci.Add(igrac1_2_1);
            ekipa1_2.Igraci.Add(igrac1_2_2);
            ekipa1_2.Igraci.Add(igrac1_2_3);


            //Prijava ekipa na turnir
            PrijavaEkipe prijava1_1 = new PrijavaEkipe
            {
                PrijavaEkipeId = 1,
                TurnirId = turnir1.TurnirId,
                EkipaId = ekipa1_1.EkipaId,
                DatumPrijave = new DateTime(2024, 6, 1),
                Potvrdjeno = true
            };
            prijava1_1.Ekipa = ekipa1_1;

            PrijavaEkipe prijava1_2 = new PrijavaEkipe
            {
                PrijavaEkipeId = 2,
                TurnirId = turnir1.TurnirId,
                EkipaId = ekipa1_2.EkipaId,
                DatumPrijave = new DateTime(2024, 6, 2),
                Potvrdjeno = true
            };
            prijava1_2.Ekipa = ekipa1_2;

            turnir1.PrijaveEkipe.Add(prijava1_1);
            turnir1.PrijaveEkipe.Add(prijava1_2);

            ekipa1_1.PrijaveEkipe.Add(prijava1_1);
            ekipa1_2.PrijaveEkipe.Add(prijava1_2);

            //Utakmica za turnir
            Utakmica utakmica1_1 = new Utakmica
            {
                UtakmicaId = 1,
                TurnirId = turnir1.TurnirId,
                DomacaEkipaId = ekipa1_1.EkipaId,
                GostujucaEkipaId = ekipa1_2.EkipaId,
                DatumVrijeme = new DateTime(2024, 7, 3, 18, 0, 0),
                StadionId = stadionMaximir.StadionId,
                SudacId = sudac1.SudacId,
                GoloviDomace = 2,
                GoloviGosta = 1,
                Status = "Završena",
                Napomena = "Dobra utakmica, puno navijača."
            };
            utakmica1_1.DomacaEkipa = ekipa1_1;
            utakmica1_1.GostujucaEkipa = ekipa1_2;
            utakmica1_1.Stadion = stadionMaximir;
            utakmica1_1.Sudac = sudac1;

            turnir1.Utakmice.Add(utakmica1_1);
            ekipa1_1.DomaceUtakmice.Add(utakmica1_1);
            ekipa1_2.GostujuceUtakmice.Add(utakmica1_1);




            // ========== TURNIR 2.==========
            Turnir turnir2 = new Turnir {
                TurnirId = 2,
                Naziv = "Zimski nogometni turnir",
                DatumPocetka = new DateTime(2024, 12, 1),
                DatumZavrsetka = new DateTime(2024, 12, 15),
                Tip = TipTurnira.Ligaski,
                Opis = "Zimski liga turnir za amaterske ekipe.",
                MaximalanBrojEkipa = 2
            };


            //EKIPA 2.1
            Ekipa ekipa2_1 = new Ekipa
            {
                EkipaId = 3,
                Naziv = "NK Rijeka",
                Grad = "Rijeka",
                DatumOsnutka = new DateTime(1946, 6, 29),
                TrenerIme = "Zoran",
                BrojIgraca = 3,
                Kontakt = "0112233445"
            };

            //Igrači za ekipu 2.1
            Igrac igrac2_1_1 = new Igrac
            {
                IgracId = 7,
                Ime = "Filip",
                Prezime = "Bradarić",
                Pozicija = "Vezni",
                BrojDresa = 14,
                DatumRodjenja = new DateTime(1992, 3, 10),
                Drzava = "Hrvatska",
                Visina = 1.80m,
                EkipaId = ekipa2_1.EkipaId
            };

            Igrac igrac2_1_2 = new Igrac
            {
                IgracId = 8,
                Ime = "Mateo",
                Prezime = "Kovačić",
                Pozicija = "Vezni",
                BrojDresa = 11,
                DatumRodjenja = new DateTime(1994, 5, 6),
                Drzava = "Hrvatska",
                Visina = 1.78m,
                EkipaId = ekipa2_1.EkipaId
            };

            Igrac igrac2_1_3 = new Igrac
            {
                IgracId = 9,
                Ime = "Domagoj",
                Prezime = "Vida",
                Pozicija = "Obrana",
                BrojDresa = 4,
                DatumRodjenja = new DateTime(1989, 11, 12),
                Drzava = "Hrvatska",
                Visina = 1.85m,
                EkipaId = ekipa2_1.EkipaId
            };

            ekipa2_1.Igraci.Add(igrac2_1_1);
            ekipa2_1.Igraci.Add(igrac2_1_2);
            ekipa2_1.Igraci.Add(igrac2_1_3);

            //EKIPA 2.2
            Ekipa ekipa2_2 = new Ekipa
            {
                EkipaId = 4,
                Naziv = "HNK Osijek",
                Grad = "Osijek",
                DatumOsnutka = new DateTime(1947, 5, 27),
                TrenerIme = "Dario",
                BrojIgraca = 3,
                Kontakt = "0223344556"
            };

            //Igrači za ekipu 2.2
            Igrac igrac2_2_1 = new Igrac
            {
                IgracId = 10,
                Ime = "Bruno",
                Prezime = "Petković",
                Pozicija = "Napad",
                BrojDresa = 9,
                DatumRodjenja = new DateTime(1996, 5, 21),
                Drzava = "Hrvatska",
                Visina = 1.87m,
                EkipaId = ekipa2_2.EkipaId
            };

            Igrac igrac2_2_2 = new Igrac
            {
                IgracId = 11,
                Ime = "Ante",
                Prezime = "Vukušić",
                Pozicija = "Vezni",
                BrojDresa = 8,
                DatumRodjenja = new DateTime(1990, 5, 6),
                Drzava = "Hrvatska",
                Visina = 1.80m,
                EkipaId = ekipa2_2.EkipaId
            };

            Igrac igrac2_2_3 = new Igrac
            {
                IgracId = 12,
                Ime = "Dino",
                Prezime = "Perić",
                Pozicija = "Obrana",
                BrojDresa = 5,
                DatumRodjenja = new DateTime(1990, 11, 12),
                Drzava = "Hrvatska",
                Visina = 1.85m,
                EkipaId = ekipa2_2.EkipaId
            };

            ekipa2_2.Igraci.Add(igrac2_2_1);
            ekipa2_2.Igraci.Add(igrac2_2_2);
            ekipa2_2.Igraci.Add(igrac2_2_3);

            //Prijava ekipa na turnir
            PrijavaEkipe prijava2_1 = new PrijavaEkipe
            {
                PrijavaEkipeId = 3,
                TurnirId = turnir2.TurnirId,
                EkipaId = ekipa2_1.EkipaId,
                DatumPrijave = new DateTime(2024, 11, 1),
                Potvrdjeno = true
            };
            prijava2_1.Ekipa = ekipa2_1;

            PrijavaEkipe prijava2_2 = new PrijavaEkipe
            {
                PrijavaEkipeId = 4,
                TurnirId = turnir2.TurnirId,
                EkipaId = ekipa2_2.EkipaId,
                DatumPrijave = new DateTime(2024, 11, 2),
                Potvrdjeno = true
            };
            prijava2_2.Ekipa = ekipa2_2;

            turnir2.PrijaveEkipe.Add(prijava2_1);
            turnir2.PrijaveEkipe.Add(prijava2_2);

            ekipa2_1.PrijaveEkipe.Add(prijava2_1);
            ekipa2_2.PrijaveEkipe.Add(prijava2_2);

            //Utakmice za turnir
            Utakmica utakmica2_1 = new Utakmica
            {
                UtakmicaId = 2,
                TurnirId = turnir2.TurnirId,
                DomacaEkipaId = ekipa2_1.EkipaId,
                GostujucaEkipaId = ekipa2_2.EkipaId,
                DatumVrijeme = new DateTime(2024, 12, 3, 18, 0, 0),
                StadionId = stadionOljica.StadionId,
                SudacId = sudac2.SudacId,
                GoloviDomace = 1,
                GoloviGosta = 1,
                Status = "Završena",
                Napomena = "Izjednačena utakmica."
            };
            utakmica2_1.DomacaEkipa = ekipa2_1;
            utakmica2_1.GostujucaEkipa = ekipa2_2;
            utakmica2_1.Stadion = stadionOljica;
            utakmica2_1.Sudac = sudac2;
            utakmica2_1.Turnir = turnir2;

            utakmica2_1.Turnir.Utakmice.Add(utakmica2_1);
            ekipa2_1.DomaceUtakmice.Add(utakmica2_1);
            ekipa2_2.GostujuceUtakmice.Add(utakmica2_1);






            // ========== TURNIR 3.==========
            Turnir turnir3 = new Turnir {
                TurnirId = 3,
                Naziv = "Proljetni nogometni turnir",
                DatumPocetka = new DateTime(2024, 3, 1),
                DatumZavrsetka = new DateTime(2024, 3, 15),
                Tip = TipTurnira.Friendly,
                Opis = "Proljetni kup turnir za amaterske ekipe.",
                MaximalanBrojEkipa = 8
            };

            PrijavaEkipe prijava3_1 = new PrijavaEkipe
            {
                PrijavaEkipeId = 5,
                TurnirId = turnir3.TurnirId,
                EkipaId = ekipa1_1.EkipaId,
                DatumPrijave = new DateTime(2024, 2, 1),
                Potvrdjeno = true
            };
            prijava3_1.Ekipa = ekipa1_1;

            PrijavaEkipe prijava3_2 = new PrijavaEkipe
            {
                PrijavaEkipeId = 6,
                TurnirId = turnir3.TurnirId,
                EkipaId = ekipa2_1.EkipaId,
                DatumPrijave = new DateTime(2024, 2, 2),
                Potvrdjeno = true
            };
            prijava3_2.Ekipa = ekipa2_1;

            turnir3.PrijaveEkipe.Add(prijava3_1);
            turnir3.PrijaveEkipe.Add(prijava3_2);

            ekipa1_1.PrijaveEkipe.Add(prijava3_1);
            ekipa2_1.PrijaveEkipe.Add(prijava3_2);

            //Utakmice za turnir
            Utakmica utakmica3_1 = new Utakmica
            {
                UtakmicaId = 3,
                TurnirId = turnir3.TurnirId,
                DomacaEkipaId = ekipa1_1.EkipaId,
                GostujucaEkipaId = ekipa2_1.EkipaId,
                DatumVrijeme = new DateTime(2024, 3, 3, 18, 0, 0),
                StadionId = stadionGradski.StadionId,
                SudacId = sudac3.SudacId,
                GoloviDomace = 0,
                GoloviGosta = 2,
                Status = "Završena",
                Napomena = "Dobra utakmica, ali domaćini nisu uspjeli postići gol."
            };
            utakmica3_1.DomacaEkipa = ekipa1_1;
            utakmica3_1.GostujucaEkipa = ekipa2_1;
            utakmica3_1.Stadion = stadionGradski;
            utakmica3_1.Sudac = sudac3;

            turnir3.Utakmice.Add(utakmica3_1);
            ekipa1_1.DomaceUtakmice.Add(utakmica3_1);
            ekipa2_1.GostujuceUtakmice.Add(utakmica3_1);















            // ========== ISPIS PODATAKA ==========AI
            Console.WriteLine("\n╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║          REGISTRIRANI TURNIRI I EKIPE                     ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");

            List<Turnir> turniri = new List<Turnir> { turnir1, turnir2, turnir3};

            foreach (var turnir in turniri)
            {
                Console.WriteLine($"\n TURNIR: {turnir.Naziv}");
                Console.WriteLine($"   Tip: {turnir.Tip}");
                Console.WriteLine($"   Datum: {turnir.DatumPocetka:dd.MM.yyyy} - {turnir.DatumZavrsetka:dd.MM.yyyy}");
                Console.WriteLine($"   Opis: {turnir.Opis}");
                Console.WriteLine($"   Max ekipa: {turnir.MaximalanBrojEkipa}");
                Console.WriteLine($"   Registrirane ekipe: {turnir.PrijaveEkipe.Count}");
                Console.WriteLine("   " + new string('─', 55));

                foreach (var prijava in turnir.PrijaveEkipe)
                {
                    Console.WriteLine($"\n    EKIPA: {prijava.Ekipa.Naziv}");
                    Console.WriteLine($"      Grad: {prijava.Ekipa.Grad}");
                    Console.WriteLine($"      Osnuta: {prijava.Ekipa.DatumOsnutka:yyyy}");
                    Console.WriteLine($"      Trener: {prijava.Ekipa.TrenerIme}");
                    Console.WriteLine($"      Broj igrača: {prijava.Ekipa.BrojIgraca}");
                    Console.WriteLine($"      Kontakt: {prijava.Ekipa.Kontakt}");
                    Console.WriteLine($"      Prijava potvrđena: {(prijava.Potvrdjeno ? "✓ DA" : "✗ NE")}");
                    Console.WriteLine($"      Datum prijave: {prijava.DatumPrijave:dd.MM.yyyy}");

                    if (prijava.Ekipa.Igraci.Count > 0)
                    {
                        Console.WriteLine("      Igrači:");
                        foreach (var igrac in prijava.Ekipa.Igraci)
                        {
                            Console.WriteLine($"         • #{igrac.BrojDresa} {igrac.Ime} {igrac.Prezime} - {igrac.Pozicija} ({igrac.DatumRodjenja:yyyy})");
                        }
                    }
                }

                if (turnir.Utakmice.Count > 0)
                {
                    Console.WriteLine($"\n    UTAKMICE ({turnir.Utakmice.Count}):");
                    foreach (var utakmica in turnir.Utakmice)
                    {
                        Console.WriteLine($"      • {utakmica.DomacaEkipa.Naziv} vs {utakmica.GostujucaEkipa.Naziv}");
                        Console.WriteLine($"        Rezultat: {utakmica.GoloviDomace}:{utakmica.GoloviGosta} | {utakmica.DatumVrijeme:dd.MM.yyyy HH:mm}");
                        Console.WriteLine($"        Stadion: {utakmica.Stadion.Naziv} | Sudac: {utakmica.Sudac.Ime} {utakmica.Sudac.Prezime}");
                        Console.WriteLine($"        Status: {utakmica.Status}");
                    }
                }

                Console.WriteLine("\n");
            }

            // ========== STATISTIKA ==========
            Console.WriteLine("\n╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    UKUPNA STATISTIKA                      ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
            
            //LINQ
            int ukupnoEkipa = turniri.SelectMany(t => t.PrijaveEkipe).Select(p => p.EkipaId).Distinct().Count();
            int ukupnoUtakmica = turniri.Sum(t => t.Utakmice.Count);
            int ukupnoIgraca = new List<Ekipa> { ekipa1_1, ekipa1_2, ekipa2_1, ekipa2_2 }
                .Sum(e => e.Igraci.Count);

            Console.WriteLine($" Broj turnira: {turniri.Count}");
            Console.WriteLine($" Broj jedinstvenih ekipa: {ukupnoEkipa}");
            Console.WriteLine($" Broj igrača: {ukupnoIgraca}");
            Console.WriteLine($" Broj stadiona: {stadioni.Count}");
            Console.WriteLine($" Broj sudaca: {sudci.Count}");
            Console.WriteLine($" Broj odigranih utakmica: {ukupnoUtakmica}");

            Console.WriteLine("\n\nPritisnite bilo koju tipku za izlaz...");
            Console.ReadKey();






        }
    }
}