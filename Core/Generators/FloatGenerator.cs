using Core.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Generators
{
    public class FloatGenerator : IGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(float);

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            return context.Random.NextSingle();
        }
    }
}
