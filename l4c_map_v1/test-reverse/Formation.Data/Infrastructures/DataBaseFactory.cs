using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formation.Data.Infrastructures
{
    public class DataBaseFactory : Disposable,IDataBaseFactory
    {

        private FormationContext datacontext;

        public FormationContext DataContext
        {
            get { return datacontext; }
            
        }

        public DataBaseFactory()
        {
            datacontext = new FormationContext();
        }

        public override void DisposeCore()
        {
            if (datacontext != null)
                datacontext.Dispose();
        }
    }
}
