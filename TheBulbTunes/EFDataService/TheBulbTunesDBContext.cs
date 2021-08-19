using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBulbTunes.EFDataService.Entities;

namespace TheBulbTunes.EFDataService
{
   public class TheBulbTunesDBContext : DbContext
    {

        string connectionString;

        //CONSTRUCTOR TO SET UP THE CONNECTION TO THE DB

        public TheBulbTunesDBContext()
        {
            connectionString = "Data Source=.;Initial Catalog=TheBulbTunes;Integrated Security=True;Pooling=False";
        }


        //DBSet PROPERTIES, ONE FOR EACH ENTITY/MODEL

        public DbSet<User> Users { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Favourite> Favourites { get; set; }

        //OnConfiguring METHOD


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(connectionString);
        }



        public void Configure(EntityTypeBuilder<Favourite> builder)
        {

            //SET ID AS PRIMARY KEY FOR FAVOURITE ENTITY

            builder.HasKey(f => f.Id);

            //A favourite must have one Song as selected song

            //Conversely, a song can appear multiple times as a Favourite

            builder.HasOne(f => f.SelectedSong)
                .WithMany(s => s.FavouritesList)
                .HasForeignKey(f => f.SelectedSongId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);


            //A favourite must have one User as AddedBy
            //Conversely, a User can have multiple Favourites

            builder.HasOne(f => f.AddedBy)
                .WithMany(u => u.FavouritesList)
                .HasForeignKey(f => f.AddedById)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
                }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            //SET UserID as the primary key for User entity
            builder.HasKey(u => u.UserId);
        }

    }
}
