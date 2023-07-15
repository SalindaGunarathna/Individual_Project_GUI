using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Student_M_S
{
    public  class Student
    {
       
        

        public string  ImgURL {


            get
            {
                return $"/Profile/{Image}";

            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public DateOnly DateofBirth { get; set; }
        public BitmapImage Image { get; set; }

        public double GPA { get; set; }

        

        public Student(string fristName, string lastName, string id, DateOnly dateOnly, double gpa,BitmapImage image )
        {
            FirstName = fristName;
            LastName = lastName;
            Id  = id;
            DateofBirth = dateOnly;
           
            GPA = gpa;
            Image = image;
        }
       
        public Student()
        {
            
        }   
    }
}
