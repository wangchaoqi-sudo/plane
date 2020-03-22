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
         static int[] playerpos = new int[2];//玩家位置
        static String[] player = new String[2];
        //两个玩家的标记
        static bool[] Flags = new bool[2];
        static void Main(string[] args)
        {
            GameShow();
            Console.WriteLine("请输入玩家A的姓名: ");
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

            //当玩家A跟玩家B没有一个人在终点的时候 两个玩家不停的去玩游戏
            while (playerpos[0] < 99 && playerpos[1] < 99)
            {
                if (Flags[0] == false)
                {
                    PlayGame(0);//Flags[0]=true;
                }
                else
                {
                    Flags[0] = false;
                }

                if (playerpos[0] >= 99)
                {
                    Console.WriteLine("玩家{0}无耻的赢了玩家{1}", player[0], player[1]);
                    break;
                }

                if (Flags[1] == false)
                {
                    PlayGame(1);
                }
                else
                {
                    Flags[1] = false;
                }
                if (playerpos[1] >= 99)
                {
                    Console.WriteLine("玩家{0}无耻的赢了玩家{1}", player[1], player[0]);
                    break;
                }
            }



            Win();

            Console.ReadKey();
        }
        //胜利
        public static void Win()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                          ◆                      ");
            Console.WriteLine("                    ■                  ◆               ■        ■");
            Console.WriteLine("      ■■■■  ■  ■                ◆■         ■    ■        ■");
            Console.WriteLine("      ■    ■  ■  ■              ◆  ■         ■    ■        ■");
            Console.WriteLine("      ■    ■ ■■■■■■       ■■■■■■■   ■    ■        ■");
            Console.WriteLine("      ■■■■ ■   ■                ●■●       ■    ■        ■");
            Console.WriteLine("      ■    ■      ■               ● ■ ●      ■    ■        ■");
            Console.WriteLine("      ■    ■ ■■■■■■         ●  ■  ●     ■    ■        ■");
            Console.WriteLine("      ■■■■      ■             ●   ■   ■    ■    ■        ■");
            Console.WriteLine("      ■    ■      ■            ■    ■         ■    ■        ■");
            Console.WriteLine("      ■    ■      ■                  ■               ■        ■ ");
            Console.WriteLine("     ■     ■      ■                  ■           ●  ■          ");
            Console.WriteLine("    ■    ■■ ■■■■■■             ■              ●         ●");
            Console.ResetColor();
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
                str = "Ａ";
            }
            else if (playerpos[1] == i)
            {
                str = "Ｂ";
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

        public static void PlayGame(int playerNumber)
        {
            Random r = new Random();
            int rNumber = r.Next(1, 7);
            Console.WriteLine("{0}按任意键开始掷骰子", player[playerNumber]);
            Console.ReadKey(true);
            Console.WriteLine("{0}掷出了{1}", player[playerNumber], rNumber);
            playerpos[playerNumber] += rNumber;
            ChangePos();
            Console.ReadKey(true);
            Console.WriteLine("{0}按任意键开始行动", player[playerNumber]);
            Console.ReadKey(true);
            Console.WriteLine("{0}行动完了", player[playerNumber]);
            Console.ReadKey(true);
            //玩家A有可能踩到了玩家B 方块 幸运轮盘 地雷 暂停 时空隧道
            if (playerpos[playerNumber] == playerpos[1 - playerNumber])
            {
                Console.WriteLine("玩家{0}踩到了玩家{1}，玩家{2}退6格", player[playerNumber], player[1 - playerNumber], player[1 - playerNumber]);
                playerpos[1 - playerNumber] -= 6;
                ChangePos();
                Console.ReadKey(true);
            }
            else//踩到了关卡
            {
                //玩家的坐标
                switch (maps[playerpos[playerNumber]])// 0 1 2 3 4
                {
                    case 0:
                        Console.WriteLine("玩家{0}踩到了方块，安全。", player[playerNumber]);
                        Console.ReadKey(true);
                        break;
                    case 1:
                        Console.WriteLine("玩家{0}踩到了幸运轮盘，请选择 1--交换位置 2--轰炸对方", player[playerNumber]);
                        string input = Console.ReadLine();
                        while (true)
                        {
                            if (input == "1")
                            {
                                Console.WriteLine("玩家{0}选择跟玩家{1}交换位置", player[playerNumber], player[1 - playerNumber]);
                                Console.ReadKey(true);
                                int temp = playerpos[playerNumber];
                                playerpos[playerNumber] = playerpos[1 - playerNumber];
                                playerpos[1 - playerNumber] = temp;
                                Console.WriteLine("交换完成！！！按任意键继续游戏！！！");
                                Console.ReadKey(true);
                                break;
                            }
                            else if (input == "2")
                            {
                                Console.WriteLine("玩家{0}选择轰炸玩家{1},玩家{2}退6格", player[playerNumber], player[1 - playerNumber], player[1 - playerNumber]);
                                Console.ReadKey(true);
                                playerpos[1 - playerNumber] -= 6;
                                ChangePos();
                                Console.WriteLine("玩家{0}退了6格", playerpos[1 - playerNumber]);
                                Console.ReadKey(true);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("只能输入1或者2  1--交换位置 2--轰炸对方");
                                input = Console.ReadLine();
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("玩家{0}踩到了地雷,退6格", player[playerNumber]);
                        Console.ReadKey(true);
                        playerpos[playerNumber] -= 6;
                        ChangePos();
                        break;
                    case 3:
                        Console.WriteLine("玩家{0}踩到了暂停，暂停一回合", player[playerNumber]);
                        Flags[playerNumber] = true;
                        Console.ReadKey(true);
                        break;
                    case 4:
                        Console.WriteLine("玩家{0}踩到了时空隧道，前进10格", player[playerNumber]);
                        playerpos[playerNumber] += 10;
                        ChangePos();
                        Console.ReadKey(true);
                        break;
                }
            }
            ChangePos();
            Console.Clear();
            DrawMap();
            Console.WriteLine();
        }

        public static void ChangePos()
        {
            if (playerpos[0] < 0)
            {
                playerpos[0] = 0;
            }
            if (playerpos[0] >= 99)
            {
                playerpos[0] = 99;
            }

            if (playerpos[1] < 0)
            {
                playerpos[1] = 0;
            }
            if (playerpos[1] >= 99)
            {
                playerpos[1] = 99;
            }
        }
    }
}