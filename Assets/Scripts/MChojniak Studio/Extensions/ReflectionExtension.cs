namespace MChojniakStudio.Extensions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System.Linq.Expressions;
    using System.ComponentModel;

    public static class ReflectionExtension
    {

        static void Cast<To>(To value) { }

        public static bool IsAssignableTo(this Type from, Type to)
        {
            if (to == from)
                return true;

            if (to.IsAssignableFrom(from))
                return true;

            to = Nullable.GetUnderlyingType(to) ?? to;
            from = Nullable.GetUnderlyingType(from) ?? from;

            var fromObject = from.IsValueType ? Activator.CreateInstance(from) : null;

            if (!typeof(IConvertible).IsAssignableFrom(to) || !typeof(IConvertible).IsAssignableFrom(from))
                return false;

            try
            {
                // First Check
                var castGenericMethod = typeof(ReflectionExtension).GetMethod(nameof(Cast), System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
                var castMethod = castGenericMethod.MakeGenericMethod(to);
                castMethod.Invoke(null, new[] { fromObject });

                // Second Check
                TypeConverter converter = TypeDescriptor.GetConverter(from);
                bool canConvert = converter.CanConvertTo(to);

                // Third Check
                var param = Expression.Parameter(from, "x");
                var body = Expression.Convert(param, to);
                var lambda = Expression.Lambda(body, param).Compile();
            }
            catch
            {
                return false;
            }

            return true;
        }



    }
}
