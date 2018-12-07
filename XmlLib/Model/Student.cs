using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlLib.Model
{
    public class Student
    {
        public int SId { get; set; }

        public string SName { get; set; }

        public StuClass Class { get; set; }
    }
}
