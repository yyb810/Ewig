using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ewig.Data
{
    public class VoteData : EntityData<Vote>
    {
        public List<Vote> GetByDate(DateTime date)
        {
            using (var context = new EwigEntities())
            {
                var restaurantNames = context.Restaurants.ToDictionary(x => x.RestaurantId, x => x.Name);

                var votes = context.Votes.Where(x => x.Date == date);
                foreach (var vote in votes)
                {
                    vote.RestaurantName = restaurantNames[vote.RestaurantId];
                }

                return votes.ToList();
            }
        }
    }
}
