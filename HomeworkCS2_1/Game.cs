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
        private static Asteroid[] _asteroids;

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
            // Таймер и обработчик таймера, в котором заставим вызываться Draw и Update.
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

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
            _bullet.Draw();
            Buffer.Render();
        }

        /// <summary>
        /// Метод изменения состояния объектов
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();

            foreach (BaseObject obj in _asteroids)
            {
                obj.Update();
                if (obj.Collision(_bullet))
                    System.Media.SystemSounds.Hand.Play();
            }
            _bullet.Update();
        }

        /// <summary>
        /// Массив объектов
        /// </summary>
        public static BaseObject[] _objs;



        /// <summary>
        /// Метод создания звёзд и их направление движения на игровом поле
        /// </summary>
        public static void Load()
        {
            _objs = new BaseObject[60];
            _bullet = new Bullet(new Point(0, 200), new Point(5, 0));
            _asteroids = new Asteroid[3];
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
                _asteroids[i] = new Asteroid(new Point(1000, rnd.Next(0, Height)), new Point(-r / 5, r)/*, new Size(r, r)*/);
            }
        }
    }
}
