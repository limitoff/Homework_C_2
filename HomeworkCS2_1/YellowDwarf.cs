using System.Drawing;

namespace HomeworkCS2_1
{
    /// <summary>
    /// Тип звезды - Жёлтый карлик
    /// </summary>
    sealed class YellowDwarf: Star
    {
        public YellowDwarf(Point pos, Point dir) : base(pos, dir) => Img = new Bitmap(@"..\..\Star1.png");
    }
}
