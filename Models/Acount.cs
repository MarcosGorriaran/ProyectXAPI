namespace ProyectXAPI.Models
{
    public class Acount
    {
        const int MaxUsernameLength = 50;
        const int MaxPasswordLength = 100;
        private string _username;
        private string _password;
        public string Username 
        {
            get 
            {
                return _username;
            }
            set 
            {
                if(value.Length > MaxUsernameLength)
                {
                    throw new Exception("Username is too long");
                }
                _username = value; 
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if(value.Length > MaxPasswordLength)
                {
                    throw new Exception("Password is too long");
                }
                _password = value;
            }
        }
    }
}
