using ProyectXAPI.Models.DTO;
using ProyectXAPI.Utils;

public abstract class Controller<CRUDDataType>
{
    private ResponseDTO _response;
    private CRUD<CRUDDataType> _dbSession;
    protected CRUD<CRUDDataType> DbSession
    {
        get
        {
            return _dbSession;
        }
    }
    protected ResponseDTO Response 
    { 
        get 
        {
            return _response; 
        } 
    }
    public Controller() 
    {
        _response = new ResponseDTO();
        _dbSession = new CRUD<CRUDDataType>();
    }
}