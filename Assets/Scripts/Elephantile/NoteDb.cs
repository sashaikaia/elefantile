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
            foreach (var c in levelText)
            {
                if (c < 'A' || c > 'G') continue;
                result.Add(LookUp(c));
            }
            return result;
        }
    }
}