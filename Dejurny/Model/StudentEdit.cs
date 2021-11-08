using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Dejurny
{
   public class StudentEdit
    {
        public List<Student> Students { get; set; } = new List<Student>();

        public void Add()
        {
            Students.Add(new Student { Name = "ФИО" });
            Save();
        }

        public StudentEdit()
        {
            Students.Add(new Student { Name = "Иван Иванов Иванович" });
            Load();
        }

        internal void Remove(Student Student)
        {
            Students.Remove(Student);
            Save();
        }

        internal void SaveStudent (Student original, Student copy)
        {
            int index = Students.IndexOf(original);
            Students[index] = copy;
            Save();
        }

        internal void MarkDate(Student student)
        {
            int index = Students.IndexOf(student);
            Students[index].DejurLog.Add(DateTime.Now);
            Save();
        }

        public void Save()
        {
            var json = JsonSerializer.Serialize(Students, typeof(List<Student>));
            File.WriteAllText("clients.db", json);
        }

        public void Load()
        {
            string file = "clients.db";
            if (!File.Exists(file) || new FileInfo(file).Length == 0)
            {
                Students = new List<Student>();
                return;
            }
            string json = File.ReadAllText(file);
            Students = (List<Student>)JsonSerializer.Deserialize(json, typeof(List<Student>));
        }
    }
}
