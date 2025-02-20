using ProyectXAPI.Models;
using ProyectXAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using ProyectXAPI.Utils;
using BCrypt.Net;

namespace ProyectXAPI.Controllers
{
    public class AcountController : Controller<Acount>
    {
        public const string WrongLogin = "Incorrect login, check user and password";
        const string WrongPassword = "The new password can't be the same as the old password";
        const string RepeatedUsername = "There is an acount with the same username";

        public AcountController() : base()
        { }

        public static bool CheckLogin(Acount acount)
        {
            try
            {
                CRUD<Acount> acountDB = new CRUD<Acount>();
                Acount searchedAcount = acountDB.SelectById(acount.Username);
                return BCrypt.Net.BCrypt.EnhancedVerify(acount.Password, searchedAcount.Password);
            }
            catch(NullReferenceException)
            {
                throw new Exception(WrongLogin);
            }
            
        }
        private bool CheckLogin(Acount acount, out Acount searchedAcount)
        {
            try
            {
                searchedAcount = DbSession.SelectById(acount.Username);
                return BCrypt.Net.BCrypt.EnhancedVerify(acount.Password, searchedAcount.Password);
            }
            catch (NullReferenceException)
            {
                throw new Exception(WrongLogin);
            }
            
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
            } catch (NullReferenceException)
            {
                Response.Message = WrongLogin;
                Response.IsSuccess = false;
            }
            catch (Exception ex)
            {
                Response.Message = ex.Message;
                Response.IsSuccess = false;
            }
            return Response;
        }
        [HttpPost("AddAcount")]
        public ResponseDTO AddAcount([FromBody]Acount acount)
        {
            try
            {
                if (DbSession.SelectById(acount.Username) != null) throw new Exception(RepeatedUsername);
                acount.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(acount.Password);
                DbSession.Insert(acount);
            } catch (Exception ex)
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
                if (CheckLogin(acount, out _))
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
            } catch (Exception ex)
            {
                Response.IsSuccess = false;
                Response.Message = ex.Message;
            }
            return Response;
        }
        [HttpDelete("DeleteAcount")]
        public ResponseDTO DeleteAcount(Acount acount)
        {
            try
            {
                if (CheckLogin(acount, out Acount hibernatedAcount))
                {
                    DbSession.Delete(hibernatedAcount);
                }
                else
                {
                    Response.IsSuccess = false;
                    Response.Message = WrongLogin;
                }
            }
            catch (Exception ex)
            {
                Response.IsSuccess = false;
                Response.Message = ex.Message;
            }

            return Response;
        }
        [HttpPut("UpdatePassword")]
        public ResponseDTO UpdateAcount([FromBody] ChangePassword changePassword)
        {
            try
            {
                if (CheckLogin(changePassword, out Acount hibernatedAcount))
                {
                    hibernatedAcount.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(changePassword.NewPassword);
                    DbSession.Update(hibernatedAcount);
                }
                else
                {
                    Response.IsSuccess = false;
                    Response.Message = WrongLogin;
                }
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
