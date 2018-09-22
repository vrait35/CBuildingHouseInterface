using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Classes
{
    public interface IWorker
    {
        void Work(House h);
    }

    public  class BasePart
    {
        public  bool isReady;
        public string Name { get; set; }
        public BasePart()
        {
            Name = GetType().Name;
        }
    }
    public class Basement : BasePart,IPart
    {
        public Basement():base()
        {
            isReady = false;            
        }
        public void Building()
        {
            isReady = true;
        }
    }
    public class Wall : BasePart, IPart
    {
        public Wall() : base()
        {
            isReady = false;
        }
        public void Building()
        {
            isReady = true;
        }
    }

    public class Window : BasePart, IPart
    {
        public Window() : base()
        {
            isReady = false;
        }
        public void Building()
        {
            isReady = true;
        }
    }

    public class Door : BasePart, IPart
    {
        public Door() : base()
        {
            isReady = false;
        }
        public void Building()
        {
            isReady = true;
        }
    }

    public class Roof : BasePart, IPart
    {
        public Roof() : base()
        {
            isReady = false;
        }
        public void Building()
        {
            isReady = true;
        }
    }

    public partial class House : BasePart, IPart
    {
        public Basement Basement { get; set; }        
        public Roof Roof { get; set; }       

        public Window[] Window { get; set; }
        public Window this[int index]
        {
            get
            {
                return Window[index];
            }
            set
            {
                Window[index] = value;
            }
        }

        public Wall[] Wall { get; set; }
        public Door[] Door { get; set; }

        public House() : base()
        {
            isReady = false;
            Wall = null;
            Door = null;
            Window = null;
            Roof = new Roof();
            Basement = new Basement();
        }
        public void Building()
        {
            isReady = true;
        }
        public House(int wall,int door,int window) : base()
        {
            Roof = new Roof();
            Basement = new Basement();
            Wall = new Wall[wall];
            for (int i = 0; i < wall; i++)
                Wall[i] = new Wall();
            Door = new Door[door];
            for (int i = 0; i < door; i++)
                Door[i] = new Door();
            Window = new Window[window];
            for (int i = 0; i < window; i++)
                Window[i] = new Window();
        }
    }

    public class Worker : IWorker
    {        
        public void Work(House house)
        {
            int wallCount = house.Wall.Length;
            int windowCount = house.Window.Length;
            int doorCount = house.Door.Length;
            if (house.Basement.isReady == false)
            {
                house.Basement.isReady = true;
                return;
            }
            else if (house.Wall[wallCount - 1].isReady == false)
            {
                for (int i = 0; i < wallCount; i++)
                    house.Wall[i].isReady = true;                
                return;
            }
            else if (house.Window[windowCount - 1].isReady == false)
            {
                for (int i = 0; i < windowCount; i++)
                    house.Window[i].isReady = true;
                
                return;
            }
            else if (house.Door[doorCount - 1].isReady == false)
            {
                for (int i = 0; i < doorCount; i++)
                    house.Door[i].isReady = true;                
                return;
            }
            else if (!house.Roof.isReady)
            {
                house.Roof.isReady = true;
                return;
            }

        }
    }
    public class Team : Worker
    {
        public Worker[] Worker { get; set; }
        public Worker this[int index]
        {
            get
            {
                return Worker[index];
            }
            set
            {
                Worker[index] = value;
            }
        }
        public Team(int count)
        {
            Worker = new Worker[count];
            for (int i = 0; i < count; i++)
                Worker[i] = new Worker();
        }
    }


    public class TeamLeader
    {
        public BasePart[] Work(House house)
        {
            int wallCount = house.Wall.Length;
            int windowCount = house.Window.Length;
            int doorCount = house.Door.Length;
            int countPart = 5;
            BasePart[] basePart = new BasePart[countPart];
            int index = 0;
            for (int i = 0; i < countPart; i++)
            {
                basePart[i] = new BasePart();
            }
            if (house.Basement.isReady)
            {
                basePart[index].Name = house.Basement.Name;
                basePart[index].isReady = true;
                index++;
            }
            if (house.Wall[wallCount - 1].isReady)
            {
                basePart[index].Name = house.Wall[wallCount - 1].Name;
                basePart[index].isReady = true; index++;
            }
            if (house.Window[windowCount - 1].isReady)
            {
                basePart[index].Name = house.Window[windowCount - 1].Name;
                basePart[index].isReady = true; index++;
            }
            if (house.Door[doorCount - 1].isReady)
            {
                basePart[index].Name = house.Door[doorCount - 1].Name;
                basePart[index].isReady = true; index++;
            }
           if (house.Roof.isReady)
            {
                basePart[index].Name = house.Roof.Name;
                basePart[index].isReady = true; index++;
            }
            if (basePart[basePart.Length - 1].isReady) house.isReady = true;
            return basePart;
        }



        public static void Result(BasePart[] basePart,int windowCount,int doorCount)
        {
            
            if (!basePart[0].isReady) return;
            for(int i = 0; i<basePart.Length; i++)
            {
                if (basePart[i].Name == "Basement")
                {
                    for(int x = 1, y = 9; x < 5; x++)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write("f");
                    }                   
                }
                 if (basePart[i].Name == "Wall")
                {
                    
                    for (int x = 1, y = 4; y < 9; y++)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write("i");
                    }
                    for (int x=4, y = 4; y < 9; y++)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write("i");
                    }                  
                }
               if (basePart[i].Name == "Window")
                {
                    int q = 0;
                    for(int x = 2, y = 4; y < 8 && q<windowCount; y++,q++)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write("o");
                    }
                    for (int x = 3, y = 4; y < 8 && q < windowCount; y++, q++)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write("o");
                    }
                }
               if (basePart[i].Name == "Door")
                {
                    int x = 3,y = 8;
                    Console.SetCursorPosition(x, y);
                    Console.Write("П");
                }
               if (basePart[i].Name == "Roof")
                {
                    for (int x = 1, y = 3; x < 5; x++)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write("*");
                    }
                    for(int x = 2, y = 2; x < 4; x++)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write("*");
                    }
                    Console.SetCursorPosition(3, 1);
                    Console.Write("*");

                }
            }
        }


    }    
}
