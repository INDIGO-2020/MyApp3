
using System.Data;

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

        //TODO: add list
        public void AddTask()
        {
            string input;
            bool isTaskCompleted = false;
            string judul;
            int invalidInput = 0;
            const int maxInvalid = 2;


            do
            {
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
                        Console.WriteLine("Judul Kegiatan telah Ditambahkan!");
                    }
                    else
                    {
                        Console.WriteLine("Judul tidak boleh Kosong!");
                        invalidInput++;
                        if (invalidInput >= maxInvalid)
                        {
                            Console.Write("Kembali Ke Menu Utama");
                            return;
                        }

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

        //TODO: Edit List
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
                            bool currentStatus = taskToEdit.IsTaskCompleted;

                            if (string.IsNullOrWhiteSpace(inputJudulBaru))
                            {
                                Console.WriteLine("Judul tidak Diperbaharui");
                                taskToEdit.IsTaskCompleted = UpdateStatus(inputStatusBaru, currentStatus);
                                break;
                            }
                            else
                            {
                                taskToEdit.Judul = inputJudulBaru;
                                Console.WriteLine("Judul telah Diperbaharui!");
                                taskToEdit.IsTaskCompleted = UpdateStatus(inputStatusBaru, currentStatus);

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

        private static bool UpdateStatus(string input, bool currentStatus)
        {
            if (input.ToLower() == "y" && !currentStatus) //input = y + true == true
            {
                Console.WriteLine("Status telah di Update menjadi Selesai");
                return true;
            }
            else if (input.ToLower() == "y" && currentStatus)
            {
                Console.WriteLine("Tidak ada Perubahan pada Status Kegiatan");
                return currentStatus;
            }


            if (input.ToLower() == "n" && !currentStatus) //input = n + false == false
            {
                Console.WriteLine("Tidak ada perubahan pada Status Kegiatan");
                return false;
            }
            else if (input.ToLower() == "n" && currentStatus) //input = n + true == ?
            {
                Console.Write("Anda yakin akan merubah Status kegiatan kembali menjadi Belum? (Y/N): ");
                char confirmRevertStatus = char.Parse(Console.ReadLine().ToLower());

                if (confirmRevertStatus == 'y') //cek changing bool == true (menjadi belum)
                {
                    Console.WriteLine("Status Kegiatan telah Kembali menjadi Belum");
                    return false;
                }
                else if (confirmRevertStatus == 'n')
                {
                    Console.WriteLine("Status kegiatan tidak berubah");
                    return currentStatus;
                }
                else
                {
                    Console.WriteLine("Input Invalid. Hanya ada 2 pilihan: (Y/N)");
                }

                return currentStatus;
            }

            else
            {
                Console.WriteLine("Input Invalid. Tolong pilih antara (Y/N)");
                return currentStatus;
            }

        }

        //TODO: Delete List
        public void DeleteTask(int id)
        {
            var TaskToDelete = taskManager.FirstOrDefault(t => t.Id == id);

            if (TaskToDelete != null)
            {
                taskManager.Remove(TaskToDelete);
                Console.WriteLine("Daftar Kegiatan berhasil dihapus");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Kegiatan dengan ID {id} tidak ditemukan!");
                Console.ReadLine();
            }

        }
        //TODO: Get list
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
