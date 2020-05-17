using System;
using System.ComponentModel.DataAnnotations;


namespace GigHub.Models
{
    public class Gig
    {
        public int Id { get; set; }
        // [Required] now is not needed on Application user
        public ApplicationUser Artist { get; set; }
        // string b/c it was defined as string in ApplicationUser class
        [Required]
        public string ArtistId { get; set; }
        public DateTime DateTime { get; set; }
        [Required]
        [StringLength(255)]
        public string Venue { get; set; }
        //[Required]
        public Genre Genre { get; set; }
        [Required]
        public byte GenreId { get; set; }
    }

    


}