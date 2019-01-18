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
    public class TestService : Service<profitability>, ITestService
    {
        static IDataBaseFactory Factory = new DataBaseFactory();

        static IUnitOfWork utk = new UnitOfWork(Factory);

        public TestService() : base(utk)
        {
        }
        public float getProf()
        {
            profitability p = new profitability();
            //GetMany(e => DateTime.Now == null).GroupBy(e=>e.project.adresse).Count()
            /*            var x = Factory.DataContext.mandates.GroupBy(e => e.project.adresse, e => e.ressource, (adress, resource) => new {
                            Key = adress,
                            count = resource.Count()
                        });
                        */
            //It only requires a condition where on the date ; dateTime.Now Between DateStart and DateEnd
          
            return Get(c => c.idProfitability == 1).gain;
            //Where(e => DateTime.Now == null).
            

        }

        public Dictionary<string ,int> nbByCountry()
        {
            var x = Factory.DataContext.mandates.ToList().Where(e=>DateTime.Now.CompareTo(e.dateBegin)>0 && DateTime.Now.CompareTo(e.dateEnd) < 0).GroupBy(e => e.project.adresse, e => e.ressource, (adress, resource) => new {
                Key = adress,
                count = resource.Distinct().Count()
            });
            return x.ToDictionary(e=>e.Key,e=>e.count);
        }
      
    }

}
