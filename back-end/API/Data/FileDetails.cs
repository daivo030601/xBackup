using Microsoft.VisualBasic.FileIO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_end.Data
{
    [Table("fileDetails")]
    public class FileDetails
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }

        public int ProxyId { get; set; }
        public virtual Proxy Proxy { get; set; }
    }
}
