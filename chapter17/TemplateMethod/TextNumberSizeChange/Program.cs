﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;

namespace TextNumberSizeChange {
    internal class Program {
        static void Main(string[] args) {
            //TextProcessor.Run<ToHnakakuProcessor>(args[0]);

            var processor = new Framework.TextFileProcessor(new ToHnakakuProcessor());
            processor.Run(args[0]);
        }
    }
}
