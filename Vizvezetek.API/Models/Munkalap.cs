using System.ComponentModel.DataAnnotations.Schema;

namespace Vizvezetek.API.Models
{
    [Table("munkalap")]
    public class Munkalap
    {
        public int Id { get; set; }

        [Column("beadas_datum")]
        public DateTime BeadasDatum { get; set; }

        [Column("javitas_datum")]
        public DateTime JavitasDatum { get; set; }


        [Column("hely_id")]
        public int HelyId { get; set; }


        [Column("szerelo_id")]
        public int SzereloId { get; set; }
        public int Munkaora { get; set; }
        public int Anyagar { get; set; }


        // Navigációs property
        public Hely Hely { get; set; }
        public Szerelo Szerelo { get; set; }

    }


}