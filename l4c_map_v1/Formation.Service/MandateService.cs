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
    public class MandateService :Service<mandate>,IMandateService
        {

        static IDataBaseFactory Factory = new DataBaseFactory();

        static IUnitOfWork utk = new UnitOfWork(Factory);
        public MandateService() : base(utk)
        {
        }
        public List<mandate> getMandates(int id)
        {
            return GetMany(e => e.ressource.id == id).ToList();
        }

        
    }
}
