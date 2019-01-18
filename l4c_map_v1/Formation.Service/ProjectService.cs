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
    public class ProjectService : Service<project>, IProjectService
    {

        static IDataBaseFactory Factory = new DataBaseFactory();

        static IUnitOfWork utk = new UnitOfWork(Factory);
        public ProjectService() : base(utk)
        {
        }
        public project getProject(int id)
        {
            return Get(e=>e.idProject==id);
        }
    }
}
