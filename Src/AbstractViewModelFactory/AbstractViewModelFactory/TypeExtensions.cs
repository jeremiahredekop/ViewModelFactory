using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GeniusCode.Components.Mvvm
{
    internal static class TypeExtensions
    {

        public static List<T> GetCustomAttributes<T>(this MemberInfo input, bool includeInheritance)
            where T : Attribute
        {
            return input.GetCustomAttributes(typeof(T), includeInheritance).Cast<T>().ToList(); 
        }


        public static object CreateObject(this Type input)
        {
            return Activator.CreateInstance(input);
        }


        public static T CreateAndCastObject<T>(this Type input)
        {
            return (T)Activator.CreateInstance(input);
        }
    }
}
