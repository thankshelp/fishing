using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;


namespace fishing
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //условие изменения направления и пофиксить штуку с расстоянием
        public class SPoint
        {
            public int X;
            public int Y;

            public SPoint()
            {
                X = 0;
                Y = 0;
            }

            public static SPoint operator +(SPoint a, SPoint b)
            {
                SPoint r = new SPoint();
                r.X = a.X + b.X;
                r.Y = a.Y + b.Y;
                return r;
            }
        }
        public class fish
        {
            //public int x, y, X, Y, dx, dy;
            public SPoint finpos = new SPoint();
            public SPoint strpos = new SPoint(); 
            public SPoint dir = new SPoint();  
            Rectangle fsh;
            ImageBrush ib = new ImageBrush();
            int kl;
            int speed;
            
            public fish(int x, int y, int sp, ref Canvas scene)
            {
                this.finpos.X = this.strpos.X = x;
                this.finpos.Y = this.strpos.Y = y;
                this.speed = sp;


                fsh = new Rectangle();
                fsh.Width = 70;
                fsh.Height = 70;

                ib.AlignmentX = AlignmentX.Left;
                ib.AlignmentY = AlignmentY.Top;
                ib.Stretch = Stretch.None;

                ib.Viewbox = new Rect(0, 0, 0, 0);
                ib.ViewboxUnits = BrushMappingMode.Absolute;

                ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/image/ryba1.png", UriKind.Absolute));

                fsh.Fill = ib;

                fsh.RenderTransform = new TranslateTransform(x, y);

                scene.Children.Add(fsh);
            }
            

            //void step()
            //{
            //    int r = new Random().Next(900);
            //    while ((finpos.X + dir.X * r > 900) && (finpos.X + dir.X * r < 100) && (finpos.Y + dir.Y * r > 900) && (finpos.Y + dir.Y * r < 100))
            //    {
            //        r = new Random().Next(100, 900);
            //    }
            //    finpos.X = finpos.X + dir.X * r;
            //    finpos.Y = finpos.Y + dir.Y * r;
            //}
            //public void updatePos()
            //{
            //    if ((finpos.X == strpos.X) && (finpos.Y == strpos.Y))
            //    {
            //        step();
            //    }

            //    if (strpos.X < finpos.X) { strpos.X += 1; }
            //    if (strpos.X > finpos.X) { strpos.X -= 1; }
            //    if (strpos.Y < finpos.Y) { strpos.Y += 1; }
            //    if (strpos.Y > finpos.Y) { strpos.Y -= 1; }


            //    fsh.RenderTransform = new TranslateTransform(strpos.X, strpos.Y);
            //}
        }

        public class seaweed
        {
            Rectangle weed;
            ImageBrush ib = new ImageBrush();

            public seaweed(int x, int y, ref Canvas scene)
            {
                weed = new Rectangle();
                weed.Width = 70;
                weed.Height = 70;

                ib.AlignmentX = AlignmentX.Left;
                ib.AlignmentY = AlignmentY.Top;
                ib.Stretch = Stretch.None;

                ib.Viewbox = new Rect(0, 0, 0, 0);
                ib.ViewboxUnits = BrushMappingMode.Absolute;

                ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/image/vodr.png", UriKind.Absolute));

                weed.Fill = ib;

                weed.RenderTransform = new TranslateTransform(x, y);

                scene.Children.Add(weed);
            }
            
        }

        
        seaweed w;
        Random rnd = new Random();
        int klw, kof, kbf, spof, spbf, round;

        System.Windows.Threading.DispatcherTimer Timer;
        public MainWindow()
        {
            InitializeComponent();

            Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Tick += new EventHandler(dispatcherTimer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 1);

          
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //f.updatePos();
            if (klw == 0)
            {
                Timer.Stop();
                round++;

                

            }
        }
            private void start_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Hidden;
            scene.Visibility = Visibility.Visible;

            klw = int.Parse(kol_weed.Text);
            kof = int.Parse(OFish.Text);
            spof = int.Parse(spO.Text);

            List<fish> f = new List<fish>(kof);

            for (int i = 0; i < klw; i++)
            {
                int wx = rnd.Next(100, 850);
                int wy = rnd.Next(100, 850);

                w = new seaweed(wx, wy, ref scene);
                
            }

            for (int i = 0; i < kof; i++)
            {

                int x = rnd.Next(100, 850);
                int y = rnd.Next(100, 850);

                for (int j = 0; j < i; j++)
                {
                    if ((x == f[j].strpos.X) && (y == f[j].strpos.Y))
                    {
                        x = rnd.Next(100, 850);
                        y = rnd.Next(100, 850);
                    }
                }

                f.Add(new fish(x, y, spof, ref scene));
            }

            Timer.Start();
        }
    }
}
