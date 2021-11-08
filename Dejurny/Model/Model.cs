using Mvvm1125;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Dejurny
{
  public class Model
    {

        StudentEdit studentEdit = new StudentEdit();
        Student selectedStudent;

    public event EventHandler StudentsChanged;
    public event EventHandler SelectedStudentChanged;
    public Student SelectedStudent
        {
        get => selectedStudent;
        set { selectedStudent = value; SelectedStudentChanged?.Invoke(this, null); }
    }


    public List<Student> GetStudent()
    {
        return studentEdit.Students;
    }

    internal void CreateStudent()
    {
            studentEdit.Add();
            StudentsChanged?.Invoke(this, null);
    }

    internal void RemoveStudent(Student student)
    {
            studentEdit.Remove(student);
            StudentsChanged?.Invoke(this, null);
    }

    internal void SaveStudent(Student original, Student copy)
    {
            studentEdit.SaveStudent(original, copy);
            StudentsChanged?.Invoke(this, null);
    }


        internal void Dejur()
        {
            Pages.ChangePageTo(PageType.DejurList);
           // OnDejurChanged?.Invoke(this, null);
        }

      /*  internal void SetDejur(Student firstStudent, Student secondStudent) // 2
        {
            Pages.ChangePageTo(PageType.DejurList);
            //studentManager.SetDuty(firstStudent, secondStudent);
        }*/
    }
}
