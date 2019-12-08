using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Linq;
using OxyPlot;
using OxyPlot.Series;


namespace fishing
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //условие изменения направления и пофиксить штуку с расстоянием
        
        public class fish
        {
            public int fx, fy, kkal = 0;
            //public SPoint finpos = new SPoint();
            //public SPoint strpos = new SPoint(); 
            public Rectangle fsh { get; set; }
            ImageBrush ib = new ImageBrush();
            int kl { get; set; }
            Rect rect;
            
            
            public fish(int x, int y, ref Canvas scene, string iname)
            {
                this.fx = x;
                this.fy = y;
                


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

                rect = fsh.RenderTransform.TransformBounds(fsh.RenderedGeometry.Bounds);

                scene.Children.Add(fsh);
            }

            public void move(int X, int Y)
            {
               if (X < fx)
               {
                    fx -= 1;
                    ib.Viewbox = new Rect(60, 0, 0, 0);
               }

               if (X > fx)
               {
                    fx += 1;
                    ib.Viewbox = new Rect(0, 0, 0, 0);
               }
               if (Y < fy)
               {
                    fy -= 1;
                    ib.Viewbox = new Rect(106, 0, 0, 0);
               }
               if (Y > fy)
               {
                   fy += 1;
                    ib.Viewbox = new Rect(155, 0, 0, 0);
               }
                fsh.Fill = ib;
                fsh.RenderTransform = new TranslateTransform(fx, fy);

            }
        }

        public class seaweed
        {
            public int sx, sy;
            public Rectangle weed;
            ImageBrush ib = new ImageBrush();

            public seaweed(int x, int y, ref Canvas scene)
            {
                this.sx = x;
                this.sy = y;

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
        int klw, kof, kbf, round, seaweeds;
        int tx, ty;
        double dist;
        List<fish> of, bf, allf;
        List<seaweed> s;
        graphs graf = new graphs();

        private void graph_Click(object sender, RoutedEventArgs e)
        {
            XDocument xdoc = XDocument.Load("D:\\Program\\fishing\\fishing\\stats.xml");

            foreach (XElement elem in xdoc.Element("simulation").Elements("round"))
            {
                XAttribute roundname = elem.Attribute("round");
                XElement ofcount = elem.Element("OrangeFish");
                XElement bfcount = elem.Element("BlueFish");

                if (roundname != null && ofcount != null && bfcount != null)
                {
                    DataPoint point1 = new DataPoint(double.Parse(roundname.Value), double.Parse(ofcount.Value));
                    DataPoint point2 = new DataPoint(double.Parse(roundname.Value), double.Parse(bfcount.Value));
                    graf.orangef.Add(point1);
                    graf.bluef.Add(point2);
                }
                
            }

            gf.Visibility = Visibility.Visible;
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            next.Visibility = Visibility.Hidden;
            graph.Visibility = Visibility.Hidden;
            gf.Visibility = Visibility.Hidden;

            round++;
            lb.Content = "Round\n" + round;

            for (int i = 0; i < klw; i++)
            {
                int wx = rnd.Next(100, 850);
                int wy = rnd.Next(100, 850);

                s.Add(new seaweed(wx, wy, ref scene));
            }

            XmlDocument xdoc = new XmlDocument();
            xdoc.Load("D:\\Program\\fishing\\fishing\\stats.xml");
            XmlElement xRoot = xdoc.DocumentElement;

            XmlElement rounds = xdoc.CreateElement("round");
            XmlAttribute roundname = xdoc.CreateAttribute("number");

            XmlElement fish1 = xdoc.CreateElement("OrangeFish");
            XmlElement fish2 = xdoc.CreateElement("BlueFish");


            XmlText roundnum = xdoc.CreateTextNode(round.ToString());
            XmlText fishes1 = xdoc.CreateTextNode(of.Count().ToString());
            XmlText fishes2 = xdoc.CreateTextNode(bf.Count().ToString());

            roundname.AppendChild(roundnum);
            fish1.AppendChild(fishes1);
            fish2.AppendChild(fishes2);
            rounds.Attributes.Append(roundname);
            rounds.AppendChild(fish1);
            rounds.AppendChild(fish2);
            xRoot.AppendChild(rounds);

            xdoc.Save("D:\\Program\\fishing\\fishing\\stats.xml");

            Timer.Start();
            Timer2.Start();
        }

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
            Timer2.Interval = new TimeSpan(0, 0, 0, 0, 20);


        }
        private void dispatcherTimer_Tick2(object sender, EventArgs e)
        {
            int curfish = -1;
            foreach (fish fs in bf)
            {
                double min = 1100;
                int curweed = -1;
                curfish++;
                foreach (seaweed sw in s)
                {
                    curweed++;
                    dist = Math.Sqrt(Math.Pow(fs.fx - sw.sx, 2) + Math.Pow(fs.fy - sw.sy, 2));

                    if (min > dist)
                    {
                        min = dist;
                        tx = sw.sx;
                        ty = sw.sy;
                        seaweeds = curweed;
                    }
                    if ((fs.fx == sw.sx) && (fs.fy == sw.sy))
                    {
                        scene.Children.Remove(sw.weed);
                        fs.kkal++;
                    }

                }
                    try
                    {
                        if ((fs.fx == tx) && (fs.fy == ty))
                        {
                            s.RemoveAt(seaweeds);
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {

                    }
                    fs.move(tx, ty);
                
            }
            if (s.Count == 0)
            {
                Timer.Stop();
                Timer2.Stop();
                foreach (fish all in allf)
                {
                    int del = -1;
                    int cur = -1;
                    foreach (fish fs in bf)
                    {
                        cur++;
                        if (fs.kkal < 2)
                        {
                            del = cur;
                            scene.Children.Remove(fs.fsh);
                        }
                    }
                    if (del != -1)
                    {
                        bf.RemoveAt(del);
                    }
                }
                foreach (fish all in allf)
                {
                    int del = -1;
                    int cur = -1;
                    foreach (fish fs in of)
                    {
                        cur++;
                        if (fs.kkal == 0)
                        {
                            del = cur;
                            scene.Children.Remove(fs.fsh);
                        }
                    }
                    if (del != -1)
                    {
                        of.RemoveAt(del);
                    }
                }
                foreach (fish f in bf)
                {
                    f.kkal = 0;
                }
                foreach (fish f in of)
                {
                    f.kkal = 0;
                }
                next.Visibility = Visibility.Visible;
                graph.Visibility = Visibility.Visible;
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            int curfish = -1;
            foreach (fish ofs in of)
            {
                double min = 1100;
                int curweed = -1;
                curfish++;
                
               foreach (seaweed sw in s)
               {
                    curweed++;
                    dist = Math.Sqrt(Math.Pow(ofs.fx - sw.sx, 2) + Math.Pow(ofs.fy - sw.sy, 2));

                    if (min > dist)
                    {
                        min = dist;
                        tx = sw.sx;
                        ty = sw.sy;
                        seaweeds = curweed;

                    }
                    if ((ofs.fx == sw.sx) && (ofs.fy == sw.sy))
                    {
                        scene.Children.Remove(sw.weed);
                        ofs.kkal++;
                    }

               }
                try
                {
                    if (( ofs.fx == tx) &&(ofs.fy == ty))
                    {
                        s.RemoveAt(seaweeds);
                    }
                }
                catch (ArgumentOutOfRangeException)
                {

                }

                ofs.move(tx, ty);
            }
           
            if (s.Count == 0)
            {
                Timer.Stop();
                Timer2.Stop();
                foreach (fish all in allf)
                {
                    int del = -1;
                    int cur = -1;
                    foreach (fish fs in bf)
                    {
                        cur++;
                        if (fs.kkal < 2)
                        {
                            del = cur;
                            scene.Children.Remove(fs.fsh);
                        }
                    }
                    if (del != -1)
                    {
                        bf.RemoveAt(del);
                    }
                }
                foreach (fish all in allf)
                {
                    int del = -1;
                    int cur = -1;
                    foreach (fish fs in of)
                    {
                        cur++;
                        if (fs.kkal == 0)
                        {
                            del = cur;
                            scene.Children.Remove(fs.fsh);
                        }
                    }
                   // if (del != -1)
                   // {
                   //     bf.RemoveAt(del);
                   // }
                }
                foreach(fish f in bf)
                {
                    f.kkal = 0;
                }
                foreach(fish f in of)
                {
                    f.kkal = 0;
                }
                next.Visibility = Visibility.Visible;
                graph.Visibility = Visibility.Visible;
            }
        }
        
        private void start_Click(object sender, RoutedEventArgs e)
        {
            round = 1;
            menu.Visibility = Visibility.Hidden;
            scene.Visibility = Visibility.Visible;

            lb.Content = "Round\n" + round;
            

            klw = int.Parse(kol_weed.Text);
            kof = int.Parse(OFish.Text);
            kbf = int.Parse(BFish.Text);


            allf = new List<fish>(kbf+kof);
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
                     while ((x == of[j].fx) && (y == of[j].fy))
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
                    while ((x == bf[j].fx) && (y == bf[j].fy))
                    {
                        x = rnd.Next(100, 850);
                        y = rnd.Next(100, 850);
                    }
                }

                bf.Add(new fish(x, y, ref scene, @"pack://application:,,,/image/ff_2.png"));
                    
            }

            foreach(fish f in bf)
            {
                allf.Add(f);
            }
            foreach (fish f in of)
            {
                allf.Add(f);
            }

            XmlDocument xdoc = new XmlDocument();
            xdoc.Load("D:\\Program\\fishing\\fishing\\stats.xml");
            XmlElement xRoot = xdoc.DocumentElement;

            XmlElement rounds = xdoc.CreateElement("round");
            XmlAttribute roundname = xdoc.CreateAttribute("number");

            XmlElement fish1 = xdoc.CreateElement("OrangeFish");
            XmlElement fish2 = xdoc.CreateElement("BlueFish");


            XmlText roundnum = xdoc.CreateTextNode(round.ToString());
            XmlText fishes1 = xdoc.CreateTextNode(of.Count().ToString());
            XmlText fishes2 = xdoc.CreateTextNode(bf.Count().ToString());

            roundname.AppendChild(roundnum);
            fish1.AppendChild(fishes1);
            fish2.AppendChild(fishes2);
            rounds.Attributes.Append(roundname);
            rounds.AppendChild(fish1);
            rounds.AppendChild(fish2);
            xRoot.AppendChild(rounds);

            xdoc.Save("D:\\Program\\fishing\\fishing\\stats.xml");

            Timer.Start();
            Timer2.Start();
        }
    }
}
