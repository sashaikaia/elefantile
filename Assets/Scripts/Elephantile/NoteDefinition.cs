using UnityEngine;

namespace Elephantile
{
    public class NoteDefinition : ScriptableObject
    {
        // A letter ranging from A to G
        public char pitch;
        
        public Sprite sprite;
        public Color color;
    }
}