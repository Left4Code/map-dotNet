using Formation.Data.Infrastructures;
using Formation.Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formation.Service
{
    class ProducerService : Service<Producer>, IProducerService
    {
        static IDataBaseFactory Factory = new DataBaseFactory();

        static IUnitOfWork utk = new UnitOfWork(Factory);
        ProducerService() : base(utk)
        {

        }
    }
}
