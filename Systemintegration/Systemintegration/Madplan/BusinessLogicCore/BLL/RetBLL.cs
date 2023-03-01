using DataAccessCore.Repositories;
using DTOCore.Model;

namespace BusinessLogicCore.BLL
{
    public class RetBLL
    {
        public Ret GetRet(int id)
        {
            return RetRepos.GetRet(id);
        }
    }
}