using UnityEngine;

namespace Elephantile
{
    public abstract class LevelBase : MonoBehaviour
    {
        [SerializeField] protected NoteDb mNoteDb;

        public abstract LevelDefinition GetDefinition();

        protected int mIndexOfExpectedNote = 0;

        public virtual NoteDefinition GetExpectedNote()
        {
            return GetDefinition()[mIndexOfExpectedNote];
        }

        public virtual void AdvanceNote()
        {
            ++mIndexOfExpectedNote;
        }

        public virtual bool IsEndOfLevel()
        {
            return mIndexOfExpectedNote >= GetDefinition().Count;
        }
    }
}