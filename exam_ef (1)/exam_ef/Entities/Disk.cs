using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace exam_ef.Entities
{
    [Table("Disks")]
    public class Disk : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CollectionId { get; set; }
        public int AuthorId { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public int PriceForSale { get; set; }
        public Disk() { }

        public virtual ICollection<Collection> Collections{ get; set; } = new HashSet<Collection>();
        public virtual ICollection<Author> Authors { get; set; } = new HashSet<Author>();
    }
}
