using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    public class ShortGenerator
    {
        private static object Generate(Type type)
        {
            var random = new Random();
            return (short)random.Next(short.MinValue, short.MaxValue);
        }

        private static bool CanGenerate(Type type) => type ==typeof(short);
    }
}
