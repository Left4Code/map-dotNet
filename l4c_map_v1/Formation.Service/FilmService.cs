using Data.Infrastructures;
using Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class FilmService : Service<Film>, IFilmService
    {
        // Toutes les méthodes spécifiques autre que CRUD

        static IDataBaseFactory Factory = new DataBaseFactory();

        static IUnitOfWork utk = new UnitOfWork(Factory);
        public FilmService() : base(utk)
        {

        }




    }
}
