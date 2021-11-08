using System;
using System.Collections.Generic;
using System.Text;

namespace Dejurny
{
    public class Student
    {
        public string Name { get; set; }
        public List<DateTime> DejurLog { get; set; } = new List<DateTime>();
        public string BirthDay { get; set; }
       // public object DejurList { get; internal set; }
    }
}
