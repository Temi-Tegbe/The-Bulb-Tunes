using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBulbTunes.EFDataService.Entities
{
  public  class Favourite
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid SelectedSongId { get; set; }


        [Required]
        public Guid AddedById { get; set; }

        [Required]
        public DataType DateAdded { get; set; }




        //THE FOLLOWING ARE NAVIGATION PROPERTIES MADE POSSIBLE FOREIGN KEY RELATIONSHIPS

        [Required]
        public virtual Song SelectedSong { get; set; }

        [Required]
        public virtual User AddedBy { get; set; }
    }
}
