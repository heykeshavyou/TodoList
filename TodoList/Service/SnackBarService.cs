using CommunityToolkit.Maui.Alerts;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Service
{
    public interface ISnackBarService
    {
        void TaskCreated();
        void TaskUpdated();
        void TaskDeleted();
        void TaskCompleted();
    }
    public class SnackBarService : ISnackBarService
    {
        public void TaskCreated()
        {
            var snackbar = Snackbar.Make("Task Created Successfully");
            snackbar.Show();
        }

        public void TaskDeleted()
        {
            var snackbar = Snackbar.Make("Task Deleted Successfully");
            snackbar.Show();
        }

        public void TaskUpdated()
        {
            var snackbar = Snackbar.Make("Task Updated Successfully");
            snackbar.Show();
        }
        public void TaskCompleted()
        {
            var snackbar = Snackbar.Make("Task Completed Successfully");
            snackbar.Show();
        }
    }
}
