using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
