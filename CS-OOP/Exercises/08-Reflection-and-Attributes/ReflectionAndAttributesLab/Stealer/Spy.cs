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
            sb.AppendLine($"Class under investigation: {classToInvestigate}");
            FieldInfo[] fields = type.GetFields((BindingFlags)60);
            foreach (var field in fields)
            {
                if (fieldsToInvestigate.Any(f => f == field.Name))
                {
                    sb.Append($"{field.Name} = {field.GetValue(new Hacker())}\n");
                }
            }
            return sb.ToString();

        }
        public string AnalyzeAccessModifiers(string classToInvestigate)
        {
            Type type = Type.GetType(classToInvestigate);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] publicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name} must be private");

            }
            foreach (var method in privateMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} must be public");
            }
            foreach (var method in publicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} must be private");
            }
            return sb.ToString();
        }
        public string RevealPrivateMethods(string classToInvestigate)
        {
            Type type = Type.GetType(classToInvestigate);
            MethodInfo[] privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class : {classToInvestigate}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");

            foreach (var method in privateMethods)
            {
                sb.AppendLine(method.Name);
            }
            return sb.ToString();
        }
        public string CollectGettersAndSetters(string classToInvestigate)
        {
            Type type = Type.GetType(classToInvestigate);
            MethodInfo[] privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            StringBuilder sb = new StringBuilder();

            foreach (var method in privateMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
            foreach (var method in privateMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString();
        }
    }
}