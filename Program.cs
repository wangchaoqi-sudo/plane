using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plane
{
    class Program
    {
         static int[] maps = new int[100];
         static int[] playerpos = new int[2];
        static String[] player = new String[2];
        static void Main(string[] args)
        {
            GameShow();
            Console.WriteLine("请输入玩家A的姓名：");
            player[0] = Console.ReadLine();
            while (player[0] == "")
            {
                Console.WriteLine("玩家A的姓名不能为空,请重新输入：");
                player[0] = Console.ReadLine();

            }
            Console.WriteLine("请输入玩家B的姓名：");
            player[1] = Console.ReadLine();
            while (player[1] == "" || player[0]==player[1])
            {
                if(player[1] == "")
                {
                    Console.WriteLine("玩家B的姓名不能为空,请重新输入：");
                    player[1] = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("玩家A的姓名不能和玩家B相同,请重新输入：");
                    player[1] = Console.ReadLine();
                }
                  
            }
            Console.Clear();
            GameShow();
            Console.WriteLine("{0}的士兵用A表示", player[0]);
            Console.WriteLine("{0}的士兵用B表示", player[1]);
            InintMap();
            DrawMap();
            Console.WriteLine();
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
            Console.WriteLine("图例：幸运轮盘☆  地雷●  暂停▲  时空隧道※");
            //第一横行
            for(int i = 0; i < 30; i++)
            {
                Console.Write(drawstringmap(i));
            }
            Console.WriteLine();
            //第一竖行
            for(int i = 30; i < 35; i++)
            {
                for(int j = 0; j < 29; j++)
                {
                    Console.Write("  ");
              
                }
                Console.Write(drawstringmap(i));
                Console.WriteLine();
            }
  
            //第二横行
            for (int i = 64; i >=35; i--)
            {
                Console.Write(drawstringmap(i));
            }
            Console.WriteLine();
            //第二竖行
            for (int i = 65; i <70; i++)
            {
                Console.WriteLine(drawstringmap(i));
            }
            //第三横行
            for(int i = 70; i< 100; i++){
                Console.Write(drawstringmap(i));
            }
        }
        //底图符号
        public static String drawstringmap(int i)
        {
            String str = "";
            if (playerpos[0] == playerpos[1] && playerpos[1] == i)
            {
                str = "<>";
            }
            else if (playerpos[0] == i)
            {
                str = "A";
            }
            else if (playerpos[0] == i)
            {
                str = "B";
            }
            else
            {
                switch (maps[i])
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        str = "□";
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Red;
                        str = "☆";
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        str = "●";
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        str = "▲";
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        str = "※";
                        break;
                }
            }
            return str;
        }
        
    }
}