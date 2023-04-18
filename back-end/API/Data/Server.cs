namespace back_end.Data
{
    public class Server
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Boolean IsUseAuthentication { get; set; }
        public Boolean IsUseProxy { get; set; }


        public virtual General General { get; set; }
        public virtual Authentication Authentication { get; set; }
        public virtual Proxy Proxy { get; set; }
    }
}
