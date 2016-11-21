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
using ParrallelPrograming_task1_;
using System.ComponentModel;

namespace ClimateData
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void DrawLines(double w, double h, System.Windows.Media.Brush Col, int level)
        {
            ViewModel v = new ViewModel(level);
            v.Execute();
            List<line> lines = v.GetLines();

            for (int i = 0; i < lines.Count; ++i)
            {
                Line line = new Line();
                line.Stroke = Col;
                line.X1 = w - lines[i].x1 * w;
                line.Y1 = - h+ lines[i].y1 * (17 * h / 18)  +  (h / 18);
                line.X2 = w - lines[i].x2 * w;
                line.Y2 =  -h +  lines[i].y2 * (17 * h / 18)  + (h / 18);
                line.StrokeThickness = 1;

                Panel.Children.Add(line);
            }
        }

        private void MyWin_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //image.Height = MyWin.Height;
            //image.Width = MyWin.Width;
            image = new Image();
            image.VerticalAlignment = VerticalAlignment.Center;
            image.HorizontalAlignment = HorizontalAlignment.Center;
            image.Stretch = Stretch.Fill;
            image.Height = e.NewSize.Height;
            image.Width = e.NewSize.Width;
            Panel.Children.Clear();
            Panel.Children.Add(image);
            DrawLines(e.NewSize.Width, e.NewSize.Height, System.Windows.Media.Brushes.Black, -10);
            DrawLines(e.NewSize.Width, e.NewSize.Height, System.Windows.Media.Brushes.Violet, 0);
            DrawLines(e.NewSize.Width, e.NewSize.Height, System.Windows.Media.Brushes.Red, 10);
            DrawLines(e.NewSize.Width, e.NewSize.Height, System.Windows.Media.Brushes.Yellow, 25);
        }
    }
}
