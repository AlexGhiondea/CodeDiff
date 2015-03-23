using CodeDiffLib;
using CodeDiffLib.Changes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace CodeDiffTests
{
    static class CompilationHelpers
    {
        public static SyntaxNode GetSyntaxNode(string s)
        {
            return SyntaxFactory.ParseSyntaxTree(s).GetRoot();
        }

        public static Changes<SyntaxNodeOrToken> GetDiff(string before, string after)
        {
            return TreeDiff.Compare(GetSyntaxNode(before), GetSyntaxNode(after));
        }
    }
}
