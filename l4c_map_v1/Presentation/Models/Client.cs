using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class Client
    {
       

        public string logo { get; set; }

        public int nbOfProjectActive { get; set; }

        public int nbOfRessource { get; set; }

        public int score { get; set; }


        public typeCategory typeCategory { get; set; }

       



        public int id { get; set; }



        public string LastName { get; set; }

    
        public string Name { get; set; }


  
        public string Picture { get; set; }




        public string Password { get; set; }



   
        public string role { get; set; }

    
        public string UserName { get; set; }






    }
 
    public enum typeCategory {
        Public,
        Private
    }
}