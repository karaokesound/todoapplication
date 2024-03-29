﻿using System;
using System.Collections.Generic;
using System.Linq;
using ToDoApp.Models;
using ToDoApp.ViewModels;
using ToDoAppDataAccess;

namespace ToDoApp.Commands.Profile
{
    public class DisplayTaskListviewCommand : CommandBase
    {
        private readonly CategoriesPanelViewModel _categoriesPanelVM;

        public override void Execute(object parameter)
        {
            if (_categoriesPanelVM.IsListviewVisible == false)
            {
                _categoriesPanelVM.IsListviewVisible = true;
                GetCategoryTaskList();
            }
            else
            {
                _categoriesPanelVM.IsListviewVisible = false;
            }
        }


        public DisplayTaskListviewCommand(CategoriesPanelViewModel categoriesPanelVM)
        {
            _categoriesPanelVM = categoriesPanelVM;
        }

        public void GetCategoryTaskList()
        {
            List<TaskModel> taskModels = new List<TaskModel>();

            Guid selectedCategoryId = _categoriesPanelVM.SelectedCategory.CategoryId;
            if (selectedCategoryId != Guid.Empty && selectedCategoryId != null)
            {
                using (ToDoAppDbContext context = new ToDoAppDbContext())
                {
                    List<CategoryTaskModel> categoryTasksListModel = context.CategoryTasks.Where(category => category.CategoryGuidId == selectedCategoryId).ToList();
                    foreach (CategoryTaskModel categoryTaskModel in categoryTasksListModel)
                    {
                        Guid categoryTaskId = categoryTaskModel.TaskGuidId;
                        TaskModel taskModel = context.Tasks.FirstOrDefault(task => task.GuidId == categoryTaskId);
                        taskModels.Add(taskModel);
                    }
                }
                _categoriesPanelVM.GetCategoryTaskList(taskModels);
            }
            else return;
        }
    }
}
