using Core.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Generators
{
    public class StringGenerator : IGenerator
    {
        private readonly Char[] _chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();
        public object Generate(Type type, GeneratorContext context)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < context.Random.Next(5, 100); i++)
                sb.Append(_chars[context.Random.Next(0, _chars.Length)]);
            return sb.ToString();
        }
        public bool CanGenerate(Type type) => type == typeof(string);
    }
}
