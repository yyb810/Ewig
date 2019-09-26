using System.Linq;

namespace Ewig.Data
{
    public class RestaurantData : EntityData<Restaurant>
    {
        public Restaurant GetByPK(int restaurantId)
        {
            using (EwigEntities context = new EwigEntities())
            {
                return context.Restaurants.FirstOrDefault(x => x.RestaurantId == restaurantId);
            }
        }
    }
}
