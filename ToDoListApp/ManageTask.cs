
namespace ToDoListApp
{
    public class ManageTask
    {
        private List<ModelTask> taskManager;

        public ManageTask()
        {
            taskManager = modelTasks();
        }

        private List<ModelTask> modelTasks()
        {
            return new List<ModelTask>
            {
                new ModelTask("Belajar Memasak", false),
                new ModelTask("Belajar Membuka Pintu", true)
            };
        }
        public void AddTask()
        {
            string input;
            bool isTaskCompleted = false;

            do
            {
                string judul;

                Console.WriteLine("Task Baru\n");
                Console.Write("Judul Kegitan: ");
                input = Console.ReadLine();

                string[] separatedInput = input.Split(",");

                if (separatedInput.Length == 1)
                {
                    judul = separatedInput[0].Trim();
                    if (!string.IsNullOrWhiteSpace(judul))
                    {
                        var taskBaru = new ModelTask(judul, isTaskCompleted);
                        taskManager.Add(taskBaru);
                    }
                    else
                    {
                        Console.WriteLine("Judul tidak boleh Kosong!");

                        /*
                         * DIBAWAH INI MERUPAKAN TRIAL UNTUK MENGHAPUS BEBERAPA BARIS.
                         */
                        //Console.SetCursorPosition(0, 8);
                        //Console.Write(new string(' ', Console.WindowWidth));
                        //Console.SetCursorPosition(0, 6);
                    }
                }
            } while (string.IsNullOrWhiteSpace(input));
        }

        public void EditTask(int id)
        {
            //inisialisasi dibawah ini merupakan implementasi dari LINQ(Language Integrated Query)
            //dimana FirstOrDefault() akan mengambil value berdasarkan kondisi yang ada pada parameter
            //parameter ini adalah lambda expression untuk mencari Id pada 't' yang sesuai dengan input id
            var taskToEdit = taskManager.FirstOrDefault(t => t.Id == id);

            if (taskToEdit != null)
            {
                int option = 0;
                do
                {

                    Console.WriteLine("\nOpsi Edit:");
                    Console.WriteLine("1. Edit Judul");
                    Console.WriteLine("9. Selesai dan Kembali ke Menu Utama");

                    Console.Write("Pilih opsi: ");
                    // Ambil input user untuk opsi edit
                    if (!int.TryParse(Console.ReadLine(), out option))
                    {
                        Console.WriteLine("Input Invalid. Gunakan Number");
                        continue;
                    }

                    switch (option)
                    {
                        case 1:
                            Console.Write("Masukkan Judul baru atau Kosongkan bila jadi diubah: ");
                            string inputJudulBaru = Console.ReadLine();

                            Console.Write("Kegiatan Selesai? (Y/N): ");
                            string? inputStatusBaru = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(inputJudulBaru))
                            {
                                Console.WriteLine("Judul tidak Diperbaharui");
                                taskToEdit.IsTaskCompleted = changeStatus(inputStatusBaru);
                                break;
                            }
                            else
                            {
                                taskToEdit.Judul = inputJudulBaru;
                                Console.WriteLine("Judul telah Diperbaharui!");
                                taskToEdit.IsTaskCompleted = changeStatus(inputStatusBaru);

                                break;
                            }
                        case 9:
                            Console.WriteLine("Kembali Ke Menu Utama");
                            Console.Clear();
                            return;

                        default:
                            break;
                    }
                } while (option != 9);
            }
            else
            {
                Console.WriteLine($"\nTugas dengan Id: {id} tidak ditemukan");
            }
        }

        private bool changeStatus(string input)
        {
            switch (input.ToLower())
            {
                case "y":
                    Console.WriteLine("Status Kegiatan telah Diubah");
                    return true;

                case "n":
                    Console.WriteLine("Status Kegiatan Tidak Diubah");
                    return false;

                default:
                    Console.WriteLine("Invalid Input. Status Tidak berubah");
                    return false;
            }
        }
        public void DisplayTask()
        {
            Console.WriteLine("\tList Tugas yang terdaftar");
            foreach (var item in taskManager)
            {
                string status = item.IsTaskCompleted ? "Selesai" : "Belum";
                Console.WriteLine($"{item.Id}. {item.Judul}; Status: {status}");
            }
        }
    }
}
