﻿using System;
using System.Collections.Generic;

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
            int option;

            do
            {
                Console.WriteLine("Pilih Menu: ");
                Console.WriteLine("1. Tambah Task");
                Console.WriteLine("2. Edit Task");
                Console.WriteLine("3. Delete Task");
                Console.WriteLine("4. Daftar Task");
                Console.WriteLine("0. Exit Program");
                Console.WriteLine("====================");
                //if(!int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out option)){
                //    Console.WriteLine("Input Harus bertipe Angka");
                //    continue;
                //}

                if (!int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out option))
                {
                    Console.WriteLine("Input Harus bertipe Angka");
                }


                switch (option)
                {
                    case 1:
                        _manage.AddTask();
                        Console.ReadLine();

                        Console.Clear();
                        break;
                    case 2:
                        _manage.DisplayTask();
                        Console.Write("Masukkan Angka/Id Task yang akan diEdit: ");
                        if (!int.TryParse(Console.ReadLine(), out int editId))
                        {
                            Console.WriteLine("Tidak ada Id tersebut");
                            Console.WriteLine("Kembali ke Menu Utama");
                            Console.ReadLine();
                        }
                        else 
                        {
                            _manage.EditTask(editId);
                        }
                        break;
                    case 3:
                        _manage.DisplayTask();
                        Console.Write("Masukkan Id yang akan dihapus: ");

                        if(int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            _manage.DeleteTask(deleteId);
                        }
                        else
                        {
                            Console.WriteLine("Kembali Ke Menu Utama");
                            Console.ReadLine();
                        }

                        Console.Clear();
                        break;
                    case 4:
                        _manage.DisplayTask();
                        Console.ReadLine();

                        Console.Clear();
                        break;
                    case 0:
                        Console.WriteLine("Program Berhenti");
                        break;
                    default:
                        Console.WriteLine("Tidak ada Menu tersebut");
                        break;
                }
            } while (option != 0);

        }
    }
}
