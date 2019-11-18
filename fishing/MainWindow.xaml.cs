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
using System.Xml.Linq;


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
            public int X { get; set; }
            public int Y { get; set; }

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
            Rectangle fsh { get; set; }
            ImageBrush ib = new ImageBrush();
            int kl { get; set; }
            
            
            public fish(int x, int y, ref Canvas scene, string iname)
            {
                this.finpos.X = this.strpos.X = x;
                this.finpos.Y = this.strpos.Y = y;
                


                fsh = new Rectangle();
                fsh.Width = 50;
                fsh.Height = 70;

                ib.AlignmentX = AlignmentX.Left;
                ib.AlignmentY = AlignmentY.Top;
                ib.Stretch = Stretch.None;

                ib.Viewbox = new Rect(0, 0, 0, 0);
                ib.ViewboxUnits = BrushMappingMode.Absolute;

                ib.ImageSource = new BitmapImage(new Uri(iname, UriKind.Absolute));

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
            public void move(int X, int Y)
            {
               if (X < strpos.X)
               {
                    strpos.X -= 1;
                    ib.Viewbox = new Rect(65, 0, 0, 0);
                    fsh.Width = 70;
                    fsh.Height = 50;
                }
               if (X > strpos.X)
               {
                    strpos.X += 1;
                    ib.Viewbox = new Rect(0, 0, 0, 0);
                    fsh.Width = 70;
                    fsh.Height = 50;
                }
               if (Y < strpos.Y)
               {
                    strpos.Y -= 1;
                    ib.Viewbox = new Rect(133, 0, 0, 0);
                    fsh.Width = 50;
                    fsh.Height = 70;

                }
               if (Y > strpos.Y)
               {
                    strpos.Y += 1;
                    ib.Viewbox = new Rect(183, 0, 0, 0);
                    fsh.Width = 50;
                    fsh.Height = 70;

                }
                fsh.Fill = ib;
                fsh.RenderTransform = new TranslateTransform(strpos.X, strpos.Y);

            }
        }

        public class seaweed
        {
            public int X, Y;
            public Rectangle weed;
            ImageBrush ib = new ImageBrush();

            public seaweed(int x, int y, ref Canvas scene)
            {
                this.X = x;
                this.Y = y;

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

        
        
        Random rnd = new Random();
        int klw, kof, kbf, round, ind; 
        double dist,min = 1100;
        List<fish> of, bf;
        List<seaweed> s;
        
        System.Windows.Threading.DispatcherTimer Timer;
        System.Windows.Threading.DispatcherTimer Timer2;
        public MainWindow()
        {
            InitializeComponent();

            Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Tick += new EventHandler(dispatcherTimer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 1);

            Timer2 = new System.Windows.Threading.DispatcherTimer();
            Timer2.Tick += new EventHandler(dispatcherTimer_Tick2);
            Timer2.Interval = new TimeSpan(0, 0, 0, 0, 2);


        }
        private void dispatcherTimer_Tick2(object sender, EventArgs e)
        {
            foreach (fish fs in bf)
            {
                foreach (seaweed sw in s.ToArray())
                {
                    dist = Math.Sqrt(Math.Pow(fs.strpos.X - sw.X, 2) + Math.Pow(fs.strpos.Y - sw.Y, 2));
                    ind = s.IndexOf(sw);

                    if (min > dist)
                    {
                        min = dist;
                        fs.finpos.X = sw.X;
                        fs.finpos.Y = sw.Y;

                    }
                    if ((fs.finpos.X == fs.strpos.X) && (fs.finpos.Y == fs.strpos.Y))
                    {
                        scene.Children.Remove(sw.weed);
                        s.Remove(sw);
                    }

                }
                fs.move(fs.finpos.X, fs.finpos.Y);
            }
        }


        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            foreach (fish ofs in of)
            {
                foreach (seaweed sw in s.ToArray())
                {
                    dist = Math.Sqrt(Math.Pow(ofs.strpos.X - sw.X, 2) + Math.Pow(ofs.strpos.Y - sw.Y, 2));

                    if (min > dist)
                    {
                        min = dist;
                        ofs.finpos.X = sw.X;
                        ofs.finpos.Y = sw.Y;

                    }
                    if ((ofs.finpos.X == ofs.strpos.X) && (ofs.finpos.Y == ofs.strpos.Y))
                    {
                        scene.Children.Remove(sw.weed);
                        s.Remove(sw);
                    }

                }

                ofs.move(ofs.finpos.X, ofs.finpos.Y);
            }
            //f.updatePos();
            if (s.Count == 0)
            {
                Timer.Stop();
                Timer2.Stop();
                if (round == 1)
                {
                    XDocument xdoc = new XDocument();
                    XElement round1 = new XElement("round");
                    XAttribute roundname = new XAttribute("name", "1");
                    XElement fish1 = new XElement("OrangeFish", kof);
                   
                    round1.Add(roundname);
                    round1.Add(fish1);
                   

                    XElement run = new XElement("run");

                    run.Add(round1);

                    xdoc.Add(run);

                    xdoc.Save("fishing.xml");
                }
                round++;
            }
        }

      
            private void start_Click(object sender, RoutedEventArgs e)
            {
                round = 1;
                menu.Visibility = Visibility.Hidden;
                scene.Visibility = Visibility.Visible;

                klw = int.Parse(kol_weed.Text);
                kof = int.Parse(OFish.Text);
                kbf = int.Parse(BFish.Text);

                bf = new List<fish>(kbf);
                of = new List<fish>(kof);
                s = new List<seaweed>(klw);

                for (int i = 0; i < klw; i++)
                {
                    int wx = rnd.Next(100, 850);
                    int wy = rnd.Next(100, 850);

                    s.Add(new seaweed(wx, wy, ref scene));
                }

                for (int i = 0; i < kof; i++)
                {

                    int x = rnd.Next(100, 850);
                    int y = rnd.Next(100, 850);

                    for (int j = 0; j < i; j++)
                    {
                        while ((x == of[j].strpos.X) && (y == of[j].strpos.Y))
                        {
                        x = rnd.Next(100, 850);
                        y = rnd.Next(100, 850);
                        }
                    }

                    of.Add(new fish(x, y, ref scene, @"pack://application:,,,/image/ff_1.png"));
                }

                for (int i = 0; i < kbf; i++)
                {

                    int x = rnd.Next(100, 850);
                    int y = rnd.Next(100, 850);

                    for (int j = 0; j < i; j++)
                    {
                        while ((x == bf[j].strpos.X) && (y == bf[j].strpos.Y))
                        {
                            x = rnd.Next(100, 850);
                            y = rnd.Next(100, 850);
                        }
                    }

                    bf.Add(new fish(x, y, ref scene, @"pack://application:,,,/image/ff_2.png"));
                }

            Timer.Start();
            Timer2.Start();
        }
    }
}
