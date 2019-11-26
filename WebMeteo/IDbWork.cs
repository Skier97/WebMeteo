using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMeteo.Models;
using System.IO;
using Newtonsoft.Json;
using System.Web.Configuration;

namespace WebMeteo
{
    interface IDbWork
    {
        void UpdateDbTasks(List<City> cities);
        List<City> ReadCitiesFromFile();
    }
}
