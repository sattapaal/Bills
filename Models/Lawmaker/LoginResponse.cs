namespace Lawmaker.Models
{
    public class LoginResponse
    {
        public string name { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string timeout { get; set; }
        public string token { get; set; }
    }
}