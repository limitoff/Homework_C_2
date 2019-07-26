using System.Drawing;

namespace HomeworkCS2_1
{
    /// <summary>
    /// Класс Звезда
    /// </summary>
    class Star: BaseObject
    {
        /// <summary>
        /// Конструктор класса Star
        /// </summary>
        /// <param name="pos">Начальная позиция</param>
        /// <param name="dir">Дельта перемещения</param>
        public Star(Point pos, Point dir) : base(pos, dir) { }

        /// <summary>
        /// Метод отрисовки Звезды
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
                Pos.Y = rnd.Next(Game.Height - Img.Height);
            }
        }
    }

    /// <summary>
    /// Тип звезды - Красный карлик
    /// </summary>
    sealed class RedDwarf : Star
    {
        /// <summary>
        /// Конструктор класса RedDwarf
        /// </summary>
        /// <param name="pos">Начальная позиция</param>
        /// <param name="dis">Дельта перемещения</param>
        public RedDwarf(Point pos, Point dir) : base(pos, dir) => Img = new Bitmap(@"..\..\Star3.png");
    }

    /// <summary>
    /// Тип звезды - Белый карлик
    /// </summary>
    sealed class WhiteDwarf : Star
    {
        /// <summary>
        /// Конструктор класса WhiteDwarf
        /// </summary>
        /// <param name="pos">Начальная позиция</param>
        /// <param name="dis">Дельта перемещения</param>
        public WhiteDwarf(Point pos, Point dir) : base(pos, dir) => Img = new Bitmap(@"..\..\Star2.png");
    }

    /// <summary>
    /// Тип звезды - Жёлтый карлик
    /// </summary>
    sealed class YellowDwarf : Star
    {
        /// <summary>
        /// Конструктор класса YellowDwarf
        /// </summary>
        /// <param name="pos">Начальная позиция</param>
        /// <param name="dis">Дельта перемещения</param>
        public YellowDwarf(Point pos, Point dir) : base(pos, dir) => Img = new Bitmap(@"..\..\Star1.png");
    }
}

