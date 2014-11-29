using System;
using System.Linq.Expressions;

namespace Library.Common.Extensions
{
    public static class StaticReflection
    {
        public static string GetMemberName<T>(
            this T instance,
            Expression<Func<T, object>> expression)
        {
            return GetMemberName(expression);
        }

        public static string GetMemberName<T>(
            Expression<Func<T, object>> expression)
        {
            if (expression == null)
                throw new NullReferenceException();

            return GetMemberName(expression.Body);
        }

        public static string GetMemberName<T>(
            this T instance,
            Expression<Action<T>> expression)
        {
            return GetMemberName(expression);
        }

        public static string GetMemberName<T>(
            Expression<Action<T>> expression)
        {
            if (expression == null)
                throw new NullReferenceException();

            return GetMemberName(expression.Body);
        }

        private static string GetMemberName(
            Expression expression)
        {
            if (expression == null)
                throw new NullReferenceException();

            var memberExpression = expression as MemberExpression;
            if (memberExpression != null)
                return memberExpression.Member.Name;

            var methodCallExpression = expression as MethodCallExpression;
            if (methodCallExpression != null)
                return methodCallExpression.Method.Name;

            var unaryExpression = expression as UnaryExpression;
            if (unaryExpression != null)
                return GetMemberName(unaryExpression);

            throw new ArgumentException();
        }

        private static string GetMemberName(
            UnaryExpression unaryExpression)
        {
            var methodExpression = unaryExpression.Operand as MethodCallExpression;
            if (methodExpression != null)
                return methodExpression.Method.Name;

            return ((MemberExpression)unaryExpression.Operand).Member.Name;
        }
    }
}
