using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
