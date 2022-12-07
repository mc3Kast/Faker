using Core;
using Tests.TestClasses;

namespace Tests
{
    public class Tests
    {
        private Faker _faker;

        [SetUp]
        public void Setup()
        {
            _faker = new Faker();
        }
        private static IEnumerable<TestCaseData> _dataTypes = new List<TestCaseData>()
    {
        new(typeof(bool)), new(typeof(byte)), new(typeof(char)), new(typeof(DateTime)),
        new(typeof(double)), new(typeof(float)), new(typeof(int)), new(typeof(List<int>)),
        new(typeof(List<List<int>>)), new(typeof(long)), new(typeof(string)), new(typeof(short))
    };

        [Test]
        [TestCaseSource(nameof(_dataTypes))]
        public void Faker_SimpleType_ReturnNotDefaultValue(Type type)
        {
            Assert.That(_faker.Create(type), Is.Not.EqualTo(type.DefaultValue()));
        }

        [Test]
        public void Faker_ComplexType_ReturnAllMembersNotDefault()
        {
            var myObject = _faker.Create<A>();
            Assert.Multiple(() =>
            {
                Assert.That(myObject.Number, Is.Not.EqualTo(myObject.Number.GetType().DefaultValue()));
                Assert.That(myObject.Text, Is.Not.EqualTo(myObject.Text.GetType().DefaultValue()));
                Assert.That(myObject.Check, Is.Not.EqualTo(myObject.Check.GetType().DefaultValue()));
                Assert.That(A.Static, Is.EqualTo(0));
            });
        }

        [Test]
        public void Faker_Struct_ReturnNotNullObject()
        {
            var myStruct = _faker.Create<MyStruct>();
            Assert.Multiple(() =>
            {
                Assert.That(myStruct.X, Is.Not.EqualTo(myStruct.X.GetType().DefaultValue()));
                Assert.That(myStruct.Y, Is.Not.EqualTo(myStruct.Y.GetType().DefaultValue()));
            });
        }

        [Test]
        public void Faker_ClassWithManyConstructors_ReturnUsingBiggestConstructor()
        {
            var myObject = _faker.Create<ManyConstructors>();
            Assert.That(myObject.X, Is.EqualTo(myObject.Y));
        }

        [Test]
        public void Faker_CycleClass_ReturnNotException()
        {
            Assert.DoesNotThrow(() => _faker.Create<InnerClass>());
        }
    }
}