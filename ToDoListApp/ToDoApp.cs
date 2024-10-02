using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp
{
    public class ToDoApp
    {
        private ManageTask _manage;

        public ToDoApp()
        {
            _manage = new ManageTask();
        }

        public void Execute()
        {
            _manage.AddTask();
            _manage.DisplayTask();
        }
    }
}
