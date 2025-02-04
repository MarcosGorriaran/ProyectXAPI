namespace ProyectXAPI.Models
{
    public class AcountChangePassword : Acount
    {
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
    }
}
