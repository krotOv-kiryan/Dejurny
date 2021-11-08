using Mvvm1125;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Dejurny
{
    public class DejurListVM : MvvmNotify, IPageVM
    {
        Model model;
        public ObservableCollection<DateTime> Dejurs { get; set; } = new ObservableCollection<DateTime>();
        public string Title { get; set; }
        public MvvmCommand Back { get; set; }
        public MvvmCommand Dejur { get; set; }

        public void SetModel(Model model)
        {
            this.model = model;

            Back = new MvvmCommand(() => Pages.ChangePageTo(PageType.DejurList), () => true);
            model.SelectedStudentChanged += Model_SelectedStudentChanged;
            //Dejur = new MvvmCommand(
            //    () =>
            //    {
            //        Pages.ChangePageTo(PageType.DejurList);
            //    },
            //    () => true);
        }

        private void Model_SelectedStudentChanged(object sender, EventArgs e)
        {
            if (model.SelectedStudent != null)
            {
                Title = $"История дежурств студента {model.SelectedStudent.Name}";
                NotifyPropertyChanged("Title");
                Dejurs = new ObservableCollection<DateTime>(model.SelectedStudent.DejurLog);
                NotifyPropertyChanged("Dejurs");
            }
        }
        private void Model_OnDejurChanged(object sender, EventArgs e)
        {
            //var dejurs = model.GetDejur();
            //FirstStudent = dejurs.Item1;
            //SecondStudent = dejurs.Item2;
            NotifyPropertyChanged("FirstStudent");
            NotifyPropertyChanged("SecondStudent");
        }
    }
}

