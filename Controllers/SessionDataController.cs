using Microsoft.AspNetCore.Mvc;
using ProyectXAPI.Models;
using ProyectXAPI.Models.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectXAPI.Controllers
{
    public class SessionDataController : Controller<SessionData>
    {
        public SessionDataController() : base() { }
        [HttpPost("AddSessionData")]
        public ResponseDTO AddSessionData([FromBody] SessionData[] dataSet)
        {
            try
            {
                DbSession.InsertMany(dataSet);
            }
            catch (Exception ex)
            {
                Response.IsSuccess = false;
                Response.Message = ex.Message;
            }
            return Response;
        }
        [HttpGet("GetAllSessionData")]
        public ResponseDTO GetSessionData()
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
        [HttpGet("GetProfileSessionData")]
        public ResponseDTO GetSessionData(Profile profile)
        {
            try
            {
                Response.Data = DbSession.SelectAll().Where(obj=>obj.Profile.Equals(profile));
            }
            catch (Exception ex)
            {
                Response.IsSuccess = false;
                Response.Message = ex.Message;
            }
            return Response;
        }
        [HttpGet("GetSessionDataInfo")]
        public ResponseDTO GetSessionData(int sessionID)
        {
            try
            {
                Response.Data = DbSession.SelectAll().Where(obj => obj.Session.SessionID == sessionID);
            }
            catch (Exception ex)
            {
                Response.IsSuccess = false;
                Response.Message = ex.Message;
            }
            return Response;
        }
        [HttpGet("GetSessionData")]
        public ResponseDTO GetSessionData(Profile profile, int sessionID) 
        {
            try
            {
                Response.Data = DbSession.SelectAll().Where(obj => obj.Session.SessionID == sessionID && obj.Profile.Equals(profile)).First();
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
