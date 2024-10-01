using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp
{
    public class ModelTask
    {
        private int _countId = 0;
        public ModelTask(string judul, bool isTaskCompleted)
        {
            if (String.IsNullOrWhiteSpace(judul))
            {
                throw new ArgumentException("Judul Kosong", nameof(judul));
            }

            _countId++;
            Id = _countId;
            Judul = judul;
            IsTaskCompleted = isTaskCompleted;
        }

        public int Id { get; private set; }
        public string Judul { get; set; }
        public bool IsTaskCompleted { get; set; }

    }
}
