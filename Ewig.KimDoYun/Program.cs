using Ewig.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ewig.KimDoYun
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("몇 명의 선수가 참여하나요?");
            string input = Console.ReadLine();

            Supper supper = new Supper();
            supper.Date = DateTime.Today;
            supper.PlayerCount = int.Parse(input);

            try
            {
                DataRepository.Supper.Insert(supper);
                Console.WriteLine("투표가 시작되었습니다.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

                if (ex.InnerException != null)
                    Console.WriteLine(ex.InnerException.Message);
            }
        }
    }
}
