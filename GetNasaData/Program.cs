using Common.BL;
using Common.Models;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GetNasaData
{
    class Program
    {
        private static readonly string Url = "https://ssd-api.jpl.nasa.gov/fireball.api";

        static async Task Main(string[] args)
        {
            log4net.Config.BasicConfigurator.Configure();
            ILog log = log4net.LogManager.GetLogger(typeof(Program));
            log.Info("Starting");

            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(Url);
                HttpContent content = response.Content;
                IFireballLogic fireballLogic = new FireballLogic();

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

                    await fireballLogic.Post(fireball);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error Fetching Data", ex);
            }
            log.Info("Closing Application");
        }
    }
}
