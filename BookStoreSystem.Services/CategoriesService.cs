using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookShopSytem.Models.Bms.Categories;
using BookShopSytem.Models.Entities;
using BookShopSytem.Models.Vms.Categories;
using BookStoreSystem.Services.Contracts;

namespace BookStoreSystem.Services
{
    public class CategoriesService : Service, ICategoriesService
    {
        public IEnumerable<CategoryVm> GetAll()
        {
            IEnumerable<Category> models = this.Context.Categories;
            IEnumerable<CategoryVm> vms = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryVm>>(models);
            return vms;
        }

        public bool CategoryExists(int id)
        {
            return this.Context.Categories.Find(id) != null;
        }

        public CategoryVm Get(int id)
        {
            Category model = this.Context.Categories.Find(id);
            CategoryVm vm = Mapper.Map<Category, CategoryVm>(model);
            return vm;
        }

        public void Delete(int id)
        {
            Category model = this.Context.Categories.Find(id);
            this.Context.Categories.Remove(model);
            this.Context.SaveChanges();
        }

        public bool CategoryNameExists(string categoryName)
        {
            return this.Context.Categories.FirstOrDefault(category => category.Name == categoryName) != null;
        }

        public void Edit(int id, string categoryName)
        {
            Category model = this.Context.Categories.Find(id);
            model.Name = categoryName;
            this.Context.SaveChanges();
        }

        public void AddCategory(AddCategoryBm bind)
        {
            Category model = Mapper.Instance.Map<AddCategoryBm, Category>(bind);
            this.Context.Categories.Add(model);
            this.Context.SaveChanges();
        }
    }
}
