using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp
{
    public class ManageTask
    {
        private List<ModelTask> taskManager;

        public ManageTask()
        {
           taskManager = new List<ModelTask>();
        }

        public void AddTask(string judul, bool isTaskCompleted)
        {
            var taskBaru = new ModelTask(judul, isTaskCompleted);
            taskManager.Add(taskBaru);
        }

        public void DisplayTask()
        {
            foreach (var item in taskManager)
            {
                Console.WriteLine($"{item.Id}. {item.Judul} selesai?{item.IsTaskCompleted}");
            }
        }
    }
}
