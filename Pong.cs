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


  public class Ball
    {
        public int X { get; set; }//координаты мяча
        public int Y { get; set; }
        public int xAngle { get; set; }//смещение в каждой из плоскостей за один кадр 
        public int yAngle { get; set; }
        public Ball()
        {
            Random rnd = new Random();
            X += rnd.Next(30, 40);
            Y += rnd.Next(9, 16);
            xAngle = 1;
            yAngle = 1;
        }
        public Ball(int w, int h)
        {
            Random rnd = new Random();
            X += rnd.Next(w / 2 - 5, w / 2 + 5);
            Y += rnd.Next(h / 2 - 3, h / 2 - +3);
            xAngle = 1;
            yAngle = 1;
        }

        public void Write()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("*");
        }
        public void Move(Racket r1, Racket r2)//логика раброты мяча тут
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("\0");//стираем предыдущую позицию

            X += xAngle;
            Y += yAngle;//перемещаем мяч

            if (Y < 2 || Y > 22)//проверка на удар об горизонтальную стену
            {
                yAngle *= -1;//меняем направление мяча
            }

            if (X < 3 || X > 67)//проверка на удар об вертикальную стену
            {
                xAngle *= -1;//меняем направление мяча
            }
            //проверка на удар по ракетке
            if (((X == 4) && ((Y >= (r1.Y - (r1.HalfRacket))) && (Y <= (r1.Y + (r1.HalfRacket))))) || ((X == 66) && ((Y >= (r2.Y - (r2.HalfRacket))) && (Y <= (r2.Y + (r2.HalfRacket))))))
            {
                if (Y == r1.Y || Y == r2.Y) { xAngle *= -2; }
                else { xAngle *= -1; yAngle *= -1; }
            }
            Write();//отрисовываем мяч по новым координатам
        }
    }

   public class Racket
    {
        public int X { get; set; }//координаты ракетки
        public int Y { get; set; }
        public int racketHeight { get; set; }//высота всей ракетки

        public int HalfRacket { get; set; }//высота половины ракетки

        public Racket()
        {
            X = 66;
            Y = 12;
            racketHeight = 25 / 4;
            HalfRacket = racketHeight / 2;
        }

        public Racket(int x, int Height)
        {
            X = x;
            Y = Height / 2;
            racketHeight = Height / 4;
            HalfRacket = racketHeight / 2;
        }

        public void Write() //отрисовка ракетки
        {
            for (int i = Y - (HalfRacket); i < Y + (HalfRacket); i++)
            {
                Console.SetCursorPosition(X, i);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("|");
            }
        }


        public void Up()//ракетка перемещается вверх
        {
            if (Y - 1 - HalfRacket > 0)
            {
                Console.SetCursorPosition(X, Y - 1 + HalfRacket);
                Console.Write("\0");//стираем предыдущую позицию
                Y--;
                Write();//отрисовываем текующую
            }
        }

        public void Down()//ракетка перемещается вниз
        {
            if (Y + 1 + HalfRacket < racketHeight * 4 + 1)
            {
                Console.SetCursorPosition(X, Y - HalfRacket);
                Console.Write("\0");//стираем предыдущую позицию
                Y++;
                Write();
            }
        }
    }

    public class BotRacket : Racket//ракетка управляемая компьютером
    {
        public BotRacket()
        {
            X = 66;
            Y = 12 / 2;
            racketHeight = 12 / 4;
            HalfRacket = racketHeight / 2;
        }
        public BotRacket(int x, int Height)
        {
            X = x;
            Y = Height / 2;
            racketHeight = Height / 4;
            HalfRacket = racketHeight / 2;

        }
        public void BotMove(Ball ball)//логика работы бота
        {
            if (ball.X > 35)
            {
                if (ball.Y > Y) { Down(); }
                if (ball.Y < Y) { Up(); }
            }
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

