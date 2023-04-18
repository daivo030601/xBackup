namespace back_end.Models
{
    public class ProxyModel
    {
        public int? Id { get; set; }
        public Boolean IsWithPass { get; set; }
        public Boolean IsWithIdentityFile { get; set; }
        public Boolean IsSocks5 { get; set; }
        public string? HostName { get; set; }
        public int Port { get; set; }
        public string? SshUserName { get; set; }
        public string? SshPassword { get; set; }
    }
}
