using System;

namespace _06.ValidPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person negativeAge = new Person("Sto5ycho", "Peshev", -12);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
            catch (InvalidPersonNameException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
        }
    }
}
