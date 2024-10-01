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
            _manage.AddTask("Belajar B.Ingris", false);
            _manage.AddTask("Belajar Jalan Kaki", true);

            _manage.DisplayTask();
        }
    }
}
