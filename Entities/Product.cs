using Core.DataAccess;

namespace Entities
{
    public class Product : BaseEntity
    {
       
        public Product()
        {
        }

        public Product(string name, double unitPrice, int stock, int categoryId)
        {
            Name = name;
            UnitPrice = unitPrice;
            Stock = stock;
            CategoryId = categoryId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public int Stock { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
