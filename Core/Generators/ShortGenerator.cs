using Core.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Int16;

namespace Core.Generators
{
    public class ShortGenerator : IGenerator
    {
        public object Generate(Type type, GeneratorContext context)
        {
            return (short)context.Random.Next(1, MaxValue);
        }
        public bool CanGenerate(Type type) => type == typeof(short);
    }
}
