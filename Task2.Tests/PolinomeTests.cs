using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task2.Tests
{
    [TestFixture]
    public class PolinomeTests
    {
        [Test]
        public void Polinome_P1P2_SumOfP1P2()
        {
            Polinome p = new Polinome(1, 2, 3);
            Polinome p1 = new Polinome(4, 2, 1); 
            Polinome expected = new Polinome(5, 4, 4);
            CollectionAssert.AreEqual(expected.Factors, (p + p1).Factors);
        }

        [Test]
        public void Polinome_P1P2_OneMoreSumOfP1P2()
        {
            Polinome p = new Polinome(1, 2, 3);
            Polinome p1 = new Polinome(1, 2, 3, 4);
            Polinome expected = new Polinome(2, 4, 6, 4);
            CollectionAssert.AreEqual(expected.Factors, (p + p1).Factors);
        }

        [Test]
        public void Polinome_P1P2_SubOfP1P2()
        {
            Polinome p = new Polinome(1, 2, 3);
            Polinome p1 = new Polinome(4, 2, 1);
            Polinome expected = new Polinome(-3, 0, 2);
            CollectionAssert.AreEqual(expected.Factors, (p - p1).Factors);
        }

        [Test]
        public void Polinome_P1P2_Zero()
        {
            Polinome p = new Polinome(1, 2, 3);
            Polinome p1 = new Polinome(1, 2, 3);
            Polinome expected = new Polinome(0);
            CollectionAssert.AreEqual(expected.Factors, (p - p1).Factors);
        }

        [Test]
        public void Polinome_P1_MinusP1()
        {
            Polinome p = new Polinome(1, 2, 3);
            Polinome expected = new Polinome(-1, -2, -3);
            CollectionAssert.AreEqual(expected.Factors, (-p).Factors);
        }

        [Test]
        public void Polinome_P1_PlusP1()
        {
            Polinome p = new Polinome(1, 2, 3);
            Polinome expected = new Polinome(1, 2, 3);
            CollectionAssert.AreEqual(expected.Factors, (+p).Factors);
        }

        [Test]
        public void Polinome_P1_kP1()
        {
            Polinome p = new Polinome(1, 2, 3);
            Polinome expected = new Polinome(2, 4, 6);
            CollectionAssert.AreEqual(expected.Factors, (2*p).Factors);
        }

        [Test]
        public void Polinome_P1_P10()
        {
            Polinome p = new Polinome(1, 2, 3);
            Polinome expected = new Polinome(0);
            CollectionAssert.AreEqual(expected.Factors, (p*0).Factors);
        }

        [Test]
        public void Polinome_P1P2_MulOfP1P2()
        {
            Polinome p = new Polinome(1, 1);
            Polinome p1 = new Polinome(-1, 1);
            Polinome expected = new Polinome(-1, 0, 1);
            CollectionAssert.AreEqual(expected.Factors, (p * p1).Factors);
        }

        [Test]
        public void Polinome_P1P2_EqualsOfP1P2()
        {
            Polinome p = new Polinome(1, 2, 3);
            Polinome p1 = new Polinome(1, 2, 3);
            Assert.AreEqual(true, p1.Equals(p));
        }

        [Test]
        public void Polinome_P1P2_NotEqualsOfP1P2()
        {
            Polinome p = new Polinome(1, 2, 3);
            Polinome p1 = new Polinome(4, 2, 1);
            Assert.AreEqual(false, p1.Equals(p));
        }

        [Test]
        public void Polinome_P1P2_GetHashCodeNotEqual()
        {
            Polinome p = new Polinome(1, 2, 3);
            Polinome p1 = new Polinome(4, 2, 1);
            Assert.AreNotEqual(p.GetHashCode(), p1.GetHashCode());
        }

        [Test]
        public void Polinome_P1P2_GetHashCodeEqual()
        {
            Polinome p = new Polinome(1, 2, 3, 0);
            Polinome p1 = new Polinome(1, 2, 3);
            Assert.AreEqual(p.GetHashCode(), p1.GetHashCode());
        }

        [Test]
        public void Polinome_P1_ValueAtPoint()
        {
            Polinome p = new Polinome(1, 2, 3, 0, 7);
            double expected = 1 + 2*2 + 3*2*2 + 7*2*2*2*2;
            Assert.AreEqual(expected, p.ValueAtPoint(2));
        }
    }
}
