using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public Spy()
        {
            
        }
        public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
        {
            StringBuilder sb = new StringBuilder();
            Type type = Type.GetType(classToInvestigate);
            sb.Append($"Class under investigation: {classToInvestigate}\n");
            FieldInfo[] fields = type.GetFields((BindingFlags)60);
            foreach (var field in fields)
            {
                if(fieldsToInvestigate.Any(f => f == field.Name))
                {
                    sb.Append($"{field.Name} = {field.GetValue(new Hacker())}\n");
                }
            }
            return sb.ToString();

        }
    }
}