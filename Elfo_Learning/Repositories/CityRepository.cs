using System.Linq.Expressions;
using Elfo_Learning.Context;
using Elfo_Learning.Entities;

namespace Elfo_Learning.Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(ElfoContext elfoContext) : base(elfoContext)
        {
        }
    }
}
