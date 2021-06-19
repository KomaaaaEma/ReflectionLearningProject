using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace importLib
{
    public class importClass
    {
        //Данный класс будет имортирован при поомщи рефлексии в основную программу под названием
        //MyReflectionMainProject

        /// <summary>
        /// Данная строка должна будет выведена в проекте
        /// </summary>
        private string str = "Стартовое значение строки";

        /// <summary>
        /// Свойство для доступа к приватной str
        /// </summary>
        public string Str
        {
            get;
            set;
        }

        /// <summary>
        /// Поменять местами значения
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static string Swapp(string a, string b)
        {
            return a + b;
        }            
    }
}
