using Core.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Generators
{
    public class DateTimeGenerator : IGenerator
    {
        public object Generate(Type type, GeneratorContext context)
        {
            return new DateTime(context.Random.Next());
        }
        public bool CanGenerate(Type type) => type == typeof(DateTime);
    }
}
