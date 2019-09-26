using Ewig.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ewig.Admin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("오늘의 선수는 몇 명입니까?");
            string input = Console.ReadLine();

            int count = int.Parse(input);

            DataRepository.Supper.Open(DateTime.Today, count);
        }
    }
}
