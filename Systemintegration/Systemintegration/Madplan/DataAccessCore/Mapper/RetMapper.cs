using DataAccessCore.Model;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessCore.Mapper
{
    internal class RetMapper
    {
        public static DTOCore.Model.Ret Map(Ret ret)
        {
            return new DTOCore.Model.Ret(ret.Id,ret.Navn, ret.AntalMennesker);
        }

        public static Ret Map(DTOCore.Model.Ret ret)
        {
            return new Ret(ret.Id,ret.Navn, ret.AntalMennesker);
        }
    }
}
