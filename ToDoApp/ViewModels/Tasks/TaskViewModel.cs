﻿using System;

namespace ToDoApp.ViewModels
{
    public class TaskViewModel : BaseViewModel
    {
        private Guid _taskId;
        public Guid TaskId
        {
            get { return _taskId; }
            set
            {
                _taskId = value;
                OnPropertyChanged(nameof(TaskId));
            }
        }

        private string _taskTitle;
        public string TaskTitle
        {
            get { return _taskTitle; }
            set
            {
                _taskTitle = value;
                OnPropertyChanged(nameof(TaskTitle));
            }
        }

        private string _taskDescription;
        public string TaskDescription
        {
            get { return _taskDescription; }
            set
            {
                _taskDescription = value;
                OnPropertyChanged(nameof(TaskDescription));
            }
        }

        private int _taskValue;
        public int TaskValue
        {
            get { return _taskValue; }
            set
            {
                _taskValue = value;
                OnPropertyChanged(nameof(TaskValue));
            }
        }

        private bool _isCompleted;
        public bool IsCompleted
        {
            get { return _isCompleted; }
            set
            {
                _isCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
            }
        }
    }
}
