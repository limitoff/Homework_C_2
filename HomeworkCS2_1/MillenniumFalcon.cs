using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HomeworkCS2_1
{
    /// <summary>
    /// Класс Тысячилетний Сокол (Ship)
    /// </summary>
    class MillenniumFalcon: BaseObject
    {
        public static event Message MessageDie;

        private int _energy = 100;
        public int Energy => _energy;

        public void EnergyLow(int n)
        {
            _energy -= n;
        }
        public MillenniumFalcon(Point pos, Point dir) : base(pos, dir) { Img = new Bitmap(@"..\..\MillenniumFalcon.png"); }

        public override void Draw() => Game.Buffer.Graphics.DrawImage(Img, Pos.X, Pos.Y);
        public override void Update() { }
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }
        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
        }
        public void Die()
        {
            MessageDie?.Invoke();
            Logger.WriteMessage("Корабль унечтожен!");
        }
    }
}
