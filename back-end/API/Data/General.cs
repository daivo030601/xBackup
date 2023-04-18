using Microsoft.AspNetCore.Server.IISIntegration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace back_end.Data
{
    [Table("general")]
    public class General
    {
        public int Id { get; set; }
        public Boolean IsIncludeSrv { get; set; }
        public Boolean IsDirectConnection { get; set; }
        public string Host { get; set; }

        public int ServerId { get; set; }
        [JsonIgnore]
        public virtual Server Server { get; set; }

        public General()
        {
            ServerId = 0;
            IsIncludeSrv = false;
            IsDirectConnection = false;
            Host = null;
        }
    }
}
