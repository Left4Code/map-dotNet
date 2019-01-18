using Data.Infrastructures;
using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Pattern
{
    public class ServiceTest : Service<test>, IServiceTest
    {
        static IDataBaseFactory Factory = new DataBaseFactory();

        static IUnitOfWork utk = new UnitOfWork(Factory);
        public ServiceTest() : base(utk)
        {

        }
        public ICollection<test> getAllTest()
        {
            ICollection<test> tests = (ICollection<test>)GetMany(c => c.difficulty>0);
            return tests;
        }
    }
}
