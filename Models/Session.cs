using Microsoft.AspNetCore.Http.HttpResults;

namespace ProyectXAPI.Models
{
    public class Session
    {
        const int MaxSessionIDLength = 10;
        
        private string _sessionID;
        private DateOnly _dateGame;
        public virtual string SessionID
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
        public virtual DateTime DateGame
        {
            get
            {
                return _dateGame.ToDateTime(new TimeOnly(0,0));
            }
            set
            {
                _dateGame = DateOnly.FromDateTime(value);
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Session))
            {
                return false;
            }
            Session other = (Session)obj;
            return other.SessionID == SessionID;
        }
    }
}
