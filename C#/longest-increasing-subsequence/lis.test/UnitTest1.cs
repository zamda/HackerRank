using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using longest_increasing_subsequence;
using System.Collections.Generic;

namespace lis.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int pos = Program.FindPredecessor(new List<int>() { 1, 2, 4 }, 3);
            Assert.AreEqual(1, pos);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int pos = Program.FindPredecessor(new List<int>() { 1, 2, 4 }, 5);
            Assert.AreEqual(2, pos);
        }


        [TestMethod]
        public void TestMethod3()
        {
            int pos = Program.FindPredecessor(new List<int>() { 1, 2, 4 }, 0);
            Assert.AreEqual(-1, pos);
        }


        [TestMethod]
        public void TestMethod4()
        {
            int pos = Program.FindPredecessor(new List<int>() { }, 0);
            Assert.AreEqual(-1, pos);
        }
    }
}
