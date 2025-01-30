using ProyectXAPI.Models;
using ProyectXAPI.Models.DTO;
using ProyectXAPI.Utils;

namespace ProyectXAPI.Controllers
{
    public class AcountController
    {
        private ResponseDTO _response;
        private CRUD<Acount> _dbSession;
        const string WrongLogin = "Incorrect login, check user and password";

        public AcountController()
        {
            _dbSession = new CRUD<Acount>();
            _response = new ResponseDTO();
        }

        /*public bool CheckLogin(Acount acount,out Acount searchedAcount)
        {
            
        }*/
    }
}
