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
        public void PickRestaurant()
        {
            //TODO: 좀 있다 할 거임
            throw new NotImplementedException();
        }

        public bool HasDecided(DateTime date)
        {
            return GetCount(x => x.Date == date && x.RestaurantId != null) > 0;
        }
    }
}
