using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plane
{
    class Program
    {
        public static int[] maps = new int[100];
        static void Main(string[] args)
        {
            GameShow();
            InintMap();
            Console.ReadKey();
        }
        //初始化游戏头
        public static void GameShow()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("******************");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("******************");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("******************");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("***net飞行棋1.0***");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("******************");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("******************");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("******************");
        }
        //初始化地图
        public static void InintMap()
        {
            int[] luckyturn = { 6, 23, 40, 55, 69, 83 }; //幸运轮盘
            for (int i = 0; i < luckyturn.Length; i++)
            {
                int index = luckyturn[i];
                maps[index] = 1;

            }
            int[] landmine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 };//地雷
            for (int i = 0; i < landmine.Length; i++)
            {
                int index = landmine[i];
                maps[index] = 2;

            }
            int[] puse = { 9, 27, 63, 90 };//暂停
            for (int i = 0; i < puse.Length; i++)
            {
                int index = puse[i];
                maps[index] = 3;

            }
            int[] timetunnel = { 20, 25, 45, 63, 72, 88, 92 };//时空隧道
            for (int i = 0; i < timetunnel.Length; i++)
            {
                int index = timetunnel[i];
                maps[index] = 4;

            }

        }
        //画地图
        public static void DrawMap()
        {

        }

    }
}