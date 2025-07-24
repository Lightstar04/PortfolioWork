using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows;

namespace UniversityTrackerAPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient _client;
        private const string BASE_URL = "http://universities.hipolabs.com/search?country=";

        public MainWindow()
        {
            InitializeComponent();

            _client = new HttpClient();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var search = SearchInput.Text.Trim();

            var url = $"{BASE_URL}{search}";
            var message = new HttpRequestMessage(HttpMethod.Get, url)
            {
                Content = new StringContent("", Encoding.UTF8, "application/json")
            };

            var response = _client.Send(message);

            var streamReader = new StreamReader(response.Content.ReadAsStream());
            var result = JsonConvert.DeserializeObject<List<University>>(streamReader.ReadToEnd());

            DataList.ItemsSource = null;
            DataList.ItemsSource = result;
        }
    }
}