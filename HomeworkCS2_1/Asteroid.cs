using System;
using System.Drawing;

namespace HomeworkCS2_1
{//++-
    /// <summary>
    /// Класс Астероид
    /// </summary>
    class Asteroid: BaseObject, ICloneable, IComparable<Asteroid>
    {
        /// <summary>
        /// Конструктор класса Астероид
        /// </summary>
        /// <param name="pos">Начальная позиция</param>
        /// <param name="dir">Дельта перемещения</param>
        public Asteroid(Point pos, Point dir, int power = 5) : base(pos, dir)
        {
            Power = power;
            Img = new Bitmap(@"..\..\Asteroid.png");
        }

        /// <summary>
        /// Метод отрисовки Астеройда
        /// </summary>
        public override void Draw() => Game.Buffer.Graphics.DrawImage(Img, Pos.X, Pos.Y);
        /// <summary>
        /// Метод изменения состояния объектов
        /// </summary>
        public override void Update()
        {
            Pos.X += Dir.X;
            if (Pos.X < -Img.Width) //0 - Img.Width
            {
                Pos.X = Game.Width;
                Pos.Y = rnd.Next(0, Game.Height - Img.Height);
            }
        }

        public object Clone() //Стандартные интерфейсы(2)
        {
            //Создаём копию астероида
            Asteroid asteroid = new Asteroid(new Point(Pos.X, Pos.Y), new Point(Dir.X, Dir.Y));
            { Power = Power; } //Не забываем скопировать новому астераиду Power
            return asteroid;
        }
        //public object Clone() => MemberwiseClone();

        int IComparable<Asteroid>.CompareTo(Asteroid obj)
        {
            if (Power > obj.Power)
                return 1;
            if (Power < obj.Power)
                return -1;
            else return 0;
        }
    }
}
