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
    }
}
