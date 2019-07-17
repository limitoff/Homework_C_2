using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkCS2_1
{
    /// <summary>
    /// Класс Звезда
    /// </summary>
    class Star: BaseObject
    {
        /// <summary>
        /// Картинка Звезды
        /// </summary>
        public Image Img { get; set; }

        /// <summary>
        /// Конструктор класса Star
        /// </summary>
        /// <param name="pos">Начальная позиция</param>
        /// <param name="dir">Дельта перемещения</param>
        /// <param name="size">Размер</param>
        public Star(Point pos, Point dir) : base(pos, dir) { }

        /// <summary>
        /// Метод отрисовки Звезды
        /// </summary>
        public override void Draw() => Game.Buffer.Graphics.DrawImage(Img, Pos.X, Pos.Y);

        /// <summary>
        /// Метод обновления позиции Звезды
        /// </summary>
        public override void Update()
        {
            Pos.X += Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width;
        }
    }
}
