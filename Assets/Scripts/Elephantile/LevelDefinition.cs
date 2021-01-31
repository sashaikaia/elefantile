using System.Collections.Generic;
using System.Linq;

namespace Elephantile
{
    public class LevelDefinition : List<NoteDefinition>
    {
        private readonly List<List<NoteDefinition>> mPhrases = new List<List<NoteDefinition>>();

        public void AddPhrase(List<NoteDefinition> phrase)
        {
            if (phrase.Count == 0) return;
            mPhrases.Add(phrase.ToList());
            AddRange(phrase);
        }

        public IReadOnlyList<IReadOnlyList<NoteDefinition>> Phrases => mPhrases;
    }
}