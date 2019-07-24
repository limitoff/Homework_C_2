using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkCS2_1
{
    /// <summary>
    /// Класс Пуля
    /// </summary>
    class Bullet: BaseObject
    {
        /// <summary>
        /// Конструктор класса Bullet
        /// </summary>
        /// <param name="pos">Начальная позиция</param>
        /// <param name="dis">Дельта перемещения</param>
        public Bullet(Point pos, Point dis) : base(pos, dis) => Img = new Bitmap(@"..\..\Bullet.png");

        /// <summary>
        /// Метод отрисовки Пули
        /// </summary>
        public override void Draw() => Game.Buffer.Graphics.DrawImage(Img, Pos.X, Pos.Y);

        /// <summary>
        /// Метод изменения состояния объектов
        /// </summary>
        public override void Update()
        {
            Pos.X += 10;
        }
    }
}
