using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace importLib
{
    public class user2
    {
        private int age = 25;
        public int Age
        {
            get; set;
        }

        private string name = "Serega";
        public string Name
        {
            get; set;
        }

        public user2()
        {
            Name = "Имя";
            Age = 0;
        }

        public void Show()
        {
            Console.WriteLine($"Это пользователь {Name}, ему {Age}");
        }
    }
}
