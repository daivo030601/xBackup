using back_end.Data;

namespace back_end.Models
{
    public class InputModel
    {
        public InputServerModel? inputServerModel { get; set; }
        public GeneralModel? GeneralModel { get; set; }
        public AuthenticationModel? AuthenticationModel { get; set; }
        public ProxyModel? ProxyModel { get; set; }
    }
}
