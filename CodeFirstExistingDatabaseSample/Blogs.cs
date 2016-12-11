#region

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#endregion

namespace CodeFirstExistingDatabaseSample {
    public class Blogs {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
             "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Blogs() {
            Posts = new HashSet<Posts>();
        }

        [Key]
        public int BlogId { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
             "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Posts> Posts { get; set; }
    }
}