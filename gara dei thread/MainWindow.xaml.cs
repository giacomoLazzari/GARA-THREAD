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
using System.Threading;

namespace gara_dei_thread
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Uri uriBeta = new Uri("beta.png", UriKind.Relative);
        public MainWindow()
        {
            InitializeComponent();
            ImageSource imm = new BitmapImage(uriBeta);
            imgBeta.Source = imm;
            Thread t1 = new Thread(new ThreadStart(muoviBeta));
            t1.Start();
        }

        public void muoviBeta()
        {
            for (int i = 100; i < 500; i += 50)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    imgBeta.Margin = new Thickness(i, 40, 0, 0);
                    
                }));
            }
            
           
        }
    }
}
