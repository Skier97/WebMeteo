using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMeteo.Models;
using System.IO;
using Newtonsoft.Json;
using System.Web.Configuration;

namespace WebMeteo
{
    public class FileDb:IDbWork
    {
        public void UpdateDbTasks(List<City> cities)
        {
            string jsonTasks = JsonConvert.SerializeObject(cities);
            using (StreamWriter sw = new StreamWriter(WebConfigurationManager.AppSettings["WayToDB"], false))
            {
                sw.WriteLine(jsonTasks);
            }
        }

        public List<City> ReadCitiesFromFile()
        {
            var colCities = new List<City>();
            using (var sr = new StreamReader(WebConfigurationManager.AppSettings["WayToDB"]))
            {
                string line = sr.ReadLine();

                colCities = JsonConvert.DeserializeObject<List<City>>(line);
            }
            return colCities;
        }
    }
}