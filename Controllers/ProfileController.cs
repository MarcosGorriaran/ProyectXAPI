using Microsoft.AspNetCore.Mvc;
using ProyectXAPI.Models;
using ProyectXAPI.Models.DTO;

namespace ProyectXAPI.Controllers
{
    public class ProfileController : Controller<Profile>
    {
        public ProfileController() : base() { }

        [HttpPost("AddProfile")]
        public ResponseDTO AddProfile([FromBody] Profile profile)
        {
            try
            {
                if (AcountController.CheckLogin(profile.Creator))
                {
                    DbSession.Insert(profile);
                }
                else
                {
                    Response.IsSuccess = false;
                    Response.Message = AcountController.WrongLogin;
                }
            }
            catch(Exception ex)
            {
                Response.IsSuccess = false;
                Response.Message = ex.Message;
            }
            return Response;
        }

        [HttpPost("UpdateProfile")]
        public ResponseDTO UpdateProfile([FromBody] Profile profile)
        {
            try
            {
                if (AcountController.CheckLogin(profile.Creator))
                {
                    DbSession.Update(profile);
                }
                else
                {
                    Response.IsSuccess = false;
                    Response.Message = AcountController.WrongLogin;
                }
                
            }
            catch (Exception ex)
            {
                Response.IsSuccess = false;
                Response.Message = ex.Message;
            }
            return Response;
        }
        [HttpPost("DeleteProfile")]
        public ResponseDTO DeleteProfile([FromBody] Profile profile)
        {
            try
            {
                if (AcountController.CheckLogin(profile.Creator))
                {
                    DbSession.Delete(profile);
                }
                else
                {
                    Response.IsSuccess = false;
                    Response.Message = AcountController.WrongLogin;
                }
            }catch(Exception ex)
            {
                Response.IsSuccess = false;
                Response.Message = ex.Message;
            }
            return Response;
        }
    }
}
