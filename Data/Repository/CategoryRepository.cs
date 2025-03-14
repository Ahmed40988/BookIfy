using Bookify.Wep.Core.Models;
using Bookify.Wep.Data.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Wep.Data.Repository
{
    public class CategoryRepository : IRepositoryCategory
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context )
        {
            this._context = context; 
        }
        public IEnumerable<Category> GetCategories()
        { return _context.Categories.AsNoTracking() .ToList(); }
         public bool checkcategory(string name)
        { return _context.Categories.Any(c=>c.Name==name); }
        public void CreateCategory( Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }
        public Category GetCategorybyid(int id)
        {
            return _context.Categories.Find(id);
        }

        public void togglestatuscategory(Category category)
        {
           category.IsDeleted = !category.IsDeleted;
            category.lastupdated=DateTime.Now;
            _context.SaveChanges();

        }


    }
}
