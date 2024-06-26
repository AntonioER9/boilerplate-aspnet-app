using Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
  public class ProductRepository : IRepository<Product>
  {
    private DatabaseContext _context;
    public ProductRepository(DatabaseContext context)
    {
      _context = context;
    }
    public async Task<IEnumerable<Product>> Get() => await _context.Products.ToListAsync();
    public async Task<Product> GetById(int id) => await _context.Products.FindAsync(id);
    public async Task Add(Product product) => await _context.Products.AddAsync(product);

    public void Update(Product product)
    {
      _context.Products.Attach(product);
      _context.Products.Entry(product).State = EntityState.Modified;
    }
    public void Delete(Product product) => _context.Products.Remove(product);
    public async Task Save() => await _context.SaveChangesAsync();

    public IEnumerable<Product> Search(Func<Product, bool> filter) => 
      _context.Products.Where(filter).ToList();
  }

}