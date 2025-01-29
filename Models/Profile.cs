namespace ProyectXAPI.Models
{
    public class Profile
    {
        const int ProfileNameLength = 50;
        private string _profileName;
        private Acount _creator;

        public string ProfileName
        {
            get
            {
                return _profileName;
            }
            set
            {
                if (value.Length > ProfileNameLength)
                {
                    throw new Exception("Profile name is too long");
                }
                _profileName = value;
            }
        }
        public Acount Creator
        {
            get
            {
                return _creator;
            }
            set
            {
                _creator = value;
            }
        }
    }
}
