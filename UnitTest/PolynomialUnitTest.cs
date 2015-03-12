using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiMember;

namespace Opertor_UnitTest
{
    [TestClass]
    public class PolynomialUnitTest
    {
        #region Operator +
        [TestMethod]
        public void AdditionPolynomialTestMethod1()
        {
            Polynomial p1 = new Polynomial(2, 3, 4);
            Polynomial p2 = new Polynomial(5, 2, 3, 4);
            Polynomial p3 = p1 + p2;
            Assert.AreEqual("5x^3+4x^2+6x+8", p3.ToString());
        }
        [TestMethod]
        public void AdditionPolynomialTestMethod2()
        {
            Polynomial p1 = new Polynomial(2, 3, 4);
            Polynomial p2 = new Polynomial(0, 0, 0, 0);
            Polynomial p3 = p1 + p2;
            Assert.AreEqual("2x^2+3x+4", p3.ToString());
        }

        [TestMethod]
        public void AdditionPolynomialTestMethod3()
        {
            Polynomial p1 = new Polynomial(0, 0, 0);
            Polynomial p2 = new Polynomial(0, 0, 0, 0);
            Polynomial p3 = p1 + p2;
            Assert.AreEqual("0", p3.ToString());
        }

        [TestMethod]
        public void AdditionPolynomialTestMethod4()
        {
            Polynomial p1 = new Polynomial(0, 0, 1);
            Polynomial p2 = new Polynomial(1, 0, 0, 0);
            Polynomial p3 = p1 + p2;
            Assert.AreEqual("x^3+1", p3.ToString());
        }

        [TestMethod]
        public void AdditionPolynomialTestMethod5()
        {
            Polynomial p1 = new Polynomial(7, -5, -1);
            Polynomial p2 = new Polynomial(-2, 1, 2, 6);
            Polynomial p3 = p1 + p2;
            Assert.AreEqual("-2x^3+8x^2-3x+5", p3.ToString());
        }
        #endregion

        #region Operator -
        [TestMethod]
        public void SubstractPolynomialTestMethod1()
        {
            Polynomial p1 = new Polynomial(6);
            Polynomial p2 = new Polynomial(2, 5);
            Polynomial p3 = p1 - p2;
            Assert.AreEqual("-2x+1", p3.ToString());
        }
        [TestMethod]
        public void SubstractPolynomialTestMethod2()
        {
            Polynomial p1 = new Polynomial(4, 3, 2, 8);
            Polynomial p2 = new Polynomial(3, 4, 5);
            Polynomial p3 = p1 - p2;
            Assert.AreEqual("4x^3-2x+3", p3.ToString());
        }
        [TestMethod]
        public void SubstractPolynomialTestMethod3()
        {
            Polynomial p1 = new Polynomial(0, 0, 0);
            Polynomial p2 = new Polynomial(0, 0, 0);
            Polynomial p3 = p1 - p2;
            Assert.AreEqual("0", p3.ToString());
        }
        #endregion

        #region Operator *
        [TestMethod]
        public void MultiplyPolynomialTestMethod1()
        {
            Polynomial p1 = new Polynomial(7, 5, -6, -4);
            Polynomial p2 = new Polynomial(-1, 5, 0, 3);
            Polynomial p3 = p1 * p2;
            Assert.AreEqual("-7x^6+30x^5+31x^4-5x^3-5x^2-18x-12", p3.ToString());
        }
        [TestMethod]
        public void MultiplyPolynomialTestMethod2()
        {
            Polynomial p1 = new Polynomial(7, 5, -6, -4);
            Polynomial p2 = new Polynomial(0);
            Polynomial p3 = p1 * p2;
            Assert.AreEqual("0", p3.ToString());
        }
        [TestMethod]
        public void MultiplyPolynomialTestMethod3()
        {
            Polynomial p1 = new Polynomial(1);
            Polynomial p2 = new Polynomial(-1, 5, 0, 3);
            Polynomial p3 = p1 * p2;
            Assert.AreEqual("-1x^3+5x^2+3", p3.ToString());
        }
        #endregion

        #region Operator == !=
        [TestMethod]
        public void EqualsPolynomialTestMethod1()
        {
            Polynomial p1 = new Polynomial(5, 4, 3);
            Polynomial p2 = new Polynomial(5, 4, 3);
            bool result = p1 == p2;
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void EqualsPolynomialTestMethod2()
        {
            Polynomial p1 = new Polynomial(5, 4, 3);
            Polynomial p2 = new Polynomial(5, 4, 3);
            bool result = p1 != p2;
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void EqualsPolynomialTestMethod3()
        {
            Polynomial p1 = new Polynomial(5, 5, 3);
            Polynomial p2 = new Polynomial(5, 4, 3);
            bool result = p1 == p2;
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void EqualsPolynomialTestMethod4()
        {
            Polynomial p1 = new Polynomial(5, 3);
            Polynomial p2 = new Polynomial(5, 4, 3);
            bool result = p1 != p2;
            Assert.AreEqual(true, result);
        }
        #endregion

        #region Derivative
        [TestMethod]
        public void DerivativePolynomialTestMethod1()
        {
            Polynomial p1 = new Polynomial(5, 4, 3);
            Polynomial result = p1.Derivative();
            Assert.AreEqual("10x+4", result.ToString());
        }

        [TestMethod]
        public void DerivativePolynomialTestMethod2()
        {
            Polynomial p1 = new Polynomial(3, 1, -5, 0, 3);
            Polynomial result = p1.Derivative();
            Assert.AreEqual("12x^3+3x^2-10x", result.ToString());
        }
        #endregion

        #region Calculate
        [TestMethod]
        public void CalculatePolynomialTestMethod1()
        {
            Polynomial p1 = new Polynomial(2, 2, 0, -10);
            double result = p1.Calculate(2);
            Assert.AreEqual(14, result);
        }

        [TestMethod]
        public void CalculatePolynomialTestMethod2()
        {
            Polynomial p1 = new Polynomial(2, 2, 0, -10);
            double result = p1.Calculate(0);
            Assert.AreEqual(-10, result);
        } 
        #endregion

    }
}
