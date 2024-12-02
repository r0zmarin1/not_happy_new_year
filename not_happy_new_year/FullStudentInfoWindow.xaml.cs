using Spire.Doc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace not_happy_new_year
{
    /// <summary>
    /// Логика взаимодействия для FullStudentInfoWindow.xaml
    /// </summary>
    public partial class FullStudentInfoWindow : Window, INotifyPropertyChanged
    {
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

        public FullStudentInfoWindow(Student student)
        {
            InitializeComponent();
            Student = student;
            DataContext = this;
        }

        private void ExportToPDF(object sender, RoutedEventArgs e)
        {
            try
            {
                Document document = new Document();
                var section = document.AddSection();
                section.PageSetup.PageSize = new System.Drawing.SizeF(400, 400);

                var p = document.Sections[0].AddParagraph();
                p.AppendText($"Фамилия студента - {Student.LastName}");

                p = document.Sections[0].AddParagraph();
                p.AppendText($"Имя студента - {Student.FirstName}");

                p = document.Sections[0].AddParagraph();
                p.AppendText($"Отчество студента - {Student.Patronymic}");

                p = document.Sections[0].AddParagraph();
                p.AppendText($"Всего часов в кабинете:  {Student.AmountHoursInCabinet}"); 
                
                p = document.Sections[0].AddParagraph();
                p.AppendText($"Выполненные практические работы:  {Student.AmountCompletedPracticalWorks}"); 
                
                p = document.Sections[0].AddParagraph();
                p.AppendText($"Всего заданных вопросов: {Student.AmountAskedQuestions}");

                p = document.Sections[0].AddParagraph();
                p.AppendText($"Внештатные ситуации:");
                p = document.Sections[0].AddParagraph();
                foreach (var item in Student.EmergencySituations)
                {
                    p = document.Sections[0].AddParagraph();
                    p.AppendText(item.Title);
                    p = document.Sections[0].AddParagraph();
                    p.AppendText(item.Date.ToShortDateString()); 
                }

                document.SaveToFile("newFile.pdf", FileFormat.PDF);
                var info = new ProcessStartInfo("explorer.exe");
                info.Arguments = Environment.CurrentDirectory + "\\newFile.pdf";
                Process.Start(info);

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
