using ValidationAttributes.Attributes;
namespace ValidationAttributes
{
    public class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        [MyRequired]
        public string Name { get; private set; }
        [MyRange(12,90)]
        public int Age { get; private set; }
    }
}