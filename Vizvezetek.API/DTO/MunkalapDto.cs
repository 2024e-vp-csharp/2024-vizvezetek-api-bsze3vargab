namespace Vizvezetek.API.DTOs
{
    public class MunkalapDto
    {
        public int Id { get; set; }
        public DateTime BeadasDatum { get; set; }
        public DateTime JavitasDatum { get; set; }
        public string Helyszin { get; set; }
        public string Szerelo { get; set; }
        public int Munkaora { get; set; }
        public int Anyagar { get; set; }

    }


}