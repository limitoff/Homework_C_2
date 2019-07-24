using System;
using System.Drawing;

namespace HomeworkCS2_1
{
    class Asteroid: BaseObject, ICloneable
    {
        protected int Power { get; set; }
        //protected Size Size { get; set; }

        /// <summary>
        /// Конструктор класса Астероид
        /// </summary>
        /// <param name="pos">Начальная позиция</param>
        /// <param name="dir">Дельта перемещения</param>
        public Asteroid(Point pos, Point dir/*, Size size*/) : base(pos, dir)
        {
            //Size = size;
            Power = 1;
            Img = new Bitmap(@"..\..\Asteroid.png");
        }

        /// <summary>
        /// Метод отрисовки Астеройда
        /// </summary>
        public override void Draw() => Game.Buffer.Graphics.DrawImage(Img, Pos.X, Pos.Y);

        //public object Clone() //Стандартные интерфейсы(2)
        //{
        //    Asteroid asteroid = new Asteroid(new Point(Pos.X, Pos.Y), new Point(Dir.X, Dir.Y));
        //    asteroid.Power = Power;
        //    return asteroid;
        //}

        public object Clone() => MemberwiseClone();
    }
}
