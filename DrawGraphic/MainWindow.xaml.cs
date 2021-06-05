using System;
using System.Collections.Generic;
using System.Data;
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
using Rendering;

namespace DrawGraphic
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double scale = 1;
        public double Scale
        {
            set
            {
                if (value <= 0) scale = 1;
                else scale = value;
            }

            get
            {
                return scale;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            Graph2D.MouseWheel += Scale_Wheel;
        }

        private void BtCalc_Click(object sender, RoutedEventArgs e)
        {
            Graph2D.Children.Clear();
            List<Coordinates> CoordList = new List<Coordinates>();
            string example = tbFunction.Text;
            double limitX = 100.0;
            DataTable table = new DataTable();
            table.Columns.Add("x");
            table.Columns.Add("y");
            for (double x = -limitX; x < limitX; x+=0.2)
            {
                string numX = x.ToString();
                string func = example.Replace("x", numX);
                string[] exampleArray = func.Split(' ');
                GetOPS getops = new GetOPS();
                string ops = getops.SignAfter(exampleArray);
                string[] repeate = ops.Split(' ');
                CountSumm calcY = new CountSumm();
                double calc = (double)calcY.GetSummRangeX(repeate);
                Coordinates newcoord = new Coordinates(x, calc);
                CoordList.Add(newcoord);
                Item c = new Item { X = x, Y = calc };
                dataGrid.Items.Add(c);

            }

            // dataGrid.DataContext = table;
            
            int OX = (int)Graph2D.ActualWidth;
            int OY = (int)Graph2D.ActualHeight;
            foreach (var line in DrawCoordAxis())
            {
                Graph2D.Children.Add(line);
            }

            for (int i = 0; i < CoordList.Count - 1; i++)
            {
                Line myLine = new Line();
                myLine.Stroke = Brushes.Black;
                myLine.StrokeThickness = 1;
                myLine.X1 = CoordList[i].x * scale + OX / 2;
                myLine.X2 = CoordList[i + 1].x * scale + OX / 2;
                myLine.Y1 = Graph2D.ActualHeight - CoordList[i].y * scale - OY / 2;
                myLine.Y2 = Graph2D.ActualHeight - CoordList[i + 1].y * scale - OY / 2;

                Graph2D.Children.Add(myLine);
            }
            //Draw(CoordList);
            Item item = new Item() { X = 0, Y = 1 };
            dataGrid.Items.Add(item);
        }

        public List<UIElement> DrawCoordAxis()
        {
            List<UIElement> lineList = new List<UIElement>();
            int OX = (int)Graph2D.ActualWidth;
            int OY = (int)Graph2D.ActualHeight;
            Line axisX = new Line();
            axisX.Stroke = Brushes.Black;
            axisX.StrokeThickness = 1;
            axisX.X1 = 0;
            axisX.X2 = OX;
            axisX.Y1 = OY / 2;
            axisX.Y2 = OY / 2;
            lineList.Add(axisX);

            Line axisY = new Line();
            axisY.Stroke = Brushes.Black;
            axisY.StrokeThickness = 1;
            axisY.X1 = OX / 2;
            axisY.X2 = OX / 2;
            axisY.Y1 = 0;
            axisY.Y2 = OY;
            lineList.Add(axisY);

            for(int i = 0; i < OX / 2 ; i++)
            {
                Line divP = new Line();
                divP.Stroke = Brushes.Black;
                divP.StrokeThickness = 1;
                divP.X1 = i * scale + OX / 2;
                divP.X2 = i * scale + OX / 2;
                divP.Y1 =(-scale * 0.2)+ OY / 2;
                divP.Y2 = (scale * 0.2) + OY / 2;
                lineList.Add(divP);

                TextBlock tb = new TextBlock();
                tb.Text = i.ToString();
                Canvas.SetLeft(tb, i * scale + OX / 2 - 4);
                Canvas.SetTop(tb, scale + OY / 2 + 5);
                lineList.Add(tb);
            }

            for (int i = 0; i > -OX / 2; i--)
            {
                Line divP = new Line();
                divP.Stroke = Brushes.Black;
                divP.StrokeThickness = 1;
                divP.X1 = i * scale + OX / 2;
                divP.X2 = i * scale + OX / 2;
                divP.Y1 = (-scale * 0.2) + OY / 2;
                divP.Y2 = (scale * 0.2) + OY / 2;
                lineList.Add(divP);

                TextBlock tb = new TextBlock();
                tb.Text = i.ToString();
                Canvas.SetLeft(tb, i * scale + OX / 2 - 4);
                Canvas.SetTop(tb, scale + OY / 2 + 5);
                lineList.Add(tb);
            }


            for (int i = 0; i < OY / 2 ; i++)
            {
                Line divP = new Line();
                divP.Stroke = Brushes.Red;
                divP.StrokeThickness = 1;
                divP.X1 = (-scale * 0.2) + OX / 2;
                divP.X2 = (scale * 0.2) + OX / 2;
                divP.Y1 = i * scale + OY / 2;
                divP.Y2 = i * scale + OY / 2;
                lineList.Add(divP);

                TextBlock tb = new TextBlock();
                tb.Text = i.ToString();
                Canvas.SetLeft(tb, -scale + OX / 2 - 5);
                Canvas.SetTop(tb, -i * scale + OY / 2 - 4);
                lineList.Add(tb);
            }

            for (int i = 0; i > -OY / 2; i--)
            {
                Line divP = new Line();
                divP.Stroke = Brushes.Red;
                divP.StrokeThickness = 1;
                divP.X1 = (-scale * 0.2) + OX / 2;
                divP.X2 = (scale * 0.2) + OX / 2;
                divP.Y1 = i * scale + OY / 2;
                divP.Y2 = i * scale + OY / 2;
                lineList.Add(divP);

                TextBlock tb = new TextBlock();
                tb.Text = i.ToString();
                Canvas.SetLeft(tb, -scale + OX / 2 - 5);
                Canvas.SetTop(tb, -i * scale + OY / 2 - 4);
                lineList.Add(tb);
            }

            return lineList;
        }

        private void Draw(List<Coordinates> __AnythingCoordList)
        {

            Line myLine = new Line();
            myLine.Stroke = Brushes.Black;
            myLine.StrokeThickness = 1;
            int size = 1;
            for (int i = 0; i < __AnythingCoordList.Count-1; i++)
            {
                myLine.X1 = __AnythingCoordList[i].x * size;
                myLine.X2 = __AnythingCoordList[i+1].x * size;
                myLine.Y1 = __AnythingCoordList[i].y * size;
                myLine.Y2 = __AnythingCoordList[i + 1].y * size;
                Graph2D.Children.Add(myLine);
            }
        }

        private void BtScale_Click(object sender, RoutedEventArgs e)
        {
            scale += 10;
            BtCalc_Click(sender, e);
        }

        private void Scale_Wheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0) Scale += 10;
            if (e.Delta < 0) Scale -= 10;
            BtCalc_Click(sender, e);
        }
    }

    class Item
    {
        public double X { get; set; }
        public double Y { get; set; }
        


    }
}