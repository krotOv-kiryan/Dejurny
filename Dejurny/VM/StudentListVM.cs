using Mvvm1125;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Dejurny
{
    public class StudentListVM : MvvmNotify, IPageVM //INotifyPropertyChanged,
    {
        //public event PropertyChangedEventHandler PropertyChanged;
        Model model;

        public ObservableCollection<Student> Students { get; set; }
        public MvvmCommand CreateStudent { get; set; }
        public MvvmCommand RemoveStudent { get; set; }
        public MvvmCommand SaveStudent { get; set; }
        public MvvmCommand DejurLog { get; set; }
        public MvvmCommand MarkDate { get; set; }
        public MvvmCommand Dejur { get; set; }

        public Student SelectedStudent
        {
            get => model.SelectedStudent;
            set
            {
                model.SelectedStudent = value;
                if (value != null)
                    SelectedStudentCopy = new Student { Name = value.Name, DejurLog = value.DejurLog };
                NotifyPropertyChanged("SelectedStudent");
                NotifyPropertyChanged("SelectedStudentCopy");
            }

        }
        public Student SelectedStudentCopy { get; set; }

        public void SetModel(Model model)
        {
            this.model = model;
            Students = new ObservableCollection<Student>(model.GetStudent());
            DejurLog = new MvvmCommand(
                () => Pages.ChangePageTo(PageType.DejurList),
                () => SelectedStudent != null);
            CreateStudent = new MvvmCommand(
                () => model.CreateStudent(),
                () => true);
            RemoveStudent = new MvvmCommand(
                () => model.RemoveStudent(SelectedStudent),
                () => SelectedStudent != null);
            SaveStudent = new MvvmCommand(
                () => model.SaveStudent(SelectedStudent, SelectedStudentCopy),
                () => SelectedStudent != null);
            DejurLog = new MvvmCommand(
                () =>
                {
                    model.SelectedStudent = SelectedStudent;
                    Pages.ChangePageTo(PageType.DejurList);
                },
                () => SelectedStudent != null);
            /*MarkDate = new MvvmCommand(
                () => model.MarkDate(SelectedStudent),
                () => SelectedStudent != null);*/
            Dejur = new MvvmCommand(
               () =>
               {
                   Pages.ChangePageTo(PageType.DejurList);
               },
               () => true);

            model.StudentsChanged += Model_StudentsChanged;
        }

        private void Model_StudentsChanged(object sender, System.EventArgs e)
        {
            Students = new ObservableCollection<Student>(model.GetStudent());
            NotifyPropertyChanged("Students");
        }


    }
}
