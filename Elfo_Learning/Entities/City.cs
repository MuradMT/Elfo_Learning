

using System.ComponentModel.DataAnnotations.Schema;

namespace Elfo_Learning.Entities
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
    }
}
