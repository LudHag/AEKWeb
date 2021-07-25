using System;

namespace AEKWeb.Data
{
    public class SignUp
    {
        public int Id { get; set; }
        public DateTime SignupDate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Instrument { get; set; }
        public string StartYear { get; set; }
    }
}
