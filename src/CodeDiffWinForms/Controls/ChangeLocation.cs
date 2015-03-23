using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDiffWinForms
{
    public class ChangeLocation
    {
        public readonly TextSpan Before;
        public readonly TextSpan After;
        public readonly string Note;
        public ChangeLocation(TextSpan before, TextSpan after, string note)
        {
            Before = before;
            After = after;

            Note = note;
        }
        public override string ToString()
        {
            if (Before != default(TextSpan))
                return string.Format("{0}: Before:{1}", Note, Before);
            else if (After != default(TextSpan))
                return string.Format("{0}: After:{1}", Note, After);
            else
                return string.Format("{0}: Before:{1} - After:{2}", Note, Before, After);
        }
    }
}
