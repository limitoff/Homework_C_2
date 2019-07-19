using System.Drawing;

namespace HomeworkCS2_1
{
    /// <summary>
    /// Тип звезды - Белый карлик
    /// </summary>
    sealed class WhiteDwarf: Star
    {
        public WhiteDwarf(Point pos, Point dir) : base(pos, dir) => Img = new Bitmap(@"..\..\Star2.png");
    }
}
