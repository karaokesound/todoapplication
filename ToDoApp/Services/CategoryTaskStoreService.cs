﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public class CategoryTaskStoreService
    {
        private static CategoryTaskStoreService _instance;
        public static CategoryTaskStoreService Instance()
        { 
            if (_instance == null)
            {
                _instance = new CategoryTaskStoreService();
            }
            return _instance;
        }

        private List<CategoryTaskModel> _categoryTaskList;

        public CategoryTaskStoreService()
        {
            _categoryTaskList = new List<CategoryTaskModel>();
        }
        public static void AddNewCategoryTask(CategoryTaskModel categoryTaskModel)
        {
            CategoryTaskModel newCategoryTask = new CategoryTaskModel
            {
                CategoryId = categoryTaskModel.CategoryId,
                TaskId = categoryTaskModel.TaskId,
            };

            Instance()._categoryTaskList.Add(newCategoryTask);
        }

        public static void RemoveCategoryTask(CategoryTaskModel categoryTaskToRemove)
        {
            var searchedTask = Instance()._categoryTaskList.FirstOrDefault(categoryTask => categoryTask.TaskId == categoryTaskToRemove.TaskId);
            _instance._categoryTaskList.Remove(searchedTask);
        }

        public static List<CategoryTaskModel> GetAllTasksForCategory(Guid categoryId)
        {
            return Instance()._categoryTaskList.FindAll(category => category.CategoryId == categoryId);
        }
    }
}
