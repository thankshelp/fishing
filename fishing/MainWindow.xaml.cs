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

namespace fishing
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public class fish
        {
          
            Rectangle fsh;
            ImageBrush ib = new ImageBrush();
            public int h, w;

            public fish(int x, int y)
            {
               
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
            }

            public void addToScene(ref Canvas scene)
            {
                scene.Children.Add(fsh);
            }
        }

        fish f;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            int x = 0;
            int y = 0;

            for (int i = 0; i < 2; i++)
            {
                int r = new Random().Next(100, 900);
                if(i==0)
                    x = r;
                else
                    y = r;
            }
            

            f = new fish(x, y);
            f.addToScene(ref scene);
        }
    }
}
