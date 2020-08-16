using OneForDotNet.Core;
using System;

namespace OneForDotNet.Console {
    class Program {
        static void Main(string[] args) {
            var s = CoreMethod.GetHome().Result;
            System.Console.ReadKey();
        }
    }
}
