using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebMeteo.Models;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Web.Configuration;

namespace WebMeteo.Controllers
{
    
    public class CityController : ApiController
    {
        List<City> cities;        

        // GET api/values
        public IHttpActionResult Get()
        {
            cities = ReadCitiesFromFile();
            UpdateDbTasks();
            return Json (cities);
        }

        // GET api/values/5
        public IHttpActionResult Get(string name)
        {
            cities = ReadCitiesFromFile();
            City tmpCity = null;
            for (int i = 0; i < cities.Count; i++)
            {
                if (cities[i].NameCity.ToLower() == name.ToLower())
                {
                    tmpCity = cities[i];
                    
                }
            }
            return Json(tmpCity);
        }

        // POST api/values
        [HttpPost]
        public void AddCity(City city)
        {
            cities = ReadCitiesFromFile();
            cities.Add(city);
            UpdateDbTasks();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        //в контролере не должно быть логики, только эндПоинты. А лучше сделать интерфейс DbContext, от него унаследовать FileDB  
        private void UpdateDbTasks()
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
