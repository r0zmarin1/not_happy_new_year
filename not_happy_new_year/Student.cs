using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace not_happy_new_year
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public string Patronymic { get; set; } 
        public int AmountHoursInCabinet { get; set; }
        public int AmountCompletedPracticalWorks { get; set; }
        public int AmountAskedQuestions { get; set; }
        public List<EmergencySituations> EmergencySituations { get; set; }

    }

    
}
