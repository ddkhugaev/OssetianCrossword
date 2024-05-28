using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OssetianCrossword
{
    class Crossword
    {
        private List<Word> words = new List<Word>();
        public void AddWord(Word word)
        {
            words.Add(word);
        }
    }
}
