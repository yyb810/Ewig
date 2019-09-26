using System;
using System.Linq;

namespace Ewig.Data
{
    public class SupperData : EntityData<Supper>
    {
        public Supper GetByPK(DateTime date)
        {
            using (EwigEntities context = new EwigEntities())
            {
                return context.Suppers.FirstOrDefault(x => x.Date == date);
            }
        }

        public void Open(DateTime date, int playerCount)
        {
            Supper supper = new Supper();
            supper.Date = date;
            supper.PlayerCount = playerCount;

            Insert(supper);
        }

        public bool HasDone(DateTime date)
        {
            Supper supper = GetByPK(date);

            int voteCount = DataRepository.Vote.GetCountByDate(date);

            return supper.PlayerCount == voteCount;
        }
    }
}
