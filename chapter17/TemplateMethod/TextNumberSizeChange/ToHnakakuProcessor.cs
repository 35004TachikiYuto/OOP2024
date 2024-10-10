using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;
using static System.Net.Mime.MediaTypeNames;

namespace TextNumberSizeChange {
    class ToHnakakuProcessor : TextProcessor {

        private int _count;
        Dictionary<char, char> name = new Dictionary<char, char>(){
            {'0','0'},{'1','１'},{'2','２'},{'3','３'},{'4','４'},
            {'5','５'},{'6','６'},{'7','７'},{'8','８'},{'9','９'},};

        protected override void Initialize(string fname) {
            _count = 0;
        
        }

        protected override void Execute(string line) {
            string s = new string(line.Select(n => (name.ContainsKey(n) ? name[n] : n)).ToArray());

            Console.WriteLine(s);
        }

        protected override void Terminate() {
            Console.WriteLine("{0}行",_count);
            
        }
    }
}
