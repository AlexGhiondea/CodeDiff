using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDiffLib.Changes
{
    public class Change<T>
    {
        public T Before { private set; get; }
        public T After { private set; get; }
        public ChangeType ChangeType { private set; get; }

        public Change(T before, T after, ChangeType change)
        {
            Before = before;
            After = after;
            ChangeType = change;
        }
    }
}
