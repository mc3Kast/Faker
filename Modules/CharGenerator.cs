using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    public class CharGenerator
    {
        private static object Generate(Type type)
        {
            var random = new Random();
            return (char)random.Next();
        }

        private static bool CanGenerate(Type type) => type == typeof(char);
    }
}
