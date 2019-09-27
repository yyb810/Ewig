using Ewig.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ewig
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 로그인
            Player player = Login();

            if (player == null)
            {
                Console.WriteLine("그런 사람 없습니다.");
                return;
            }


            // 투표
            Vote(player);


            // 투표가 완료될 때 까지 대기
            while (true)
            {
                bool decided = DataRepository.Supper.HasDecided(DateTime.Today);

                if (decided)
                    break;

                Console.WriteLine(".");

                Thread.Sleep(2000);
            }


            // 결과 표시
            ShowResult();
        }

        private static void ShowResult()
        {
            Supper supper = DataRepository.Supper.GetFirst(x => x.Date == DateTime.Today);

            Restaurant restaurant = DataRepository.Restaurant.GetFirst(x => x.RestaurantId == supper.RestaurantId);

            Console.WriteLine($"오늘의 식당은 *{restaurant.Name}* 입니다.");
        }

        private static void Vote(Player player)
        {
            Console.WriteLine("식당을 선택하세요.");

            int index = 1;
            var restaurants = DataRepository.Restaurant.Get();
            foreach (var item in restaurants)
                Console.WriteLine($"[{index++}] {item.Name}");

            Console.WriteLine("-------------------");
            string input = Console.ReadLine();

            Restaurant restaurant = restaurants[int.Parse(input) -1];

            Vote vote = new Vote();
            vote.Date = DateTime.Today;
            vote.RestaurantId = restaurant.RestaurantId;
            vote.PlayerId = player.PlayerId;

            DataRepository.Vote.Insert(vote);

            DataRepository.Supper.PickRestaurant(DateTime.Today);
        }

        private static Player Login()
        {
            Console.WriteLine("전화번호를 입력하세요.");
            string input = Console.ReadLine();

            return DataRepository.Player.GetFirst(x => x.PlayerId == input);
        }
    }
}
