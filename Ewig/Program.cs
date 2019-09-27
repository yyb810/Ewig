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
            Login();

            SelectRestaurant();
            
            while (true)
            {
                if (DataRepository.Supper.HasDone(DateTime.Today))
                    break;

                Thread.Sleep(1000);
                Console.Write(".");
            }

            ShowVotes();

            ShowWinner();
        }

        private static void Login()
        {
            Console.WriteLine("전화번호 끝자리 4개를 입력하시오");
        }

        private static void ShowWinner()
        {
            var supper = DataRepository.Supper.GetByPK(DateTime.Today);
            var restaurant = DataRepository.Restaurant.GetByPK(supper.RestaurantId.Value);

            Console.WriteLine($"The winner is {restaurant.Name}");
        }

        private static void ShowVotes()
        {
            var votes = DataRepository.Vote.GetByDate(DateTime.Today);

            int index = 1;
            foreach (var vote in votes)
            {
                Console.WriteLine($"[{index++}] {vote.RestaurantName}");
            }
        }

        private static void SelectRestaurant()
        {
            Console.WriteLine("선택하세요");        
            var list = DataRepository.Restaurant.GetAll();
            int index = 1;
            foreach (var item in list)
                Console.WriteLine($"[{index++}] {item.Name}");

            int selection = int.Parse(Console.ReadLine());
            var restaurant = list[selection - 1];

            DataRepository.Vote.Vote()
        }
    }
}
