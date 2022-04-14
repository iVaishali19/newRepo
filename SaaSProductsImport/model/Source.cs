using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaaSProductsImport.model
{
    public class Source
    {
        //This model is for future refrence if required to push dictionary data into db
        public Dictionary<Capterra,string> Capterra { get; set; }
        public List<SoftwareAdvice> SoftwareAdvice { get; set; }
      
    }
}
