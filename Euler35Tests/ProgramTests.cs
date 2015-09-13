using Microsoft.VisualStudio.TestTools.UnitTesting;
using Euler35;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler35.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void NumberFromTest_EmptyArray()
        {
            int result = Program.NumberFrom(new int[] { });
            Assert.AreEqual<int>(result, 0);
        }

        [TestMethod()]
        public void NumberFromTest_SingleDigit()
        {
            int result = Program.NumberFrom(new int[] { 7 });
            Assert.AreEqual<int>(result, 7);
        }

        [TestMethod()]
        public void NumberFromTest_DoubleDigit()
        {
            int result = Program.NumberFrom(new int[] {3, 9 });
            Assert.AreEqual<int>(result, 39);
        }

        [TestMethod()]
        public void NumberFromTest_FromNumbersIn()
        {
            int result = Program.NumberFrom(Program.NumbersIn(37));
            Assert.AreEqual<int>(result, 37);
        }

        [TestMethod()]
        public void SmallestPermutation_SingleDigit()
        {
            int result = Program.SmallestPermutation(7);
            Assert.AreEqual<int>(result, 7);
        }

        [TestMethod()]
        public void SmallestPermutation_AlreadySmallest()
        {
            int result = Program.SmallestPermutation(37);
            Assert.AreEqual<int>(result, 37);
        }

        [TestMethod()]
        public void SmallestPermutation_DoubleDigit()
        {
            int result = Program.SmallestPermutation(96);
            Assert.AreEqual<int>(result, 69);
        }

        [TestMethod()]
        public void Permutations_3DifferentDigits()
        {
            int[] actual = Program.Permutations(179).ToArray();
            int[] expected = { 179, 791, 917};
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Permutations_3Digits2Different()
        {
            int[] actual = Program.Permutations(334).ToArray();
            int[] expected = { 334, 343, 433 };
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}