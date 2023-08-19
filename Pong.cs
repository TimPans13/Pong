using System;
using System.Threading;

namespace Pong
{
    public class Pong
    {
        int width;
        int height;

        Board board;

        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public Board Board { get => board; set => board = value; }

        public Pong()//конструктор по умолчанию
        {
            Width = 70;//x    (дефолт:70)
            Height = 25;//y   (дефолт:25)
            
            Board = new Board(Height, Width);
        }
    }

        public class Board
    {
        public int width { set; get; }
        public int height { set; get; }


        public Board()
        {
            width = 70;//x=70    
            height = 25;//y=25       
        }
        public Board(int h, int w)
        {
            height = h;
            width = w;
        }
        public void Write()
        {
            {
                //отрисовка границ поля в 2 цикла
                for (int x = 0; x < width; x++)
                {
                    Console.SetCursorPosition(x, 0);
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("+");
                    Console.SetCursorPosition(x, height - 1);
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("/");
                }

                for (int y = 0; y < height; y++)
                {
                    Console.SetCursorPosition(0, y);
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("+");
                    Console.SetCursorPosition(width - 1, y);
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("/");
                }

                Console.ResetColor();
            }
        }



    }

}

