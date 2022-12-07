using Core.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Generators
{
    public class DoubleGenerator : IGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(double);
        

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return context.Random.NextDouble();
        }
    }
}
