using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using XmlLib.Model;
using Xunit;

namespace XmlLib
{
    public class Class1
    {
        private Xunit.Abstractions.ITestOutputHelper _outputHelper;

        public Class1(Xunit.Abstractions.ITestOutputHelper iTestOutputHelper)
        {
            this._outputHelper = iTestOutputHelper;
        }

        [Fact]
        public void Write()
        {
            var items = new List<Model.Student>();
            for (int i = 1; i <= 10; i++)
            {
                items.Add(new Student()
                {
                    SId = i,
                    SName = $"名字_{i}",
                    Class = new StuClass()
                    {
                        CId = i,
                        CName = $"班级_{i}"
                    }
                });
            }
            var path = Path.GetFullPath($"../../Xml/Test1.xml");
            Operator.Write(path,items);
        }

        [Fact]
        public void ReadFile()
        {
            var path = Path.GetFullPath($"../../Xml/Test1.xml");
            List<Model.Student> read = Operator.ReadFromPath<List<Model.Student>>(path);
            _outputHelper.WriteLine(read[2].SName);
        }

        [Fact]
        public void ReadStr()
        {
            var path = Path.GetFullPath($"../../Xml/Test1.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            var xmlStr = doc.OuterXml;
            List<Model.Student> read = Operator.ReadFromString<List<Model.Student>>(xmlStr);
            _outputHelper.WriteLine(read[3].SName);
        }
    }
}
