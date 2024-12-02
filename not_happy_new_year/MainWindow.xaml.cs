
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace not_happy_new_year
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public List<Student> Students { get; set; }
        public List<EmergencySituations> EmergencySituations { get; set; }


        public Student Student 
        { 
            get => student;
            set 
            {
                student = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Student)));
            }
        }
        private Student student;

        private int lastIdStudent = 1;


        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            EmergencySituations = new List<EmergencySituations>();
            EmergencySituations.Add(new EmergencySituations { Id = 1, Title = "Устроил короткое замыкание", Date = DateTime.Now });
            EmergencySituations.Add(new EmergencySituations { Id = 2, Title = "Устроил оргию", Date = DateTime.Now });
            EmergencySituations.Add(new EmergencySituations { Id = 3, Title = "Украл мать", Date = DateTime.Now });
            EmergencySituations.Add(new EmergencySituations { Id = 4, Title = "Не поделился кодом с одногруппником", Date = DateTime.Now });
            EmergencySituations.Add(new EmergencySituations { Id = 5, Title = "Сломал стул стоя", Date = DateTime.Now });
            EmergencySituations.Add(new EmergencySituations { Id = 6, Title = "Взломал госуслуги", Date = DateTime.Now });

            Students = new List<Student>();
            Students.Add(new Student
            {
                Id = lastIdStudent,
                LastName = "Котов",
                FirstName = "Владислав",
                Patronymic = "-",
                AmountHoursInCabinet = -100,
                AmountCompletedPracticalWorks = -1,
                AmountAskedQuestions = 200,
                EmergencySituations = new List<EmergencySituations> { EmergencySituations[2] }
            });
            DataContext = this;
        }
        
        private void CheckInfo(object sender, RoutedEventArgs e)
        {
            FullStudentInfoWindow fullStudentInfoWindow = new FullStudentInfoWindow(Student);
            fullStudentInfoWindow.Show();

        }

        private void EditStudent(object sender, RoutedEventArgs e)
        {
            EditStudentWindow editStudentWindow =  new EditStudentWindow(Student);
            editStudentWindow.Show();
        }
    }
}