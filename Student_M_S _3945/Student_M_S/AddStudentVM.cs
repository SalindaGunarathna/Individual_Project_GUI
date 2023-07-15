using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Collections.ObjectModel;

namespace Student_M_S
{
    public partial class AddStudentVM : ObservableObject
    {

        [ObservableProperty]
        public string firstname;


        [ObservableProperty]
        public string lastname ;

        [ObservableProperty]
        public string id;

        [ObservableProperty]
        public DateOnly dateofbirth;

        [ObservableProperty]
        public double gpa;


        [ObservableProperty]
        public ObservableCollection<int> creadits = new ObservableCollection<int>
        {
           0, 1, 2, 3,4
        };




       





        [ObservableProperty]
        public BitmapImage selectedImage;



        public AddStudentVM (Student u)
        {
            User = u;

            firstname = User.FirstName;
            lastname = User.LastName;
            id = User.Id;

            dateofbirth = User.DateofBirth;
             gpa = User.GPA;
            selectedImage = User.Image;

           

        }
        public AddStudentVM()
        {

        }


        //get image 
        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                selectedImage = new BitmapImage(new Uri(dialog.FileName));

                MessageBox.Show("Imgae successfuly uploded!", "successfull");
            }
        }






        public Student User { get; private set; }
        public Action CloseAction { get; internal set; }

        [RelayCommand]
        public void Save()
        {



            if (gpa < 0 || gpa > 4)
            {
                MessageBox.Show("GPA value must be between 0 and 4.", "Error");
                return;
            }
            if (User == null)
            {

                User = new Student()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Id = id,
                    DateofBirth = dateofbirth,
                    GPA = gpa,
                    Image = selectedImage


                    
                   

                };

                


            }
            else
            {

                User.FirstName = firstname;
                User.LastName = lastname;
                User.Id = id;
               
                
                User.DateofBirth = dateofbirth;
                User.GPA = gpa;
                User.Image = selectedImage;



            }

            if (User.FirstName != null)
            {

                CloseAction();
            }
            Application.Current.MainWindow.Show();


        }


        [RelayCommand]
        private void ColoseButton()
        {



            if (User == null)
            {

                User = new Student()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Id = id,
                    DateofBirth = dateofbirth,
                    GPA = gpa,
                    Image = selectedImage





                };

            }





                CloseAction();
            
            Application.Current.MainWindow.Show();

        }
    }
}
