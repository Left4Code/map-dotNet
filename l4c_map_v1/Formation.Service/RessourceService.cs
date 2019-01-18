using Data.Infrastructures;
using Domain;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public  class RessourceService : Service<ressource>, IRessourceService
    {
        static IDataBaseFactory Factory = new DataBaseFactory();

        static IUnitOfWork utk = new UnitOfWork(Factory);

        public RessourceService() : base(utk)
        {
        }

        public List<ressource> getRessources()
        {
         
            return GetMany().ToList();
        }
    }
}
