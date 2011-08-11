using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

// This code is property of GeniusCode, LLC
// Licensed under MS-PL

namespace System
{

    public static class TypeExtensions
    {

        public static List<T> GetCustomAttributes<T>(this MemberInfo input, bool includeInheritance)
            where T : Attribute
        {
            return input.GetCustomAttributes(typeof(T), includeInheritance).Cast<T>().ToList(); //.ConvertToList<T>();
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
