using UnityEngine;

namespace Elephantile
{
    public class LevelBase : MonoBehaviour
    {
        [SerializeField] protected NoteDb mNoteDb;

        public virtual LevelDefinition GetDefinition()
        {
            return mNoteDb.ParseLevel("ABCDEFG");
        }
    }
}