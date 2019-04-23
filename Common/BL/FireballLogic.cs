using Common.Data;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Common.BL
{
    public class FireballLogic
    {
        private NasaDbContext db = new NasaDbContext();

        public async Task<Fireball> Post(Fireball fireball)
        {
            db.Fireballs.Add(fireball);
            await db.SaveChangesAsync();

            var savedObject = await db.Fireballs.FindAsync(fireball.Id);
            return savedObject;
            
        }
    }
}