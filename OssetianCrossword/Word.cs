using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OssetianCrossword
{
    class Word
    {
        private int number;
        private int x;
        private int y;
        private int count;
        private string direction;
        private string[] ossetianWord;
        private string russianWord;
        public Word(int number, int x, int y, int count, string direction, string ossetianWord, string russianWord)
        {
            this.number = number;
            this.x = x;
            this.y = y;
            this.count = count;
            this.direction = direction;
            this.ossetianWord = ossetianWord.Replace("ае", "ӕ").Split();
            this.russianWord = russianWord;
        }
        // возвращает наше слово в виде строки с характеристиками (бета)
        public string MakeString()
        {
            return $"{number} {x} {y} {count} {direction} {ossetianWord} {russianWord}";
        }
        // get методы
        public int GetNumber()
        {
            return number;
        }
        public int[] GetXY()
        {
            return new int[] { x, y };
        }
        public int GetLen()
        {
            return count;
        }
        public string GetDirection()
        {
            return direction;
        }
        public string[] GetOssetianWord()
        {
            return ossetianWord;
        }
    }
}
