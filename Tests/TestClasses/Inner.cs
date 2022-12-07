using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.TestClasses
{
    public class InnerClass
    {
        public int X { get; set; }
        public InnerClass Inner { get; set; }

        public InnerClass(int x, InnerClass inner)
        {
            X = x;
            Inner = inner;
        }
    }
}
