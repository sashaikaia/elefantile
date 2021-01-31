using System;
using UnityEngine;

namespace Elephantile
{
    [Serializable]
    public class NoteDefinition
    {
        // A letter ranging from A to G
        public char pitch;

        public Sprite sprite;
        public Color color;
    }
}