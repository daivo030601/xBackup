namespace back_end.Models
{
    public class GeneralModel
    {
        public int? Id { get; set; }
        public Boolean IsIncludeSrv { get; set; }
        public Boolean IsDirectConnection { get; set; }
        public string? Host { get; set; }

    }
}
