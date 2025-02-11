using Microsoft.AspNetCore.Mvc;
using ProyectXAPI.Models;
using ProyectXAPI.Models.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectXAPI.Controllers
{
    public class SessionController : Controller<Session>
    {
        public SessionController() : base() { }

        [HttpGet("GetSessions")]
        public ResponseDTO GetSessions() 
        {
            try
            {
                Response.Data = DbSession.SelectAll();
            }
            catch (Exception ex)
            {
                Response.IsSuccess = false;
                Response.Message = ex.Message;
            }
            return Response; 
        }
        [HttpGet("GetSession")]
        public ResponseDTO GetSession(int sessionId)
        {
            try
            {
                Response.Data = DbSession.SelectById(sessionId);
            }
            catch (Exception ex)
            {
                Response.IsSuccess = false;
                Response.Message = ex.Message;
            }
            return Response;
        }
        [HttpPost("AddSession")]
        public ResponseDTO PostSession([FromBody]Session session)
        {
            try
            {
                int? id;
                id = DbSession.SelectAll().Max(obj => obj.SessionID) + 1;
                if (!id.HasValue) id = 0;
                if(!session.DateGame.HasValue) session.DateGame = DateTime.Now;

                session.SessionID = id;
                DbSession.Insert(session);
                Response.Data = DbSession.SelectById(id);
            }
            catch (Exception ex)
            {
                Response.IsSuccess = false;
                Response.Message = ex.Message;
            }
            return Response;
        }
    }
}
