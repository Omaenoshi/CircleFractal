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

namespace CircleFractal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Draw(double radius, double i, double dx, double dy)
        {

            if (i > 0)
            {
                Draw(radius / 2, i - 1, dx + radius * i, dy);
                Draw(radius / 2, i - 1, dx, dy - radius * i );
                Draw(radius / 2, i - 1, dx, dy + radius * i);
                Draw(radius / 2, i - 1, dx - radius * i , dy);
            }

            
            Ellipse target = new Ellipse();
            target.Width = radius;
            target.Height = radius;
            target.Stroke = Brushes.Red;
            target.StrokeThickness = 2;
            Canvas.SetLeft(target, (Field.ActualWidth - target.ActualWidth - radius) / 2 + dx);
            Canvas.SetTop(target, (Field.ActualHeight - target.ActualHeight - radius) / 2 + dy);
            Field.Children.Add(target);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Field.Children.Clear();

            double radius = 30;
            int i = int.Parse(Count.Text);

            Draw(radius, i, 0, 0);
        }
    }
}
