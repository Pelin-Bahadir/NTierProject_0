using Project.BLL.DesignPatterns.GenericRepository.BaseRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.ConcRep
{
    public class CategoryRepository:BaseRepository<Category>
    {
        public void AddCategoryWithProducts(Category item,List<Product> products)
        {
            item.Products = products;
            _db.Categories.Add(item);
            Save();
        }
    }
}
