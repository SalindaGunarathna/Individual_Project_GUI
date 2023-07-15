using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;

namespace Student_M_S
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> students;
        [ObservableProperty]
        public Student selectedStudent = null;


        

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddStudentVM();
          
            AddStudentWindow window = new AddStudentWindow(vm);
            window.ShowDialog();


            if(vm.User.FirstName==null)
            {
                return;
            }
            else
            {
                students.Add(vm.User);
            }

        }

        [RelayCommand]
        public void Delete()
        {
            if (selectedStudent != null)
            {
                string name = selectedStudent.FirstName;
                students.Remove(selectedStudent);
                MessageBox.Show($"{name} is Deleted successfuly.", "Delete \a ");

            }
            else
            {
                MessageBox.Show("Plese Select Student before Delete.", "Error");


            }
        }
        [RelayCommand]
        public void EditStudentDetails()
        {
            if (selectedStudent != null)
            {
                var vm = new AddStudentVM(selectedStudent);
               
                var window = new AddStudentWindow(vm);

                window.ShowDialog();

                int index = students.IndexOf(selectedStudent);
                students.RemoveAt(index);
                students.Insert(index, vm.User);

                



            }
            else
            {
                MessageBox.Show("Please Select the student", "Warning!");
            }
        }



        [RelayCommand]
        public void messeag()
        {

            MessageBox.Show($"{selectedStudent.FirstName} GPA value is incorrect", "Error");
        }

        public MainWindowVM()
        {
            students = new ObservableCollection<Student>();
            BitmapImage image1 = new BitmapImage(new Uri("/Profile/1.png", UriKind.Relative));
            students.Add(new Student("Jhone", "bell","EG/3912",new  DateOnly(2012,02,02),3.8,image1));

            BitmapImage image2 = new BitmapImage(new Uri("/Profile/1.png", UriKind.Relative));
            students.Add(new Student("Mok", "fanando", "EG/5656", new DateOnly(2012, 05, 02), 3, image2));

            BitmapImage image3 = new BitmapImage(new Uri("/Profile/3.png", UriKind.Relative));
            students.Add(new Student("Asela", "Nuwan", "EG/3852", new DateOnly(2012, 07, 08), 3.2, image3));

            BitmapImage image4 = new BitmapImage(new Uri("/Profile/1.png", UriKind.Relative));
            students.Add(new Student("Alan", "Max", "EG/3968", new DateOnly(2012, 12, 07), 3.5, image4));





        }
    }
}
