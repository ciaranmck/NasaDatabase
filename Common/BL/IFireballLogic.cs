using System.Threading.Tasks;
using Common.Models;

namespace Common.BL
{
    public interface IFireballLogic
    {
        Task<Fireball> Post(Fireball fireball);
    }
}