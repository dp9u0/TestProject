#region

using System;
using System.Linq;
using System.Linq.Expressions;
using CnblogsLinqProvider;

#endregion

namespace Test {
    internal class Program {
        private static void Main(string[] args) {
            Console.WriteLine("-----------------------------");
            Test000();
            Console.WriteLine("-----------------------------");
            Test001();
            Console.ReadLine();
        }


        private static void Test000() {
            var provider = new CnblogsQueryProvider();
            var queryable = new Query<Post>(provider);

            var query =
                from p in queryable
                where p.Title.Contains("r")
                      && (p.Diggs >= 10)
                      && (p.Comments > 10)
                      && (p.Views > 10)
                      && (p.Comments < 20)
                select p;
            var titles = from p in query select p.Title;

            Console.WriteLine(query.ToString());
            //var list = query.ToList();
        }

        private static void Test001() {
            CnblogsQueryProvider provider = new CnblogsQueryProvider();
            Query<Post> queryable = new Query<Post>(provider);
            IQueryable<Post> arg14D0 = queryable;
            ParameterExpression parameterExpression = Expression.Parameter(typeof(Post), "p");

            IQueryable<Post> arg18B0 =
                arg14D0.Where(
                    Expression.Lambda<Func<Post, bool>>(
                        Expression.AndAlso(
                            Expression.AndAlso(
                                Expression.AndAlso(
                                    Expression.AndAlso(
                                        Expression.Call(
                                            Expression.Property(parameterExpression, "Title"),
                                            typeof(string).GetMethod("Contains"), Expression.Constant("r", typeof(string))),
                                        Expression.GreaterThanOrEqual(
                                            Expression.Property(parameterExpression, "Diggs"),
                                            Expression.Constant(10, typeof(int)))),
                                    Expression.GreaterThan(Expression.Property(parameterExpression,
                                        "Comments"), Expression.Constant(10, typeof(int)))), Expression.GreaterThan(
                                    Expression.Property(parameterExpression,
                                        "Views"), Expression.Constant(10, typeof(int)))),
                            Expression.LessThan(Expression.Property(parameterExpression,
                                "Comments"), Expression.Constant(20, typeof(int)))), parameterExpression));

            //input parameterExpression
            //parameterExpression = Expression.Parameter(typeof(Post), "p");

            //IQueryable<string> query = arg18B0.Select(Expression.Lambda<Func<Post, string>>(
            //    Expression.Property(parameterExpression,
            //        "Title"), parameterExpression));

            Console.WriteLine(arg18B0.ToString());
            //var list = query.ToList();

        }
    }
}