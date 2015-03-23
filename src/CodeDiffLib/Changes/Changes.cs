using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDiffLib.Changes
{
    public class Changes<T>
    {
        private List<Change<T>> changes;

        public Changes()
        {
            changes = new List<Change<T>>();
        }

        public bool Any()
        {
            return changes.Any();
        }

        public IEnumerable<Change<T>> GetAdded()
        {
            return changes.Where(x => x.ChangeType == ChangeType.Added);
        }
        public IEnumerable<Change<T>> GetRemoved()
        {
            return changes.Where(x => x.ChangeType == ChangeType.Removed);
        }
        public IEnumerable<Change<T>> GetModified()
        {
            return changes.Where(x => x.ChangeType == ChangeType.Modified);
        }

        public void NewRemoved(T before)
        {
            addChange(before, default(T), ChangeType.Removed);
        }
        public void NewAdded(T after)
        {
            addChange(default(T), after, ChangeType.Added);
        }
        public void NewModified(T before, T after)
        {
            addChange(before, after, ChangeType.Modified);
        }

        private void addChange(T before, T after, ChangeType change)
        {
            changes.Add(new Change<T>(before, after, change));
        }
    }
}
