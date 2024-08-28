using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1_1("employee.xml");

            // これは確認用
            Console.WriteLine(File.ReadAllText("employee.xml"));
            Console.WriteLine();

           Exercise1_2("employees.xml");
            Exercise1_3("employees.xml");
            Console.WriteLine();

            Exercise1_4("employees.json");

            // これは確認用
            Console.WriteLine(File.ReadAllText("employees.json"));
        }

        private static void Exercise1_1(string outfile) {
#if true
            var employee = new Employee {
                Id = 1,
                Name = "橋本陸",
                HireDate = new DateTime(2024,08,27)
            };

            //シリアル化
            using (var writer = XmlWriter.Create(outfile)) {
                var serializer = new XmlSerializer(employee.GetType());
                serializer.Serialize(writer, employee);
            }
#else
            using (var reader = XmlReader.Create(outfile)) {
                var serializer = new XmlSerializer(typeof(Employee));
                var employee = serializer.Deserialize(reader)as Employee;
                Console.WriteLine(employee);
            }
#endif

        }

        private static void Exercise1_2(string outfile) {
            var emps = new Employee[] {
                new Employee {
                    Id=123,
                    Name = "出井　秀行",
                    HireDate=new DateTime(2001,5,10)
                },
                new Employee {
                    Id = 139,
                    Name = "大橋　孝仁",
                    HireDate = new DateTime(2004,12,1)
                },
            };
            using (var writer = XmlWriter.Create(outfile)) {
                var serializer = new DataContractSerializer(emps.GetType());
                serializer.WriteObject(writer, emps);
            }
        }
        private static void Exercise1_3(string file) {
            using (var reader = XmlReader.Create(file)) {
                var serializer = new DataContractSerializer(typeof(Employee[]));
                var emps = serializer.ReadObject(reader) as Employee[];
                foreach (var emp in emps) {
                    Console.WriteLine("{0},{1},{2}", emp.Id, emp.Name, emp.HireDate);
                }
            }
        }

        private static void Exercise1_4(string file) {
        }
    }
}
