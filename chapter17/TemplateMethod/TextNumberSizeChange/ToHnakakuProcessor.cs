using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;
using TextNumberSizeChange.Framework;
using static System.Net.Mime.MediaTypeNames;

namespace TextNumberSizeChange {
    class ToHnakakuProcessor : ITextFileService {

        private int _count;
        Dictionary<char, char> name = new Dictionary<char, char>(){
            {'０','0'},{'１','1'},{'２','2'},{'３','3'},{'４','4'},
            {'５','5'},{'６','6'},{'７','7'},{'８','8'},{'９','9'},
        };

        public void Initialize(string fname) {
            _count = 0;
        
        }

        public void Execute(string line) {
            string s = new string(line.Select(n => (name.ContainsKey(n) ? name[n] : n)).ToArray());

            Console.WriteLine(s);
        }

        public void Terminate() {
            Console.WriteLine("{0}行",_count);
            
        }

       
    }
}
