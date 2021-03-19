using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Odev4.API.Data.Context;
using Odev4.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev4.API.Data
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                 serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (context.Albums.Any())
                {
                    return;
                }
                context.Albums.AddRange(
                    new Album
                    {
                        Id = 1,
                        Name = "Nerde Kalmıştık?",
                        Artist = "Cem Karaca",
                        SongCount = 11
                    },
                    new Album
                    {
                        Id = 2,
                        Name = "Fesuphanallah",
                        Artist = "Erkin Koray",
                        SongCount = 9
                    },
                    new Album
                    {
                        Id = 3,
                        Name = "Yeni Bir Gün",
                        Artist = "Barış Manço",
                        SongCount = 14
                    }
                    );

                context.Songs.AddRange(
                    new Song
                    {
                        Id = 1,
                        Name = "Raptiye Rap Rap!",
                        AlbumId = 1
                    },
                    new Song
                    {
                        Id = 2,
                        Name = "Islak Islak",
                        AlbumId = 1
                    },

                    new Song
                    {
                        Id = 3,
                        Name = "Sen Duymadın",
                        AlbumId = 1
                    },
                     new Song
                     {
                         Id = 4,
                         Name = "Bu Biçim",
                         AlbumId = 1
                     },
                     new Song
                     {
                         Id = 5,
                         Name = "Sende Başını Alıp Gitme",
                         AlbumId = 1
                     },
                     new Song
                     {
                         Id = 6,
                         Name = "Niyazi Köfteler",
                         AlbumId = 1
                     },
                     new Song
                     {
                         Id = 7,
                         Name = "Karabağ",
                         AlbumId = 1
                     },
                     new Song
                     {
                         Id = 8,
                         Name = "Herkes Gibisin",
                         AlbumId = 1
                     },
                     new Song
                     {
                         Id = 9,
                         Name = "Nöbetçinin Türküsü",
                         AlbumId = 1
                     },
                      new Song
                      {
                          Id = 10,
                          Name = "Ömrüm",
                          AlbumId = 1
                      },
                       new Song
                       {
                           Id = 11,
                           Name = "Suskunluk",
                           AlbumId = 1
                       }
                    );

                context.SaveChanges();
            }
        }
    }
}
