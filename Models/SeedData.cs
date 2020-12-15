using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Music.Data;
using System;
using System.Linq;

namespace Music.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SongContext1Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SongContext1Context>>()))
            {
                // Look for any movies.
                if (context.Songs.Any())
                {
                    return;   // DB has been seeded
                }

                context.Songs.AddRange(
                    new Song
                    {
                        Title = "Test1",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Hip Hop",
                    },

                    new Song
                    {
                        Title = "Test2",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Hip Hop",
                    
                    },

                    new Song
                    {
                        Title = "Test3",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Hip Hop",
                        //Artist = "TestArtist"
                    },

                    new Song
                    {
                        Title = "Test4",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Hip Hop",
                        //Artist = "TestArtist"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
