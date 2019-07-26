using System;
using System.Drawing;

namespace HomeworkCS2_1
{
    public delegate void Message();

    /// <summary>
    /// Интерфейс определения столкновений Пули с Астероидом
    /// </summary>
    public interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }

    /// <summary>
    /// Класс Базовый объект
    /// </summary>
    abstract class BaseObject: ICollision
    {
        /// <summary>
        /// Картинка объекта
        /// </summary>
        protected Image Img { get; set; }

        protected Point Pos;
        protected Point Dir;
        //protected Size Size;
        protected int Power { get; set; }

        protected Random rnd = new Random();

        /// <summary>
        /// Конструктор класса Базовый объект
        /// </summary>
        /// <param name="pos">Начальная позиция</param>
        /// <param name="dir">Дельта перемещения</param>
        /// <param name="size">Размер</param>
        protected BaseObject(Point pos, Point dir)
        {
            Pos = pos;
            Dir = dir;
            //Size = size;
        }

        /// <summary>
        /// Метод вывод объектов на экран.
        /// </summary>
        public abstract void Draw();
        
        /// <summary>
        /// Метод изменения состояния объектов
        /// </summary>
        public abstract void Update();
        
        /// <summary>
        /// Метод определения столкновений Пули с Астероидом
        /// </summary>
        /// <param name="o">Объект</param>
        /// <returns>True или False</returns>
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect); //«Астероид» с использованием интерфейсов
        public Rectangle Rect => new Rectangle(Pos, Img.Size);
    }
}
