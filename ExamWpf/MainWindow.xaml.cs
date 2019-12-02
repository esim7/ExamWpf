using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace ExamWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Rootobject> StarWarsObjects { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            StarWarsObjects = new List<Rootobject>();
        }

        private void Download_Click(object sender, RoutedEventArgs e)
        {
            var Url = @"https://swapi.co/api/people/" + textBox_PageNumber.Text;
            try
            {
                using (WebClient client = new WebClient())
                {

                    var json = client.DownloadString(Url);
                    var result = JsonConvert.DeserializeObject<Rootobject>(json);
                    if (StarWarsObjects.Count == 0)
                    {
                        StarWarsObjects.Add(result);
                    }
                    else
                    {
                        lvItems.ItemsSource = null;
                        StarWarsObjects.RemoveAt(0);
                        StarWarsObjects.Add(result);
                    }
                    lvItems.ItemsSource = StarWarsObjects;
                }
            }
            catch
            {
                MessageBox.Show("Неверный номер страницы");
            }
        }
    }
}
