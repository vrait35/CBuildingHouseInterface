using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace BuildHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Запомните!");
            Console.WriteLine("нажимайте ENTER клавишу для продолжения");
            Console.WriteLine("ESC для выхода с программы");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("f-фундамент");
            Console.WriteLine("i-стена");
            Console.WriteLine("o-окно");
            Console.WriteLine("П-дверь");
            Console.WriteLine("*-крыша");
            Console.WriteLine("нажимайте ENTER клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();
            int windowCount = 5 ; //можно изменить до 8, изменится картинка
            int wallCount = 4;    
            int doorCount = 1;    
            int workerCount = 5;
            House house = new House(wallCount, doorCount, windowCount);
            Team team = new Team(workerCount);
            TeamLeader teamLeader = new TeamLeader();
            BasePart[] basePart = teamLeader.Work(house);
            while (true)
            {
                basePart= teamLeader.Work(house);
                TeamLeader.Result(basePart, windowCount, doorCount);
                team.Work(house);                           
                Console.ReadKey();             
                if (basePart[basePart.Length - 1].isReady) break;
            }         
            Console.ReadKey();
        }
    }
}
