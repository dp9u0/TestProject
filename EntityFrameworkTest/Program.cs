using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EntityFrameworkTest {
    class Program {
        static void Main(string[] args) {

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
