using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace not_happy_new_year
{
    /// <summary>
    /// Логика взаимодействия для EditStudentWindow.xaml
    /// </summary>
    public partial class EditStudentWindow : Window, INotifyPropertyChanged
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

        public event PropertyChangedEventHandler? PropertyChanged;
        public EditStudentWindow(Student student)
        {
            InitializeComponent();
            Student = student;
            DataContext = this;
        }

        public void Save(object sender, RoutedEventArgs e)
        {
            SaveStudent(student);
        }

        public void SaveStudent(Student student)
        {
            var stu = Students.FirstOrDefault(s => s.Id == student.Id);
            stu.Id = student.Id;
            stu.LastName = student.LastName;
            stu.FirstName = student.FirstName;
            stu.Patronymic = student.Patronymic;
            stu.AmountHoursInCabinet = student.AmountHoursInCabinet;
            stu.AmountCompletedPracticalWorks = student.AmountCompletedPracticalWorks;
            stu.AmountAskedQuestions = student.AmountAskedQuestions;
            stu.EmergencySituations = student.EmergencySituations;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Student)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Students)));
        }
    }
}
