using System;
using System.Drawing;
using System.Windows.Forms;

namespace HomeworkCS2_1
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        private static Bullet _bullet;
        /// <summary>
        /// Мамссив астероидов
        /// </summary>
        private static Asteroid[] _asteroids;
        /// <summary>
        /// Массив объектов
        /// </summary>
        public static BaseObject[] _objs;
        /// <summary>
        /// Массив аптечек
        /// </summary>
        public static AidKit[] _aidKits;




        /// <summary>
        /// Объект ship
        /// </summary>
        private static MillenniumFalcon _ship;

        /// <summary>
        /// Ширина игрового поля
        /// </summary>
        public static int Width { get; set; }
        /// <summary>
        /// Высота игрового поля
        /// </summary>
        public static int Height { get; set; }
        /// <summary>
        /// Фон игрового поля
        /// </summary>
        public static Image Img { get; set; }
        /// <summary>
        /// Фон игрового поля
        /// </summary>
        public static Image Img2 { get; set; }

        /// <summary>
        /// Конструктор класса Game
        /// </summary>
        static Game()
        {
            Img = new Bitmap(@"..\..\Cosmo.png");
            Img2 = new Bitmap(@"..\..\Space.jpg");
        }

        /// <summary>
        /// Метод запуска игры
        /// </summary>
        /// <param name="form"></param>
        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаём объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            
            Load();
            //Таймер и обработчик таймера, в котором заставим вызываться Draw и Update.
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;

            // Обработчики событий на KeyDown
            form.KeyDown += Form_KeyDown;

            MillenniumFalcon.MessageDie += Finish;
        }

        private static Timer _timer = new Timer();
        public static Random rnd = new Random();

        private static Timer rndTimer = new Timer() { Interval = 3000 };

        /// <summary>
        /// Обработчик таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        
        /// <summary>
        /// Метод отрисовки объектов на игровом поле
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawImage(Img2, 0, 0, 800, 600);
            Buffer.Graphics.DrawImage(Img, 0, 0, 800, 600);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (Asteroid obj in _asteroids)
                obj.Draw();
            _bullet?.Draw();
            _ship?.Draw();
            if (_ship != null)
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
            Buffer.Render();
        }

        /// <summary>
        /// Метод изменения состояния объектов
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objs) obj.Update();
            _bullet?.Update();
            for (var i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null) continue;
                _asteroids[i].Update();
                if (_bullet != null && _bullet.Collision(_asteroids[i]))
                {
                    System.Media.SystemSounds.Hand.Play();
                    _asteroids[i] = null;
                    _bullet = null;
                    continue;
                }
                if (!_ship.Collision(_asteroids[i])) continue;
                var rnd = new Random();
                _ship?.EnergyLow(rnd.Next(1, 10));
                System.Media.SystemSounds.Asterisk.Play();
                if (_ship.Energy <= 0) _ship?.Die();
            }
        }
        
        /// <summary>
        /// Метод создания звёзд и их направление движения на игровом поле
        /// </summary>
        public static void Load()
        {
            _objs = new BaseObject[60];
            _bullet = new Bullet(new Point(0, 200), new Point(5, 0));
            _asteroids = new Asteroid[3];
            _ship = new MillenniumFalcon(new Point(10, 400), new Point(5, 5));

            var rnd = new Random();
            
            for (int i = 0; i < _objs.Length / 6; i++)
            {
                int r = rnd.Next(5, 50);
                _objs[i] = new RedDwarf(new Point(1000, rnd.Next(0, Height)), new Point(-r, r));
            }
            for (int i = _objs.Length / 6; i < _objs.Length / 3; i++)
            {
                int r = rnd.Next(5, 50);
                _objs[i] = new YellowDwarf(new Point(1000, rnd.Next(0, Height)), new Point(-r, r));
            }
            for (int i = _objs.Length / 3; i < _objs.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _objs[i] = new WhiteDwarf(new Point(1000, rnd.Next(0, Height)), new Point(-r, r));

            }
            
            for (var i = 0; i < _asteroids.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _asteroids[i] = new Asteroid(new Point(1000, rnd.Next(0, Height)), new Point(-r / 5, r));
            }
        }

        /// <summary>
        /// Метод упраления кораблём
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) _bullet = new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(4, 0));
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
        }

        /// <summary>
        /// Метод Финиш
        /// </summary>
        public static void Finish()
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }
    }
}
