using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
  public class Product
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductID { get; set; }
    public string Name { get; set; }

    public int BrandID { get; set; }
    
    [ForeignKey("BrandID")]
    public virtual Brand Brand { get; set; }
  }
}