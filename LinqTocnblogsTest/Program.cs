#region

using System;
using System.Linq;
using CnblogsLinqProvider;

#endregion

namespace Test {
    internal class Program {
        private static void Main(string[] args) {
            var provider = new CnblogsQueryProvider();
            var queryable = new Query<Post>(provider);

            var query =
                from p in queryable
                where (p.Diggs >= 10) &&
                      (p.Comments > 10) &&
                      (p.Views > 10) &&
                      (p.Comments < 20)
                select p;

            Console.WriteLine(query.ToString());

            //var list = query.ToList();
            Console.ReadLine();
        }
    }
}