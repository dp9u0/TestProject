#region

using System;
using System.Threading;

#endregion

namespace EntityFrameworkTest {
    internal class Program {
        private static void Main(string[] args) {
            using (DbContext context = new ModelContainer()) {
                context.Set<Entity1>().Add(new Entity1());
                context.SaveChanges();
                CancellationToken cancellationToken = new CancellationToken();
                var result = context.Set<Entity1>().FirstOrDefaultAsync(cancellationToken);
                Console.WriteLine(result.Result.Id);
            }
        }
    }
}