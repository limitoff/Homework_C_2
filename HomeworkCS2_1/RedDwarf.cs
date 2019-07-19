using System.Drawing;

namespace HomeworkCS2_1
{
    /// <summary>
    /// Тип звезды - Красный карлик
    /// </summary>
    sealed class RedDwarf: Star
    {
        public RedDwarf(Point pos, Point dir) : base(pos, dir) => Img = new Bitmap(@"..\..\Star3.png");
    }
}
