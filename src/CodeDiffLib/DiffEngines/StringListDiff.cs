using CodeDiffLib.Changes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDiffLib
{
    public class StringListDiff
    {
        public static IEnumerable<Change<string>> Compare(IEnumerable<string> before, IEnumerable<string> after)
        {
            var beforeEnumerator = before.GetEnumerator();
            var afterEnumerator = after.GetEnumerator();

            bool beforeEnumeratorStillValid = beforeEnumerator.MoveNext();
            bool afterEnumeratorStillValid = afterEnumerator.MoveNext();

            while (afterEnumeratorStillValid && beforeEnumeratorStillValid)
            {
                if (StringComparer.OrdinalIgnoreCase.Equals(beforeEnumerator.Current, afterEnumerator.Current))
                {
                    // we have no changes
                    yield return new Change<string>(beforeEnumerator.Current, afterEnumerator.Current, ChangeType.NoChange);

                    // move to the next element;
                    beforeEnumeratorStillValid = beforeEnumerator.MoveNext();
                    afterEnumeratorStillValid = afterEnumerator.MoveNext();
                    continue;
                }

                // since the files are sorted, if one is greater than the other, it means the file is not there.
                if (beforeEnumeratorStillValid && StringComparer.OrdinalIgnoreCase.Compare(beforeEnumerator.Current, afterEnumerator.Current) < 0)
                {
                    while (beforeEnumeratorStillValid && StringComparer.OrdinalIgnoreCase.Compare(beforeEnumerator.Current, afterEnumerator.Current) < 0)
                    {
                        yield return new Change<string>(beforeEnumerator.Current, null, ChangeType.Removed);
                        beforeEnumeratorStillValid = beforeEnumerator.MoveNext();
                    }
                }
                else
                {
                    while (afterEnumeratorStillValid && StringComparer.OrdinalIgnoreCase.Compare(beforeEnumerator.Current, afterEnumerator.Current) > 0)
                    {
                        yield return new Change<string>(null, afterEnumerator.Current, ChangeType.Added);
                        afterEnumeratorStillValid = afterEnumerator.MoveNext();
                    }
                }
            }

            while (beforeEnumeratorStillValid)
            {
                yield return new Change<string>(beforeEnumerator.Current, null, ChangeType.Removed);
                beforeEnumeratorStillValid = beforeEnumerator.MoveNext();
            }

            while (afterEnumeratorStillValid)
            {
                yield return new Change<string>(null, afterEnumerator.Current, ChangeType.Added);
                afterEnumeratorStillValid = afterEnumerator.MoveNext();
            }

            yield break;
        }
    }
}
