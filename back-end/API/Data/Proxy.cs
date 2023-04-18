using Microsoft.AspNetCore.Server.IISIntegration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace back_end.Data
{
    [Table("proxy")]
    public class Proxy
    {
        public int Id { get; set; }
        public Boolean IsWithPass { get; set; }
        public Boolean IsWithIdentityFile { get; set; }
        public Boolean IsSocks5 { get; set; }
        public string HostName { get; set; }
        public int Port { get; set; }
        public string SshUserName { get; set; }
        public string SshPassword { get; set; }

        public int ServerId { get; set; }
        [JsonIgnore]
        public virtual Server Server { get; set; }
        public virtual FileDetails IdentityFile { get; set; }

        public Proxy(int serverId)
        {
            ServerId = serverId;
            IsWithPass = false;
            IsWithIdentityFile = false;
            IsSocks5 = false;
            HostName = null;
            Port = 0;
            SshUserName = null;
            SshPassword = null;

        }

        public Proxy()
        {
            ServerId = 0;
            IsWithPass = false;
            IsWithIdentityFile = false;
            IsSocks5 = false;
            HostName = null;
            Port = 0;
            SshUserName = null;
            SshPassword = null;

        }
    }
}
