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
        readonly Uri uriAerox = new Uri("aerox.jpg", UriKind.Relative);
        readonly Uri uriPanigale = new Uri("Panigale.jpg", UriKind.Relative);
        List<string> classifica = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            ImageSource immAerox = new BitmapImage(uriAerox);
            imgAerox.Source = immAerox;
            ImageSource imm = new BitmapImage(uriBeta);
            imgBeta.Source = imm;
            ImageSource immPanigale = new BitmapImage(uriPanigale);
            imgPanigale.Source = immPanigale;
            Thread t1 = new Thread(new ThreadStart(muoviBeta));
            t1.Start();
            Thread t2 = new Thread(new ThreadStart(MuoviAerox));
            t2.Start();
            Thread t3 = new Thread(new ThreadStart(MuoviPanigale));
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            for(int i = 0;i<classifica.Count;i++)
            {
                lstClassifica.Items.Add(classifica[i]);
            }
        }

        public void muoviBeta()
        {
            try
            {
                for (int i = 100; i < 500; i += 50)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        imgBeta.Margin = new Thickness(i, 40, 0, 0);

                    }));
                }
                classifica.Add("Beta");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void MuoviAerox()
        {
            try
            {
                for (int i = 100; i < 500; i += 50)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        imgAerox.Margin = new Thickness(i, 150, 0, 0);

                    }));
                }
                classifica.Add("Aerox");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void MuoviPanigale()
        {
            try
            {
                for (int i = 100; i < 500; i += 50)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        imgPanigale.Margin = new Thickness(i, 250, 0, 0);

                    }));
                }
                classifica.Add("Panigale");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

  
    }
}
