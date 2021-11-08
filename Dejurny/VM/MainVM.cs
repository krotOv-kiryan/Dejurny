using Mvvm1125;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;

namespace Dejurny
{
   public class MainVM : MvvmNotify
    {
        public ObservableCollection<Student> Students { get; set; }
        public Student SelectedStudent { get => model.SelectedStudent; set => model.SelectedStudent = value; }
        Model model;
        public MvvmCommand Dejur { get; set; }

        public Page CurrentPage { get; set; }

        public MainVM()
        {
            model = new Model();
            Pages.SetModel(model);
            CurrentPage = Pages.GetPageByType(PageType.DejurList);
            Pages.CurrentPageChanged += PageContainer_CurrentPageChanged;
            Pages.SetModel(model);
            //Application.Current.Exit += (o, e) => model.Save();
        }

        public void SetModel(Model model)
        {
            this.model = model;
            Dejur = new MvvmCommand(() => Pages.ChangePageTo(PageType.DejurList), () => true);
            //model.SelectedStudentChanged += Model_SelectedStudentChanged;
            model.StudentsChanged += Model_StudentsChanged;
             Dejur = new MvvmCommand(
                () => model.Dejur(),
                () => Students.Count >= 2);

        }





        void PageContainer_CurrentPageChanged(object sender, PageType e)
        {
            CurrentPage = Pages.GetPageByType(e);
            NotifyPropertyChanged("CurrentPage");
        }
        private void Model_StudentsChanged(object sender, EventArgs e)
        {
            Students = new ObservableCollection<Student>(model.GetStudent());
            NotifyPropertyChanged("Students");
        }
    }
}
