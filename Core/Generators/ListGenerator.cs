using Core.Intefaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Generators
{
    public class ListGenerator : IGenerator
    {
        public object Generate(Type type, GeneratorContext context)
        {
            var length = context.Random.Next(3, 5);
            var list = Activator.CreateInstance(type) as IList;
            if (list != null)
                for (var i = 0; i < length; i++)
                    list.Add(context.Faker.Create(type.GetGenericArguments()[0]));
            return list;
        }
        public bool CanGenerate(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
        }
    }
}
