namespace ProyectXAPI.Models
{
    public class Session
    {
        const int MaxSessionIDLength = 10;
        
        private string _sessionID;
        private DateOnly _dateGame;
        public string SessionID
        {
            get
            {
                return _sessionID;
            }
            set
            {
                if(value.Length > MaxSessionIDLength)
                {
                    throw new Exception("Session ID is too long");
                }
                _sessionID = value;
            }
        }
        public DateOnly DateGame
        {
            get
            {
                return _dateGame;
            }
            set
            {
                _dateGame = value;
            }
        }
    }
}
