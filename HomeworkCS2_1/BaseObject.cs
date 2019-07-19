using System.Drawing;

namespace HomeworkCS2_1
{
    class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        //protected Size Size;

        /// <summary>
        /// Конструктор класса Базовый объект
        /// </summary>
        /// <param name="pos">Начальная позиция</param>
        /// <param name="dir">Дельта перемещения</param>
        /// <param name="size">Размер</param>
        public BaseObject(Point pos, Point dir)
        {
            Pos = pos;
            Dir = dir;
            //Size = size;
        }
        
        /// <summary>
        /// Метод вывод объектов на экран.
        /// </summary>
        public virtual void Draw()
        {
            //Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        
        /// <summary>
        /// Метод изменения состояния объектов
        /// </summary>
        public virtual void Update()
        {
            Pos.X += Dir.X;
            Pos.Y += Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }
    }
}
