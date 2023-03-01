using DataAccessCore.Context;
using DataAccessCore.Mapper;
using DTOCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessCore.Repositories
{
    public class RetRepos
    {

        
        public static Ret GetRet(int id)
        {
            using(RetContext context = new RetContext())
            {
                return RetMapper.Map(context.Rets.Find(id));
            }
        }

        public static void AddRet(Ret ret)
        {
            using (RetContext context = new RetContext())
            {
                context.Rets.Add(RetMapper.Map(ret));
                context.SaveChanges();
            }
        }
    }
}
