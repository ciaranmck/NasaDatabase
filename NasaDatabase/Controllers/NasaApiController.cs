using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using NasaDatabase.Models;
using Newtonsoft.Json;

namespace NasaDatabase.Controllers
{
    public class NasaController : ApiController
    {
        //var BLCLass bl = new BLClass();

        [Route("nasaDatabase/allFireballData")]
        [HttpGet]
        public async Task Get()
        {
            //bool success = BLCLass.getNASA();
            //if success
            //    return 200
            //        else return 500;

            string Url = "https://ssd-api.jpl.nasa.gov/fireball.api";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(Url);
            HttpContent content = response.Content;

            FireballsController fireballsController = new FireballsController();


                string result = await content.ReadAsStringAsync();

                var fireballData = JsonConvert.DeserializeObject<NasaFireballData>(result);

                for (var i = 0; i < fireballData.Data.Length; i++)
                {
                    var fireball = new Fireball();

                    fireball.Date = Convert.ToDateTime(fireballData.Data[i][0]);
                    fireball.Energy = Convert.ToDecimal(fireballData.Data[i][1]);
                    fireball.ImpactE = Convert.ToDecimal(fireballData.Data[i][2]);
                    fireball.Lat = Convert.ToDecimal(fireballData.Data[i][3]);
                    fireball.LatDir = fireballData.Data[i][4];
                    fireball.Lon = Convert.ToDecimal(fireballData.Data[i][5]);
                    fireball.LonDir = fireballData.Data[i][6];
                    fireball.Alt = Convert.ToDecimal(fireballData.Data[i][7]);
                    fireball.Vel = Convert.ToDecimal(fireballData.Data[i][8]);

                    await fireballsController.PostFireball(fireball);
                }
        }
    }
}