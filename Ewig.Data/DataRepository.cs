namespace Ewig.Data
{
    public class DataRepository
    {
        public static VoteData Vote {get;} = new VoteData();
        public static RestaurantData Restaurant {get;} = new RestaurantData();
        public static PlayerData Player {get;} = new PlayerData();
        public static SupperData Supper {get;} = new SupperData();
    }
}
