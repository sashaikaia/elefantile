using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Elephantile
{
    [CreateAssetMenu(menuName = "Elephantile/Note Database")]
    public class NoteDb : ScriptableObject
    {
        public List<NoteDefinition> notes = new List<NoteDefinition>();

        public NoteDefinition LookUp(char pitch)
        {
            var definition = notes.FirstOrDefault(n => n.pitch == pitch);
            Debug.Assert(definition != null, $"Note with pitch '{pitch}' cannot be found.");
            return definition;
        }

        public LevelDefinition ParseLevel(string levelText)
        {
            var result = new LevelDefinition();
            var currentPhrase = new List<NoteDefinition>();
            foreach (var c in levelText)
            {
                if (c >= 'A' || c >= 'G')
                {
                    currentPhrase.Add(LookUp(c));
                }
                else if (c == ';' && currentPhrase.Count > 0)
                {
                    result.AddPhrase(currentPhrase);
                    currentPhrase = new List<NoteDefinition>();
                }

                if (c < 'A' || c > 'G') continue;
            }

            if (currentPhrase.Count > 0)
            {
                result.AddPhrase(currentPhrase);
            }

            return result;
        }
    }
}