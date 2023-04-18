using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace back_end.Data
{
    [Table("authentication")]
    public class Authentication
    {
        public int Id { get; set; }
        public bool IsDefault { get; set; }
        public bool IsSHA1 { get; set; }
        public bool IsSHA256 { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AuthDatabase { get; set; }

        public int ServerId { get; set; }
        [JsonIgnore]
        public virtual Server Server { get; set; }

        public Authentication(int serverId)
        {
            ServerId = serverId;
            IsDefault = false;
            IsSHA1 = false;
            IsSHA256 = false;
            Username = null;
            Password = null;
            AuthDatabase = null;

        }

        public Authentication()
        {
            ServerId = 0;
            IsDefault = false;
            IsSHA1 = false;
            IsSHA256 = false;
            Username = null;
            Password = null;
            AuthDatabase = null;

        }
    }
}
