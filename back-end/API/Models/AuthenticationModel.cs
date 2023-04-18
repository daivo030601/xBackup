namespace back_end.Models
{
    public class AuthenticationModel
    {
        public int? Id { get; set; }
        public Boolean IsDefault { get; set; }
        public Boolean IsSHA1 { get; set; }
        public Boolean IsSHA256 { get; set; }
        public String? Username { get; set; }
        public String? Password { get; set; }
        public String? AuthDatabase { get; set; }
    }
}
