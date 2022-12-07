using Core.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Generators
{
    public class ObjectGenerator : IGenerator
    {
        public object Generate(Type type, GeneratorContext context)
        {
            var obj = CreateObject(type, context);
            return obj == null ? null : InitializeObject(obj, context);
        }

        public bool CanGenerate(Type type) => true;

        private object? CreateObject(Type type, GeneratorContext context)
        {
            var constructors = type.GetConstructors()
                .OrderByDescending(c => c.GetParameters().Length).ToList();

            foreach (var constructorInfo in constructors)
            {
                try
                {
                    var args = constructorInfo.GetParameters()
                        .Select(p => context.Faker.Create(p.ParameterType)).ToArray();
                    return constructorInfo.Invoke(args);
                }
                catch
                {
                    // ignored
                }
            }

            try
            {
                return Activator.CreateInstance(type);
            }
            catch
            {
                // ignored
            }

            return null;
        }

        private object InitializeObject(object obj, GeneratorContext context)
        {
            obj.GetType().GetProperties(BindingFlags.Public |
                                        BindingFlags.Instance)
                .Where(p => Equals(p.GetValue(obj), p.PropertyType.DefaultValue()))
                .ForEach(property =>
                {
                    try
                    {
                        property.SetValue(obj, context.Faker.Create(property.PropertyType));
                    }
                    catch
                    {
                        // ignored
                    }
                });

            obj.GetType().GetFields()
                .Where(f => !f.IsStatic)
                .Where(f => Equals(f.GetValue(obj), f.FieldType.DefaultValue()))
                .ForEach(field =>
                {
                    try
                    {
                        field.SetValue(obj, context.Faker.Create(field.FieldType));
                    }
                    catch
                    {
                        // ignored
                    }
                });

            return obj;
        }
    }
}
