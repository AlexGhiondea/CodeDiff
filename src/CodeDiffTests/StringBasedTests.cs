using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System.Linq;

namespace CodeDiffTests
{
    [TestClass]
    public class StringBasedTests
    {
        [TestMethod]
        public void TokenValueModified1()
        {
            string before = @"class C{}";
            string after = @"class D{}";

            var codeDiff = CompilationHelpers.GetDiff(before, after);

            Assert.AreEqual(0, codeDiff.GetAdded().Count());
            Assert.AreEqual(0, codeDiff.GetRemoved().Count());
            Assert.AreEqual(1, codeDiff.GetModified().Count());
            Assert.AreEqual("C", codeDiff.GetModified().First().Before.ToString());
            Assert.AreEqual("D", codeDiff.GetModified().First().After.ToString());
        }

        [TestMethod]
        public void TokenAdded1()
        {
            string before = @"class C{}";
            string after = @"public class C{}";
            var codeDiff = CompilationHelpers.GetDiff(before, after);

            Assert.AreEqual(1, codeDiff.GetAdded().Count());
            Assert.AreEqual("public", codeDiff.GetAdded().First().After.ToString());
            Assert.AreEqual(0, codeDiff.GetRemoved().Count());
            Assert.AreEqual(0, codeDiff.GetModified().Count());
        }

        [TestMethod]
        public void TokenDeleted1()
        {
            string before = @"public class C{}";
            string after = @"class C{}";

            var codeDiff = CompilationHelpers.GetDiff(before, after);

            Assert.AreEqual(0, codeDiff.GetAdded().Count());
            Assert.AreEqual(1, codeDiff.GetRemoved().Count());
            Assert.AreEqual("public", codeDiff.GetRemoved().First().Before.ToString());
            Assert.AreEqual(0, codeDiff.GetModified().Count());
        }

        [TestMethod]
        public void NodeAdded1()
        {
            string before = @"class C{}";
            string after = @"class C{} class D{}";

            var codeDiff = CompilationHelpers.GetDiff(before, after);

            Assert.AreEqual(1, codeDiff.GetAdded().Count());
            Assert.AreEqual("class D{}", codeDiff.GetAdded().First().After.ToString());
            Assert.AreEqual(0, codeDiff.GetRemoved().Count());
            Assert.AreEqual(0, codeDiff.GetModified().Count());
        }

        [TestMethod]
        public void NodeAdded2()
        {
            string before = @"class C{}";
            string after = @"class C{ class D{} }";

            var codeDiff = CompilationHelpers.GetDiff(before, after);

            Assert.AreEqual(1, codeDiff.GetAdded().Count());
            Assert.AreEqual("class D{}", codeDiff.GetAdded().First().After.ToString());
            Assert.AreEqual(0, codeDiff.GetRemoved().Count());
            Assert.AreEqual(0, codeDiff.GetModified().Count());
        }

        [TestMethod]
        public void NodeDeletedInternal1()
        {
            string before = @"class C{class D{}}";
            string after = @"class C{}";

            var codeDiff = CompilationHelpers.GetDiff(before, after);

            Assert.AreEqual(0, codeDiff.GetAdded().Count());
            Assert.AreEqual(1, codeDiff.GetRemoved().Count());
            Assert.AreEqual("class D{}", codeDiff.GetRemoved().First().Before.ToString());
            Assert.AreEqual(0, codeDiff.GetModified().Count());
        }

        [TestMethod]
        public void NodeDeletedEnd1()
        {
            string after = @"class C{}";
            string before = @"class C{} class D{}";

            var codeDiff = CompilationHelpers.GetDiff(before, after);

            Assert.AreEqual(0, codeDiff.GetAdded().Count());
            Assert.AreEqual(1, codeDiff.GetRemoved().Count());
            Assert.AreEqual("class D{}", codeDiff.GetRemoved().First().Before.ToString());
            Assert.AreEqual(0, codeDiff.GetModified().Count());
        }

        [TestMethod]
        public void Identical1()
        {
            string after = @"class C{}";
            string before = @"class C{}";

            var codeDiff = CompilationHelpers.GetDiff(before, after);

            Assert.AreEqual(0, codeDiff.GetAdded().Count());
            Assert.AreEqual(0, codeDiff.GetRemoved().Count());
            Assert.AreEqual(0, codeDiff.GetModified().Count());
        }

        [TestMethod]
        public void Identical2()
        {
            string after = @"";
            string before = @"";

            var codeDiff = CompilationHelpers.GetDiff(before, after);

            Assert.AreEqual(0, codeDiff.GetAdded().Count());
            Assert.AreEqual(0, codeDiff.GetRemoved().Count());
            Assert.AreEqual(0, codeDiff.GetModified().Count());
        }


        [TestMethod]
        public void NodesAddedInBetweenOtherNodes1()
        {
            string before = @"class C{ 
void Foo(){
Icon i = new Icon(icon);
box.Image = i.ToBitmap();
Controls.Add(box);
}
}";

            string after = @"
class C{ 
void Foo(){
Icon i = new Icon(icon);
box.Location = new System.Drawing.Point();
box.TabStop = false;
box.Image = i.ToBitmap();
Controls.Add(box);
}
}";

            var codeDiff = CompilationHelpers.GetDiff(before, after);

            Assert.AreEqual(2, codeDiff.GetAdded().Count());
            Assert.AreEqual(0, codeDiff.GetRemoved().Count());
            Assert.AreEqual(0, codeDiff.GetModified().Count());
        }

    }
}
