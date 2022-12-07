using Core.Generators;
using Core.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core
{

    public class Faker : IFaker
    {
        private const string DllName = "Modules";
        private readonly string[] _generatorsFromDllNames = { "Modules.CharGenerator", "Modules.ShortGenerator" };
        private readonly IEnumerable<IGenerator> _generators;
        private readonly GeneratorContext _generatorContext;
        private readonly CycleChecker _cycleChecker = new();

        public Faker()
        {
            _generatorContext = new GeneratorContext(new Random(), this);
            _generators = new List<IGenerator> { new BoolGenerator(), new ByteGenerator(),
            new DateTimeGenerator(), new DoubleGenerator(),
            new FloatGenerator(), new IntGenerator(), new LongGenerator(),
            new StringGenerator(), new ListGenerator()};
        }

        public T Create<T>() => (T)Create(typeof(T));

        public object Create(Type type)
        {
            if (!_cycleChecker.AddType(type))
                return null;
            object obj;
            try
            {
                obj = GenerateViaDll(type);
            }
            catch (Exception)
            {
                obj = null;
            }
            if (obj == null)
            {
                obj = _generators.FirstOrDefault(g => g.CanGenerate(type), new ObjectGenerator())
                    .Generate(type, _generatorContext);
            }
            _cycleChecker.RemoveType(type);
            return obj;
        }

        public object GenerateViaDll(Type t)
        {
            object result = null;
            var assembly = Assembly.LoadFrom(DllName);

            foreach (var generatorName in _generatorsFromDllNames)
            {
                var genType = assembly.GetType(generatorName);

                var methodInfoCanGenerate = genType?.GetMethod("CanGenerate", BindingFlags.NonPublic | BindingFlags.Static);

                var param = new object[] { t };
                if (methodInfoCanGenerate is not null && (bool?)methodInfoCanGenerate.Invoke(null, param) == true)
                {
                    var methodInfoGenerate = genType.GetMethod("Generate", BindingFlags.NonPublic | BindingFlags.Static);
                    result = methodInfoGenerate?.Invoke(null, param);
                }
            }

            return result;
        }
    }
}
