using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.WebAPI
{
    public partial class AppDBContext
    {
        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            List<string> Salt = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                Salt.Add(GenerateSalt());
            }

            modelBuilder.Entity<Korisnici>().HasData
            (
                new Korisnici
                {
                    KorisnikID = 1,
                    NazivKorisnika = "Vlasnik",
                    PasswordSalt = "j9YrZlzsNBJqETEVzYkMrw==",
                    PasswordHash = "G3ecAz/XArwcFmxWq8zeJipjdZY="
                },
                new Korisnici
                {
                    KorisnikID = 2,
                    NazivKorisnika = "Administrator",
                    PasswordSalt = "uquYuXHmsv0Z8gpDR/Q0EQ==",
                    PasswordHash = "PwqLALYJ7xw6aDlHARYsNAmwTN8="
                },
                new Korisnici
                {
                    KorisnikID = 3,
                    NazivKorisnika = "7",
                    PasswordSalt = "urZ/n7EOOW05DPHwnVz4Ng==",
                    PasswordHash = "FvcyfCRzhVAhYKFE6/xwH1LmWgQ="
                }
            );

            modelBuilder.Entity<Uloge>().HasData(

                new Uloge
                {
                    UlogaID = 1,
                    NazivUloge = "Vlasnik"
                },
                new Uloge
                {
                    UlogaID = 2,
                    NazivUloge = "Administrator"
                }
                );

            modelBuilder.Entity<KorisnikUloga>().HasData(

                new KorisnikUloga
                {
                    KorisnikUlogaID = 1,
                    KorisniciID = 1,
                    UlogeID = 1
                },
                new KorisnikUloga
                {
                    KorisnikUlogaID = 2,
                    KorisniciID = 2,
                    UlogeID = 2
                },
                new KorisnikUloga
                {
                    KorisnikUlogaID = 3,
                    KorisniciID = 3,
                    UlogeID = 2
                }
                );
            modelBuilder.Entity<JedinicaKolicine>().HasData(

                new JedinicaKolicine
                {
                    JedinicaKolicineID = 1,
                    NazivJedinice = "Kilogram"
                },
                new JedinicaKolicine
                {
                    JedinicaKolicineID = 2,
                    NazivJedinice = "Litar"
                }
                );
            modelBuilder.Entity<KategorijaProizvoda>().HasData(

                new KategorijaProizvoda
                {
                    KategorijaProizvodaID = 1,
                    NazivKategorije = "Hrana"
                },
                new KategorijaProizvoda
                {
                    KategorijaProizvodaID = 2,
                    NazivKategorije = "Piće"
                }
                );

            modelBuilder.Entity<PodKategorijeProizvoda>().HasData(

                new PodKategorijeProizvoda
                {
                    ID = 1,
                    Naziv = "Jela sa roštilja",
                    KategorijaProizvodaID = 1
                },
                new PodKategorijeProizvoda
                {
                    ID = 2,
                    KategorijaProizvodaID = 1,
                    Naziv = "Kuhana jela"
                },
                new PodKategorijeProizvoda
                {
                    ID = 3,
                    Naziv = "Hladna pića",
                    KategorijaProizvodaID = 2
                },
                new PodKategorijeProizvoda
                {
                    ID = 4,
                    KategorijaProizvodaID = 2,
                    Naziv = "Topla pića"
                }
                );

            modelBuilder.Entity<Skladiste>().HasData(
                new Skladiste
                {
                    SkladisteID=1,
                    NazivSkladista= "Glavno skladište"
                },
                new Skladiste
                {
                    SkladisteID = 2,
                    NazivSkladista = "Sporedno skladište"

                });

            modelBuilder.Entity<ProizvodDetalji>().HasData(
                new ProizvodDetalji
                {
                    ProizvodDetaljiID=1,
                    Opis= "Porcija od 10 cevapa uz prilog luka te kajmaka. Pored toga uz ovu prociju cete da dobijete cijeli somun.",
                    KolicinaNaSkladistu=48
                },
                new ProizvodDetalji
                {
                    ProizvodDetaljiID=2,
                    Opis= "U prociji kobasica cete da dobijete 400 grama mesa te kao prilog salatu.",
                    KolicinaNaSkladistu=30
                },
                new ProizvodDetalji
                {
                    ProizvodDetaljiID = 3,
                    Opis = "Uz ovu porciju cete da dobijete, cevape, kobasice, batake, pekarski krompir, filete. Uz to kao prilog ide umak te salta.",
                    KolicinaNaSkladistu = 20
                },
                new ProizvodDetalji
                {
                    ProizvodDetaljiID = 4,
                    Opis = "Uz ovu porciju cete da dobijete, cevape, kobasice, sis cevap, batake, filete. Kao prilog cete dobiti pomfrit te salatu.",
                    KolicinaNaSkladistu = 7
                },
                new ProizvodDetalji
                {
                    ProizvodDetaljiID = 5,
                    Opis = "U porciji cete da dobijete tanjir graha kuhanog na poseban nacin.",
                    KolicinaNaSkladistu = 46
                },
                new ProizvodDetalji
                {
                    ProizvodDetaljiID = 6,
                    Opis = "U ovoj porciji cete da dobijete telece kuhano meso sa kropmirom i povrcem.",
                    KolicinaNaSkladistu = 35
                },
                new ProizvodDetalji
                {
                    ProizvodDetaljiID = 7,
                    Opis = "U ovoj porciji cete da dobijete makarone sa mljevenim meso kuhanim na poseban nacin.",
                    KolicinaNaSkladistu = 51
                },
                new ProizvodDetalji
                {
                    ProizvodDetaljiID = 8,
                    Opis = "U ovoj porciji cete da dobijete spagete u posebnom sosu od paradajiza.",
                    KolicinaNaSkladistu = 50
                },
                new ProizvodDetalji
                {
                    ProizvodDetaljiID = 9,
                    Opis = "Fanta osvjezavajuce gazirano pice.",
                    KolicinaNaSkladistu = 86
                },
                new ProizvodDetalji
                {
                    ProizvodDetaljiID = 10,
                    Opis = "Coca cola osvjezavajuce gazirano pice.",
                    KolicinaNaSkladistu = 98
                },
                new ProizvodDetalji
                {
                    ProizvodDetaljiID = 11,
                    Opis = "Sprite osvjezavajuce gazirano pice.",
                    KolicinaNaSkladistu = 100
                },
                new ProizvodDetalji
                {
                    ProizvodDetaljiID = 12,
                    Opis = "Senzacija, osvjezavajuce gazirano pice.",
                    KolicinaNaSkladistu = 100
                },
                new ProizvodDetalji
                {
                    ProizvodDetaljiID = 13,
                    Opis = "Soljica kafe od brendiranih proizvodjaca.",
                    KolicinaNaSkladistu = 100
                },
                new ProizvodDetalji
                {
                    ProizvodDetaljiID = 14,
                    Opis = "Soljica posebno spremljene kafe uz poseban uzitak.",
                    KolicinaNaSkladistu = 100
                },
                new ProizvodDetalji
                {
                    ProizvodDetaljiID = 15,
                    Opis = "Posebno birane trave te kao prilog limun za potpuni uzitak.",
                    KolicinaNaSkladistu = 100
                },
                new ProizvodDetalji
                {
                    ProizvodDetaljiID = 16,
                    Opis = "Posebno ukuhana topla coklada uz dodatak slaga.",
                    KolicinaNaSkladistu = 100
                }
                );
            modelBuilder.Entity<Proizvod>().HasData(
                
                new Proizvod
                {
                    ProizvodID = 1,
                    Naziv = "Cevapi",
                    Cijena = 6,
                    Slika = File.ReadAllBytes("Files/cevapi.jpg"),
                    Količina = 300,
                    Aktivan = true,
                    JedinicaKolicineID = 1,
                    PodKategorijeProizvodaID=1,
                    SkladisteID=1,
                    ProizvodDetaljiID=1,
                    IstekRoka= new DateTime(2021,12,30),
                    NabavnaCijena=2
                },

                new Proizvod
                {
                    ProizvodID = 2,
                    Naziv = "Kobasice",
                    Cijena = 7,
                    Slika = File.ReadAllBytes("Files/kobasice.jpg"),
                    Količina = 400,
                    Aktivan = true,
                    JedinicaKolicineID = 1,
                    PodKategorijeProizvodaID = 1,
                    SkladisteID = 1,
                    ProizvodDetaljiID = 2,
                    IstekRoka = new DateTime(2021, 12, 30),
                    NabavnaCijena = 3
                },

                new Proizvod
                {
                    ProizvodID = 3,
                    Naziv = "Mala kombinacija",
                    Cijena = 9,
                    Slika = File.ReadAllBytes("Files/velikakombinacija.png"),
                    Količina = 600,
                    Aktivan = true,
                    JedinicaKolicineID = 1,
                    PodKategorijeProizvodaID = 1,
                    SkladisteID = 1,
                    ProizvodDetaljiID = 3,
                    IstekRoka = new DateTime(2021, 12, 30),
                    NabavnaCijena = 4
                },

                new Proizvod
                {
                    ProizvodID = 4,
                    Naziv = "Velika kombinacija",
                    Cijena = 15,
                    Slika = File.ReadAllBytes("Files/najvecemijesno.jpg"),
                    Količina = 800,
                    Aktivan = true,
                    JedinicaKolicineID = 1,
                    PodKategorijeProizvodaID = 1,
                    SkladisteID = 1,
                    ProizvodDetaljiID = 4,
                    IstekRoka = new DateTime(2021, 12, 30),
                    NabavnaCijena = 6
                },

                new Proizvod
                {
                    ProizvodID = 5,
                    Naziv = "Grah",
                    Cijena = 6,
                    Slika = File.ReadAllBytes("Files/grah.jpg"),
                    Količina = 300,
                    Aktivan = true,
                    JedinicaKolicineID = 1,
                    PodKategorijeProizvodaID = 2,
                    SkladisteID = 1,
                    ProizvodDetaljiID = 5,
                    IstekRoka = new DateTime(2021, 12, 30),
                    NabavnaCijena = 2
                },

                new Proizvod
                {
                    ProizvodID = 6,
                    Naziv = "Gulas",
                    Cijena = 6,
                    Slika = File.ReadAllBytes("Files/gulas.jpg"),
                    Količina = 300,
                    Aktivan = true,
                    JedinicaKolicineID = 1,
                    PodKategorijeProizvodaID = 2,
                    SkladisteID = 1,
                    ProizvodDetaljiID = 6,
                    IstekRoka = new DateTime(2021, 12, 30),
                    NabavnaCijena = 2
                },

                new Proizvod
                {
                    ProizvodID = 7,
                    Naziv = "Makaroni",
                    Cijena = 7,
                    Slika = File.ReadAllBytes("Files/makaronimljevenomeso.jpg"),
                    Količina = 300,
                    Aktivan = true,
                    JedinicaKolicineID = 1,
                    PodKategorijeProizvodaID = 2,
                    SkladisteID = 1,
                    ProizvodDetaljiID = 7,
                    IstekRoka = new DateTime(2021, 12, 30),
                    NabavnaCijena = 2
                },

                new Proizvod
                {
                    ProizvodID = 8,
                    Naziv = "Spagete",
                    Cijena = 7,
                    Slika = File.ReadAllBytes("Files/spagete.jpg"),
                    Količina = 300,
                    Aktivan = true,
                    JedinicaKolicineID = 1,
                    PodKategorijeProizvodaID = 2,
                    SkladisteID = 1,
                    ProizvodDetaljiID = 8,
                    IstekRoka = new DateTime(2021, 12, 30),
                    NabavnaCijena = 2
                },

                new Proizvod
                {
                    ProizvodID = 9,
                    Naziv = "Fanta",
                    Cijena = 2.5,
                    Slika = File.ReadAllBytes("Files/fanta.png"),
                    Količina = 0.33,
                    Aktivan = true,
                    JedinicaKolicineID = 2,
                    PodKategorijeProizvodaID = 3,
                    SkladisteID = 1,
                    ProizvodDetaljiID = 9,
                    IstekRoka = new DateTime(2021, 12, 30),
                    NabavnaCijena = 1
                },

                new Proizvod
                {
                    ProizvodID = 10,
                    Naziv = "Coca cola",
                    Cijena = 2.5,
                    Slika = File.ReadAllBytes("Files/cocacola.jpeg"),
                    Količina = 0.33,
                    Aktivan = true,
                    JedinicaKolicineID = 2,
                    PodKategorijeProizvodaID = 3,
                    SkladisteID = 1,
                    ProizvodDetaljiID = 10,
                    IstekRoka = new DateTime(2021, 12, 30),
                    NabavnaCijena = 1
                },

                new Proizvod
                {
                    ProizvodID = 11,
                    Naziv = "Sprite",
                    Cijena = 2.5,
                    Slika = File.ReadAllBytes("Files/sprite.jpg"),
                    Količina = 0.33,
                    Aktivan = true,
                    JedinicaKolicineID = 2,
                    PodKategorijeProizvodaID = 3,
                    SkladisteID = 1,
                    ProizvodDetaljiID = 11,
                    IstekRoka = new DateTime(2021, 12, 30),
                    NabavnaCijena = 1
                },

                new Proizvod
                {
                    ProizvodID = 12,
                    Naziv = "Senzacija",
                    Cijena = 2.5,
                    Slika = File.ReadAllBytes("Files/senzacija.jpg"),
                    Količina = 0.33,
                    Aktivan = true,
                    JedinicaKolicineID = 2,
                    PodKategorijeProizvodaID = 3,
                    SkladisteID = 1,
                    ProizvodDetaljiID = 12,
                    IstekRoka = new DateTime(2021, 12, 30),
                    NabavnaCijena = 1
                },

                new Proizvod
                {
                    ProizvodID = 13,
                    Naziv = "Kafa",
                    Cijena = 2.5,
                    Slika = File.ReadAllBytes("Files/kafa.jpg"),
                    Količina = 0.20,
                    Aktivan = true,
                    JedinicaKolicineID = 2,
                    PodKategorijeProizvodaID = 4,
                    SkladisteID = 1,
                    ProizvodDetaljiID = 13,
                    IstekRoka = new DateTime(2021, 12, 30),
                    NabavnaCijena = 1
                },

                new Proizvod
                {
                    ProizvodID = 14,
                    Naziv = "Kapucino",
                    Cijena = 2.5,
                    Slika = File.ReadAllBytes("Files/kapucino.jpg"),
                    Količina = 0.20,
                    Aktivan = true,
                    JedinicaKolicineID = 2,
                    PodKategorijeProizvodaID = 4,
                    SkladisteID = 1,
                    ProizvodDetaljiID = 14,
                    IstekRoka = new DateTime(2021, 12, 30),
                    NabavnaCijena = 1
                },

                new Proizvod
                {
                    ProizvodID = 15,
                    Naziv = "Caj",
                    Cijena = 2.5,
                    Slika = File.ReadAllBytes("Files/caj.jpg"),
                    Količina = 0.20,
                    Aktivan = true,
                    JedinicaKolicineID = 2,
                    PodKategorijeProizvodaID = 4,
                    SkladisteID = 1,
                    ProizvodDetaljiID = 15,
                    IstekRoka = new DateTime(2021, 12, 30),
                    NabavnaCijena = 1
                },

                new Proizvod
                {
                    ProizvodID = 16,
                    Naziv = "Topla cokolada",
                    Cijena = 2.5,
                    Slika = File.ReadAllBytes("Files/toplacokolada.jpg"),
                    Količina = 0.20,
                    Aktivan = true,
                    JedinicaKolicineID = 2,
                    PodKategorijeProizvodaID = 4,
                    SkladisteID = 1,
                    ProizvodDetaljiID = 16,
                    IstekRoka = new DateTime(2021, 12, 30),
                    NabavnaCijena = 1
                }
                );

            
            modelBuilder.Entity<StatusNarudzbe>().HasData(
            new StatusNarudzbe
            {
                StatusNarudzbeID=1,
                NazivStatusa= "Na čekanju"
            },
            new StatusNarudzbe
            {
                StatusNarudzbeID = 2,
                NazivStatusa = "U pripremi"
            },
            new StatusNarudzbe
            {
                StatusNarudzbeID = 3,
                NazivStatusa = "U isporuci"
            },
            new StatusNarudzbe { 
                StatusNarudzbeID = 4,
                NazivStatusa = "Završeno"
            }
            );

            modelBuilder.Entity<KorisnikOcjena>().HasData(
                new KorisnikOcjena
                {
                    ID=1,
                    KorisniciID=3,
                    ProizvodID=6,
                    Ocjena=5
                },
                new KorisnikOcjena
                {
                    ID = 2,
                    KorisniciID = 3,
                    ProizvodID = 7,
                    Ocjena = 3
                },
                new KorisnikOcjena
                {
                    ID = 3,
                    KorisniciID = 3,
                    ProizvodID = 9,
                    Ocjena = 5
                }
                );


            modelBuilder.Entity<MjestoPosluzivanja>().HasData(
                
                new MjestoPosluzivanja
                {
                    MjestoPosluzivanjaID=1,
                    BrojMjestaPosluzivanja=1,
                },
                new MjestoPosluzivanja
                {
                    MjestoPosluzivanjaID = 2,
                    BrojMjestaPosluzivanja = 2,
                },
                new MjestoPosluzivanja
                {
                    MjestoPosluzivanjaID = 3,
                    BrojMjestaPosluzivanja = 3,
                },
                new MjestoPosluzivanja
                {
                    MjestoPosluzivanjaID = 4,
                    BrojMjestaPosluzivanja = 4,
                },
                new MjestoPosluzivanja
                {
                    MjestoPosluzivanjaID = 5,
                    BrojMjestaPosluzivanja = 5,
                },
                new MjestoPosluzivanja
                {
                    MjestoPosluzivanjaID = 6,
                    BrojMjestaPosluzivanja = 6,
                },
                new MjestoPosluzivanja
                {
                    MjestoPosluzivanjaID = 7,
                    BrojMjestaPosluzivanja = 7,
                },
                new MjestoPosluzivanja
                {
                    MjestoPosluzivanjaID = 8,
                    BrojMjestaPosluzivanja = 8,
                },
                new MjestoPosluzivanja
                {
                    MjestoPosluzivanjaID = 9,
                    BrojMjestaPosluzivanja = 9,
                },
                new MjestoPosluzivanja
                {
                    MjestoPosluzivanjaID = 10,
                    BrojMjestaPosluzivanja = 10,
                }
                );
            modelBuilder.Entity<NarudzbaDetalji>().HasData(
                new NarudzbaDetalji
                {
                    NarudzbaDetaljiID=1,
                    Količina="3",
                    Cijena=15,
                    Placena=false
                },
                new NarudzbaDetalji
                {
                     NarudzbaDetaljiID = 2,
                     Količina = "3",
                     Cijena = 15,
                     Placena = true
                },
                new NarudzbaDetalji
                {
                    NarudzbaDetaljiID = 3,
                    Količina = "4",
                    Cijena = 34,
                    Placena = false
                },
                new NarudzbaDetalji
                {
                    NarudzbaDetaljiID = 4,
                    Količina = "4",
                    Cijena = 34,
                    Placena = false
                }
                );
            modelBuilder.Entity<Narudzba>().HasData(

                new Narudzba
                {
                    NarudzbaID=1,
                    NazivNarudzbe= "7_NovaNarudzba_3",
                    VrijemeKreiranjaNarudzbe= new DateTime(2021,6,20,22,43,36),
                    VrijemeOdgovoraNaNarudzbu=DateTime.Now,
                    StatusNarudzbeID=2,
                    NarudzbaDetaljiID=2,
                    MjestoPosluzivanjaID=7,
                    ImeNarucioca="Abedin Halilovic",
                    AdresaNarucioca= "3.Mart bb.",
                    BrojTelefonaNarucioca= "061602461",
                    Prihvacena=true,
                    PrihvacenaNotifikacija=true,
                    PromjenaStatusa=false
                },
                new Narudzba
                {
                    NarudzbaID = 2,
                    NazivNarudzbe = "7_NovaNarudzba_4",
                    VrijemeKreiranjaNarudzbe = new DateTime(2021, 6, 20, 22, 46, 3),
                    VrijemeOdgovoraNaNarudzbu = DateTime.Now,
                    StatusNarudzbeID = 1,
                    NarudzbaDetaljiID = 3,
                    MjestoPosluzivanjaID = 7,
                    ImeNarucioca = null,
                    AdresaNarucioca = null,
                    BrojTelefonaNarucioca = null,
                    Prihvacena = true,
                    PrihvacenaNotifikacija = false,
                    PromjenaStatusa = false
                },
                new Narudzba
                {
                    NarudzbaID = 3,
                    NazivNarudzbe = "7_NovaNarudzba_4",
                    VrijemeKreiranjaNarudzbe = new DateTime(2021, 6, 20, 22, 46, 44),
                    VrijemeOdgovoraNaNarudzbu = DateTime.Now,
                    StatusNarudzbeID = 3,
                    NarudzbaDetaljiID = 4,
                    MjestoPosluzivanjaID = 7,
                    ImeNarucioca = null,
                    AdresaNarucioca = null,
                    BrojTelefonaNarucioca = null,
                    Prihvacena = true,
                    PrihvacenaNotifikacija = true,
                    PromjenaStatusa = false
                }
                );
            modelBuilder.Entity<NarudzbaProizvod>().HasData(


               new NarudzbaProizvod
               {
                   NarudzbaProizvodID = 1,
                   NarudzbaID = 1,
                   ProizvodID = 7
               },
               new NarudzbaProizvod
               {
                    NarudzbaProizvodID=2,
                    NarudzbaID=2,
                    ProizvodID=7
               },
               new NarudzbaProizvod
               {
                   NarudzbaProizvodID=3,
                   NarudzbaID = 2,
                   ProizvodID = 5
               },
               new NarudzbaProizvod
               {
                   NarudzbaProizvodID = 4,
                   NarudzbaID = 2,
                   ProizvodID = 1
               },
               new NarudzbaProizvod
               {
                   NarudzbaProizvodID = 5,
                   NarudzbaID = 2,
                   ProizvodID = 9
               },
               new NarudzbaProizvod
               {
                   NarudzbaProizvodID = 6,
                   NarudzbaID = 3,
                   ProizvodID = 5
               },
               new NarudzbaProizvod
               {
                   NarudzbaProizvodID = 7,
                   NarudzbaID = 3,
                   ProizvodID = 7
               },
               new NarudzbaProizvod
               {
                   NarudzbaProizvodID = 8,
                   NarudzbaID = 3,
                   ProizvodID = 1
               },
               new NarudzbaProizvod
               {
                   NarudzbaProizvodID = 9,
                   NarudzbaID = 3,
                   ProizvodID = 9
               }
               );

            modelBuilder.Entity<KorisnikNarudzba>().HasData(
                
                new KorisnikNarudzba
                {
                    NarudzbaKorisnikID=1,
                    NarudzbaID=2,
                    KorisnikID=3
                },
                new KorisnikNarudzba
                {
                    NarudzbaKorisnikID = 2,
                    NarudzbaID = 3,
                    KorisnikID = 3
                }
                );
        }
    }
}
