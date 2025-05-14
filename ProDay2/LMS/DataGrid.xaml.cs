using System.Windows;

namespace LMS
{
    /// <summary>
    /// Interaction logic for DataGrid.xaml
    /// </summary>
    public partial class DataGrid : Window
    {
        public DataGrid()
        {
            InitializeComponent();

            List<Person> people = new List<Person>()
            {
                new Person(1, "John", "1234"),
                new Person(2, "Tony", "1234"),
                new Person(3, "Richard", "1234"),
                new Person(4, "Steven", "1234"),
            };

            personGrid.ItemsSource = people;
        }
    }

    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public Person(int id, string name, string phoneNumber)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}
