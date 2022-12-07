using Core.Generators;
using Core.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Faker : IFaker
    {
        private readonly IEnumerable<IGenerator> _generators;
        private readonly GeneratorContext _generatorContext;
        private readonly CycleChecker _cycleChecker = new();

        public Faker()
        {
            _generatorContext = new GeneratorContext(new Random(), this);
            _generators = new List<IGenerator> { new BoolGenerator(), new ByteGenerator(),
            new CharGenerator(), new DateTimeGenerator(), new DoubleGenerator(),
            new FloatGenerator(), new IntGenerator(), new LongGenerator(), new ShortGenerator(),
            new StringGenerator(), new ListGenerator()};
        }

        public T Create<T>() => (T)Create(typeof(T));

        public object Create(Type type)
        {
            if (!_cycleChecker.AddType(type))
                return null;

            var obj = _generators.FirstOrDefault(g => g.CanGenerate(type), new ObjectGenerator())
                .Generate(type, _generatorContext);

            _cycleChecker.RemoveType(type);
            return obj;
        }
    }
}
