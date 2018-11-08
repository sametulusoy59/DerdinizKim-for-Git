using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DerdinizKimComWeb.Entities;

namespace DerdinizKimComWeb.DataAccessLayer.EntityFramework
{
    public class MyInitializer:CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            User admin = new User()
            {
                name = "Cagri",
                surname = "Ulusoy",
                email = "samet-ulusoy@hotmail.com",
                activate = Guid.NewGuid(),
                adminmi = true,
                aktifmi = true,
                username = "sametulusoy59",
                password = "123456",
                olusturulduguzaman = DateTime.Now,
                duzenlendigitarih = DateTime.Now.AddMinutes(5),
                duzenleyenkullanici = "sametulusoy59"

            };
            User admindegil = new User()
            {
                name = "Samet",
                surname = "Ulusoy",
                email = "sametulusoy@hotmail.com",
                activate = Guid.NewGuid(),
                adminmi = false,
                aktifmi = true,
                username = "Sulusoy59",
                password = "123456",
                olusturulduguzaman = DateTime.Now.AddHours(1),
                duzenlendigitarih = DateTime.Now.AddMinutes(65),
                duzenleyenkullanici = "sametulusoy59"

            };

            context.Kullanicilar.Add(admin);
            context.Kullanicilar.Add(admindegil);

            for(int a = 0; a < 8; a++)
            {
                User user = new User()
                {
                    name = FakeData.NameData.GetFirstName(),
                    surname = FakeData.NameData.GetSurname(),
                    email = FakeData.NetworkData.GetEmail(),
                    activate = Guid.NewGuid(),
                    adminmi = false,
                    aktifmi = true,
                    username = $"user{a}",
                    password = "123",
                    olusturulduguzaman = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    duzenlendigitarih = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    duzenleyenkullanici = $"user{a}"

                };
                context.Kullanicilar.Add(user);
            }


            context.SaveChanges();
            List<User> userlist = context.Kullanicilar.ToList();
            for (int i = 0; i < 10; i++)
            {
                Kategori kat = new Kategori()
                {
                    baslik = FakeData.PlaceData.GetStreetName(),
                    aciklama = FakeData.PlaceData.GetAddress(),
                    duzenlendigitarih = DateTime.Now,
                    olusturulduguzaman = DateTime.Now,
                    duzenleyenkullanici = "sametulusoy59"
                    
                };

                context.Kategoriler.Add(kat);
                for (int k = 0; k < FakeData.NumberData.GetNumber(5, 9); k++)
                {
                    User Sahip = userlist[FakeData.NumberData.GetNumber(0, userlist.Count - 1)];
                    Dert dert1 = new Dert()
                    {
                        baslik = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5, 25)),
                        dert = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        kategori = kat,
                        taslakmi = false,
                        begenisayisi = FakeData.NumberData.GetNumber(1, 9),
                        sahibi = Sahip,
                        olusturulduguzaman = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        duzenlendigitarih = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        duzenleyenkullanici = Sahip.username,
                    };
                    kat.Dertler.Add(dert1);
                    for (int j = 0; j < FakeData.NumberData.GetNumber(3, 5); j++)
                    {
                        User YorumSahibi = userlist[FakeData.NumberData.GetNumber(0, userlist.Count - 1)];
                        Yorum yorum = new Yorum()
                        {
                            yorum = FakeData.TextData.GetSentence(),
                            sahibi = YorumSahibi,
                            olusturulduguzaman = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            duzenlendigitarih = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            duzenleyenkullanici = YorumSahibi.username,

                        };
                        dert1.Yorumlar.Add(yorum);
                    }
                   
                    for (int c = 0; c < dert1.begenisayisi; c++)
                    {
                        begenilmils liked = new begenilmils()
                        {
                            user = userlist[c],

                        };
                        dert1.begenilmis.Add(liked);
                    
                    }
                    }
                }
            context.SaveChanges();
        }

        }

    }

