using DbRepository.Categories;
using MyTasksManager.Models;
using System.Collections.Generic;

namespace MyTasksManager.Actions
{
    public class CategoryFetch
    {
        readonly GetCategories GetCategories;

        public CategoryFetch(GetCategories getCategories)
        {
            GetCategories = getCategories;
        }

        public List<Category> GetAllCategories()
        {
            return GetCategories.Execute();
        }
    }
}
