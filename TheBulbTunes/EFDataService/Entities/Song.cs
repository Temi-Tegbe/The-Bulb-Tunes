using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBulbTunes.EFDataService.Entities
{
  public  class Song
    {
        [Required]
        public Guid SongId { get; set; }

        [Required, MaxLength(50)]
        public string Title { get; set; }

        [Required, MaxLength(50)]
        public string Artist { get; set; }

        [Required, MaxLength(100)]
        public string Album { get; set; }

        [MaxLength(150)]
        public string Featuring { get; set; }

        [MaxLength(50)]
        public string Genre { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        //Favourites referring to this song

        public List<Favourite> FavouritesList { get; set; }

    }
}
