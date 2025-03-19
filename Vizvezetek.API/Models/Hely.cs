using System.ComponentModel.DataAnnotations.Schema;

namespace Vizvezetek.API.Models
{
    [Table("hely")]

    public class Hely
    {
        public int Id { get; set; }
        public string Telepules { get; set; }
        public string Utca { get; set; }


        // Navigációs property
        public ICollection<Munkalap> Munkalapok { get; set; }

    }

}
