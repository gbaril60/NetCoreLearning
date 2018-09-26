using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace StandardLib.Extensions
{
    public static class ReflectionExtensions
    {
        public static void ForEachProperty<T>(this T obj, Action<PropertyDescriptor> method)
        {
            var props = TypeDescriptor.GetProperties(obj);

            if (props.Count == 0) return;

            foreach (PropertyDescriptor prop in props)
            {
                method(prop);
            }
        }
        public static void ForEachProperty(this Type type, Action<PropertyDescriptor> method)
        {
            var props = TypeDescriptor.GetProperties(type);

            foreach (PropertyDescriptor prop in props)
            {
                method(prop);
            }
        }
        public static string GetPropertyName<TObj, TProp>(this Expression<Func<TObj, TProp>> source)
        {
            return GetMemberName(source);
        }
        public static string GetMemberName<TIn, TOut>(Expression<Func<TIn, TOut>> e)
        {
            MemberExpression exp = null;

            if (e is UnaryExpression)
            {
                var op = ((UnaryExpression)e.Body).Operand;
                exp = ((MemberExpression)op);
            }
            else if (e.Body is MemberExpression)
            {
                exp = ((MemberExpression)e.Body);
            }
            else
            {
                if (e.Body is UnaryExpression)
                {
                    var tempExp = (UnaryExpression)e.Body;
                    exp = ((MemberExpression)tempExp.Operand);
                }
            }

            return exp.Member.Name;
        }
    }
}
