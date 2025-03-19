using System.ComponentModel.DataAnnotations.Schema;

namespace Vizvezetek.API.Models
{
    [Table("szerelo")]

    public class Szerelo
    {
        public int Id { get; set; }
        public string Nev { get; set; }


        // Navigációs property
        public ICollection<Munkalap> Munkalapok { get; set; }

    }


}