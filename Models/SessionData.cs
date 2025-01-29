namespace ProyectXAPI.Models
{
    public class SessionData
    {
        const int ProfileLength = 50;
        const int ProfileCreatorLength = 50;
        const int SessionLength = 10;

        private Profile _profile;
        private Session _session;
        private int _kills;
        private int _deaths;

        public Profile Profile
        {
            get
            {
                return _profile;
            }
            set
            {
                _profile = value;
            }
        }
        public Session Session
        {
            get
            {
                return _session;
            }
            set
            {
                _session = value;
            }
        }
        public int Kills
        {
            get
            {
                return _kills;
            }
            set
            {
                _kills = value;
            }
        }
        public int Deaths
        {
            get
            {
                return _deaths;
            }
            set
            {
                _deaths = value;
            }
        }
    }
}
