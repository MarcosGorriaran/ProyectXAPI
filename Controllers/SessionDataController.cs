using Microsoft.AspNetCore.Mvc;
using ProyectXAPI.Models;
using ProyectXAPI.Models.DTO;
using System.Data;
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
                SessionData[] dataSet = DbSession.SelectAll().ToArray();
                foreach(SessionData data in dataSet)
                {
                    data.Profile.Creator.Password = string.Empty;
                }
                Response.Data = dataSet;
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
                SessionData[] dataSet = DbSession.SelectAll().Where(obj => obj.Profile.Equals(profile)).ToArray();
                foreach (SessionData data in dataSet)
                {
                    data.Profile.Creator.Password = string.Empty;
                }
                Response.Data = dataSet;
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
                SessionData[] dataSet = DbSession.SelectAll().Where(obj => obj.Session.SessionID == sessionID).ToArray();
                foreach (SessionData data in dataSet)
                {
                    data.Profile.Creator.Password = string.Empty;
                }
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
                SessionData data = DbSession.SelectAll().Where(obj => obj.Session.SessionID == sessionID && obj.Profile.Equals(profile)).First();
                data.Profile.Creator.Password = string.Empty;
                Response.Data = data;
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
