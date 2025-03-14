using Bookify.Wep.Core.Models;

namespace Bookify.Wep.Data.IRepository
{
    public interface IRepositoryCategory
    {
        IEnumerable<Category> GetCategories();
        bool checkcategory(string name);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        Category GetCategorybyid(int id);
        void togglestatuscategory(Category category);
    }
}
