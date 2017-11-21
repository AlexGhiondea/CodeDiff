using CodeDiffLib.Changes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDiffLib
{
    public class TreeDiff
    {
        public static Changes<SyntaxNodeOrToken> Compare(string beforeText, string afterText)
        {
            return Compare(SyntaxFactory.ParseSyntaxTree(beforeText).GetRoot(), SyntaxFactory.ParseSyntaxTree(afterText).GetRoot());
        }

        public static Changes<SyntaxNodeOrToken> Compare(SyntaxNodeOrToken before, SyntaxNodeOrToken after)
        {
            var myCodeDiff = new Changes<SyntaxNodeOrToken>();

            var one = new Stack<SyntaxNodeOrToken>();
            var two = new Stack<SyntaxNodeOrToken>();

            ////we first need to check at the very top level.
            CompareNodes(before, after, one, two, myCodeDiff);

            while (one.Count > 0 && two.Count > 0)
            {
                var nodeFirstTree = one.Pop();
                var nodeSecondTree = two.Pop();

                CompareNodes(nodeFirstTree, nodeSecondTree, one, two, myCodeDiff);
            }

            // if we have more nodes in two, they are added nodes.
            while (two.Count > 0)
            {
                myCodeDiff.NewAdded(two.Pop());
            }

            return myCodeDiff;
        }

        private static void CompareNodes(SyntaxNodeOrToken first, SyntaxNodeOrToken second, Stack<SyntaxNodeOrToken> one, Stack<SyntaxNodeOrToken> two, Changes<SyntaxNodeOrToken> myCodeDiff)
        {
            if (first.IsToken && !second.IsToken)
            {
                // we added more nodes
                myCodeDiff.NewAdded(second);
                return;
            }
            if (!first.IsToken && second.IsToken)
            {
                // we removed some nodes?
                myCodeDiff.NewRemoved(first);
                return;
            }

            // if we have tokens, deal with that first.
            if (first.IsToken && second.IsToken)
            {
                if (first.AsToken().Text != second.AsToken().Text)
                {
                    myCodeDiff.NewModified(first, second);
                }
                return;
            }

            int idx1 = 0;
            int idx2 = 0;
            var firstDesc = first.AsNode().ChildNodesAndTokens().ToArray();
            var secondDesc = second.AsNode().ChildNodesAndTokens().ToArray();

            while (idx1 < firstDesc.Length && idx2 < secondDesc.Length)
            {
                int posFirst, posSecond;

                FindFirstSequence(firstDesc, secondDesc, idx1, idx2, out posFirst, out posSecond);

                if (posSecond >= 0 && posFirst >= 0)
                {
                    //This marks the nodes that are not in the left tree but are in the righ tree
                    for (int i = idx1; i < posFirst; i++)
                    {
                        myCodeDiff.NewRemoved(firstDesc[i]);
                        //markAsDifferent(first.Nodes[i], Color.LightPink, true);
                    }

                    //This marks the nodes that are only in the right tree
                    for (int i = idx2; i < posSecond; i++)
                    {
                        myCodeDiff.NewAdded(secondDesc[i]);
                    }

                    //now they match structurally.

                    idx1 = posFirst; idx2 = posSecond;

                    //while the nodes have identical types, we add them to the list of nodes to further consider 
                    while ((idx1 < firstDesc.Length && idx2 < secondDesc.Length)
                        && firstDesc[idx1].Kind() == secondDesc[idx2].Kind())
                    {
                        // if the text does not match
                        if (!IsTextSame(firstDesc[idx1], secondDesc[idx2]))
                        {
                            // both sides have a diferent content but same structure

                            // we should see if the same structure and content can be found somewhere else.
                            if (LookForBetterMatch(firstDesc[idx1], secondDesc, idx2, out posSecond))
                            {
                                // we have a better match!
                                // since we are only going to look in the 'after' tree, if we find any nodes, they are going to be
                                // 'new' nodes.

                                for (; idx2 < posSecond; idx2++)
                                {
                                    myCodeDiff.NewAdded(secondDesc[idx2]);
                                }
                            }
                            else
                            {
                                // we don't have a better match further down.

                                // we only need to push syntax nodes since tokens are leaf nodes.
                                if (!firstDesc[idx1].IsToken) one.Push(firstDesc[idx1]);
                                if (!secondDesc[idx2].IsToken) two.Push(secondDesc[idx2]);

                                // if either is a token, recod this as a change.
                                if (firstDesc[idx1].IsToken && secondDesc[idx2].IsToken)
                                    myCodeDiff.NewModified(firstDesc[idx1], secondDesc[idx2]);
                            }

                            // we should try and find the next sequence.
                            idx1++; idx2++;
                            break;
                        }

                        idx1++; idx2++;
                    }
                }
                else
                {
                    //nothing matched..
                    for (int i = 0; i < firstDesc.Length; i++)
                    {
                        myCodeDiff.NewRemoved(firstDesc[i]);
                    }
                    for (int i = 0; i < secondDesc.Length; i++)
                    {
                        myCodeDiff.NewAdded(secondDesc[i]);
                    }
                    break;
                }

            }
            for (int i = idx1; i < firstDesc.Length; i++)
            {
                myCodeDiff.NewRemoved(firstDesc[i]);
            }
            for (int i = idx2; i < secondDesc.Length; i++)
            {
                myCodeDiff.NewAdded(secondDesc[i]);
            }
        }

        private static bool LookForBetterMatch(SyntaxNodeOrToken first, SyntaxNodeOrToken[] second, int secondPos, out int maxSecond)
        {
            maxSecond = secondPos;

            for (int i = secondPos; i < second.Length; i++)
            {
                if (first.Kind() == second[i].Kind() &&
                    IsTextSame(first, second[i]))
                {
                    maxSecond = i;
                    return true;
                }
            }

            return false;
        }

        private static void FindFirstSequence(SyntaxNodeOrToken[] first, SyntaxNodeOrToken[] second, int firstPos, int secondPos, out int maxFirst, out int maxSecond)
        {
            //we need to start at the given positions.

            int i, j;

            maxFirst = -1;
            maxSecond = -1;

            int maxLen = -1;
            int startFirst, startSecond;
            int currLen;

            //we traverse the first list of nodes
            for (i = firstPos; i < first.Length; i++)
            {
                for (j = secondPos; j < second.Length; j++)
                {
                    if ((first[i]).Kind() == (second[j]).Kind())
                    {
                        //we start the show.
                        startFirst = i;
                        startSecond = j;
                        currLen = 0;
                        int tempF = i;
                        int tempS = j;

                        //while the node types match
                        while ((tempF < first.Length && tempS < second.Length) &&
                            (first[tempF]).Kind() == (second[tempS]).Kind())
                        {
                            tempF++; tempS++;
                            currLen++;
                        }

                        //we reached a node that no longer matches

                        //if this is the first sequence that we find, we ask no more questions
                        if (maxLen < 0)
                        {
                            maxFirst = startFirst;
                            maxSecond = startSecond;
                            maxLen = currLen;
                        }
                        else if ((currLen > maxLen) && (first[startFirst].Span.Start == second[startSecond].Span.Start))
                        {
                            //if we find a longer sequence of types AND the span start positions match, we will pick that one. This will prevent cases where you have
                            //something like: 
                            // First code:
                            //      using sytem;
                            //      class C{}
                            //
                            //Second code:
                            //      using sytem;
                            //      using Sytem.Text;
                            //      class C{}
                            // in this case, the longest matching list of types for the second case starts with using system.Text. But because we can't look at the value (here) we would match using System with using System.Type
                            // Requiring the span to start at the same place will invalidate this longer chain as a better match.
                            maxFirst = startFirst;
                            maxSecond = startSecond;
                            maxLen = currLen;
                        }
                    }
                }
            }
        }

        private static bool IsTextSame(SyntaxNodeOrToken first, SyntaxNodeOrToken second)
        {
            if ((first.IsToken && !second.IsToken) || (!first.IsToken && second.IsToken))
                return false;

            if (first.IsToken && second.IsToken)
                return first.AsToken().Text == second.AsToken().Text;


            return first.AsNode().NormalizeWhitespace().ToString() == second.AsNode().NormalizeWhitespace().ToString();
            //if (first is SyntaxToken && second is SyntaxToken)
            //{
            //    return (first as SyntaxToken).Text == (second as SyntaxToken).Text;
            //}
            //return true;
        }
    }
}
