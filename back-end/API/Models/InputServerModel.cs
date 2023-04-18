namespace back_end.Models
{
    public class InputServerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Boolean IsUseAuthentication { get; set; }
        public Boolean IsUseProxy { get; set; }
    }
}
