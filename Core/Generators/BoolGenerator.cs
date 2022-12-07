using Core.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Generators
{
    public class BoolGenerator : IGenerator
    {
        public object Generate(Type type, GeneratorContext context) => true;
        public bool CanGenerate(Type type) => type == typeof(bool);
    }
}
