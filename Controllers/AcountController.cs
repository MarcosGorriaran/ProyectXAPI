using ProyectXAPI.Models;
using ProyectXAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using ProyectXAPI.Utils;

namespace ProyectXAPI.Controllers
{
    public class AcountController : Controller<Acount>
    {
        public const string WrongLogin = "Incorrect login, check user and password";
        
        public AcountController() : base()
        {}

        public static bool CheckLogin(Acount acount)
        {
            CRUD<Acount> acountDB = new CRUD<Acount>();
            Acount searchedAcount = acountDB.SelectById(acount.Username);
            return (searchedAcount.Password == acount.Password);
        }
        private bool CheckLogin(Acount acount,out Acount searchedAcount)
        {
            searchedAcount = DbSession.SelectById(acount.Username);
            return (searchedAcount.Password == acount.Password);
        }
        [HttpPost("CheckLogin")]
        public ResponseDTO RequestLogin([FromBody] Acount acount)
        {
            try
            {
                Response.IsSuccess = CheckLogin(acount, out _);
                if (Response.IsSuccess)
                {
                    Response.Data = acount;
                }
                else
                {
                    Response.Message = WrongLogin;
                }
            }catch(NullReferenceException ex)
            {
                Response.Message = WrongLogin;
                Response.IsSuccess = false;
            }
            catch(Exception ex)
            {
                Response.Message = ex.Message;
                Response.IsSuccess = false;
            }
            return Response;
        }
        [HttpPost("AddAcount")]
        public ResponseDTO AddAcount(Acount acount)
        {
            try
            {
                DbSession.Insert(acount);
            }catch(Exception ex)
            {
                Response.IsSuccess = false;
                Response.Message = ex.Message;
            }
            return Response;
        }
        [HttpPost("GetAcountProfiles")]
        public ResponseDTO GetAcountProfiles(Acount acount)
        {
            try
            {
                if(CheckLogin(acount,out _))
                {
                    CRUD<Profile> profileDB = new CRUD<Profile>();
                    Profile[] profiles = profileDB.SelectAll()
                        .Where((prof) =>
                        {
                            try
                            {
                                return prof.Creator.Username == acount.Username;
                            }
                            catch (Exception ex)
                            {
                                return false;
                            }
                        }).ToArray();

                    Response.Data = profiles;
                }
                else
                {
                    Response.IsSuccess = false;
                    Response.Message = WrongLogin;
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
