
namespace ToDoListApp
{
    public class ManageTask
    {
        private List<ModelTask> taskManager;

        public ManageTask()
        {
           taskManager = new List<ModelTask>();
        }

        public void AddTask()
        {
            string judul;
            bool isTaskCompleted = false;

            Console.WriteLine("Task Baru\n");
            Console.Write("Judul Kegitan: ");
            string input = Console.ReadLine();

            string[] separatedInput = input.Split(",");

            if(separatedInput.Length == 1)
            {
                judul = separatedInput[0].Trim(); 

                var taskBaru = new ModelTask(judul, isTaskCompleted);
                taskManager.Add(taskBaru);
            }
            else
            {
                Console.WriteLine("Error");
            }


        }

        public void DisplayTask()
        {
            foreach (var item in taskManager)
            {
                string status = item.IsTaskCompleted ? "Selesai" : "Belum";
                Console.WriteLine($"{item.Id}. {item.Judul} Status: {status}");
            }
        }
    }
}
