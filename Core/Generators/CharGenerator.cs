using Core.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Generators
{
    public class CharGenerator : IGenerator
    {
        private readonly char[] _chars = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        public object Generate(Type type, GeneratorContext context)
        {
            return _chars[context.Random.Next(0, _chars.Length)];
        }

        public bool CanGenerate(Type type) => type == typeof(char);
    }
}
