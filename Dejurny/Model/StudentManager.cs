using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Linq;

namespace Dejurny
{
    public class StudentManager
    {
        private const string path = "students.db";

        public List<Student> Students { get; set; } = new List<Student>();

        public StudentManager()
        {
            LoadStudentList();
        }

        

        internal List<Student> GetDejur()
        {
            Student firstStudent;
            Student secondStudent;

            Random rand = new Random();

            int totalDejurs = 0;
            foreach (Student student in Students)
                totalDejurs += student.DejurLog.Count;
            double avg = (double)totalDejurs / Students.Count;

            List<Student> dejurStudents = new List<Student>();
            foreach (Student student in Students)
                if (student.DejurLog.Count <= avg)
                    dejurStudents.Add(student);

            firstStudent = dejurStudents[rand.Next(0, dejurStudents.Count - 1)];
            dejurStudents.Remove(firstStudent);

            if (dejurStudents.Count == 0)
                dejurStudents = Students.Where(s => s != firstStudent).ToList();
            
            secondStudent = dejurStudents[rand.Next(0, dejurStudents.Count - 1)];

            return new List<Student>(new[] { firstStudent, secondStudent });
        }

        internal void SetDejur(Student firstStudent, Student secondStudent) //1
        {
            firstStudent.DejurLog.Add(DateTime.Today);
            secondStudent.DejurLog.Add(DateTime.Today);
            SaveStudentList();
        }

        

        public void SaveStudentList()
        {
            var json = JsonSerializer.Serialize(Students, typeof(List<Student>));
            File.WriteAllText(path, json);
        }

        public void LoadStudentList()
        {
            string file = path;
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
