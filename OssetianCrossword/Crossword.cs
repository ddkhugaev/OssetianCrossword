using System.Collections.Generic;

namespace OssetianCrossword
{
    class Crossword
    {
        private List<Word> words = new List<Word>();
        // добавление слова в список слов
        public void AddWord(Word word)
        {
            words.Add(word);
        }
        // get методы
        public int GetLen()
        {
            return words.Count;
        }
        // индексатор
        public Word this[int index]
        {
            get { return words[index]; }
        }
    }
}
