using System.Diagnostics;

namespace Ewig.Data
{
    public class DataRepository
    {
        static DataRepository()
        {
        }

        public static SupperData Supper {get;} = new SupperData();
        public static RestaurantData Restaurant {get;} = new RestaurantData();
        public static PlayerData Player {get;} = new PlayerData();
        public static VoteData Vote {get;} = new VoteData();

         public static EwigEntities Create()
        {
            EwigEntities context = new EwigEntities();
            context.Database.Log = (x) => Debug.WriteLine(x);
            return context;
        }
    }
}
