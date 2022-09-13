using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly LibraryDbContext _libraryDbContext;

        public CategoryRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public IEnumerable<Category> GetAllCategories => _libraryDbContext.Categories;
    }
}
