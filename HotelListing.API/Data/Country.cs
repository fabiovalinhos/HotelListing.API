using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.API.Data
{
    public class Country
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }
        public virtual IList <Hotel> Hotels { get; set; }
    }
}