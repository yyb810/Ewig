using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ewig.Data
{
    public class SupperData : EntityData<Supper>
    {
        /// <summary>
        /// 투표가 완료되었으면 레스토랑을 결정한다.
        /// </summary>
        public void PickRestaurant(DateTime date)
        {
            Supper supper = GetFirst(x => x.Date == date);

            int voteCount = DataRepository.Vote.GetCount(x => x.Date == date);

            if (supper.PlayerCount != voteCount)
                return;


            var votes = DataRepository.Vote.Get(x => x.Date == date);
            
            //var dict = new Dictionary<int, int>();
            //foreach (var vote in votes)
            //{
            //    if (dict.ContainsKey(vote.RestaurantId) == false)
            //        dict.Add(vote.RestaurantId, 0);

            //    dict[vote.RestaurantId] += 1;
            //}

            var dict = votes
                        .GroupBy(x => x.RestaurantId)
                        .ToDictionary(x => x.Key, x => x.Count());

            int restaurantId = dict.OrderByDescending(x => x.Value).First().Key;

            supper.RestaurantId = restaurantId;
            Update(supper);
        }

        public bool HasDecided(DateTime date)
        {
            return GetCount(x => x.Date == date && x.RestaurantId != null) > 0;
        }
    }
}
