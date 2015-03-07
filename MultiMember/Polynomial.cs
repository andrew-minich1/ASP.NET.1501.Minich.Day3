using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiMember
{
    public class Polynomial
    {
        private double[] factors;
        private int exponent;

        #region Indexer
        public int this[int number]
        {
            set
            {
                if (number >= 0 || number < factors.Length)
                {
                    this.factors[number] = value;
                }
            }
        }
        #endregion

        #region Constructor
        private Polynomial() { }
        public Polynomial(string str)
        {

        }
        public Polynomial(params double[] coefficients)
        {
            this.factors = coefficients;
            this.exponent = coefficients.Length - 1;
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < factors.Length - 1; i++)
            {
                if (factors[i] == 0) continue;
                if (factors[i] == 1)
                {
                    result.AppendFormat("x^{0}+", exponent - i);
                }
                else
                {
                    result.AppendFormat("{0}x^{1}+", factors[i], exponent - i);
                }
            }
            if (factors[factors.Length - 1] != 0) result.Append(factors[factors.Length - 1]);
            else if (result.Length != 0) result.Remove(result.Length - 1, 1);
            else return "0";
            result.Replace("+-", "-");
            result.Replace("^1", string.Empty);
            return result.ToString();
        }
        #endregion

        #region Equals
        public override bool Equals(Object obj)
        {
            if (obj == null || !(obj is Polynomial))
                return false;
            else
            {
                Polynomial temp = (Polynomial)obj;
                if (this.factors.Length == temp.factors.Length)
                {
                    for (int i = 0; i < temp.factors.Length; i++)
                    {
                        if (factors[i] != temp.factors[i]) return false;
                    }
                    return true;
                }
                return false;
            }
        }
        #endregion

        #region GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        #region Derivative();
        public Polynomial Derivative()
        {
            Polynomial result = new Polynomial(new double[this.factors.Length - 1]);
            for (int i = 0; i < this.factors.Length - 1; i++)
            {
                result.factors[i] = this.factors[i] * (this.exponent - i);
            }
            return result;
        }
        #endregion

        #region Calculate
        public double Calculate(double number)
        {
            if (number == 0) return factors[factors.Length - 1];
            double result = 0;
            for (int i = 0; i < factors.Length - 1; i++)
            {
                result = (result + factors[i]) * number;
            }
            result += factors[factors.Length - 1];
            return result;
        } 
        #endregion

        #region Operator +
        public static Polynomial operator +(Polynomial first, Polynomial second)
        {
            double[] result = new double[Math.Max(first.factors.Length, second.factors.Length)];
            first.factors.CopyTo(result, result.Length - first.factors.Length);
            for (int i = second.factors.Length - 1, y = result.Length - 1; i > -1; i--, y--)
            {
                result[y] += second.factors[i];
            }
            return new Polynomial(result);
        }
        #endregion

        #region Operator -
        public static Polynomial operator -(Polynomial first, Polynomial second)
        {
            double[] result = new double[Math.Max(first.factors.Length, second.factors.Length)];
            first.factors.CopyTo(result, result.Length - first.factors.Length);
            for (int i = second.factors.Length - 1, y = result.Length - 1; i > -1; i--, y--)
            {
                result[y] -= second.factors[i];
            }
            return new Polynomial(result);
        }
        #endregion

        #region Operator *
        public static Polynomial operator *(Polynomial first, Polynomial second)
        {
            double[] result = new double[first.factors.Length + second.factors.Length - 1];
            for (int i = 0; i < first.factors.Length; i++)
            {
                for (int y = 0; y < second.factors.Length; y++)
                {
                    result[i + y] += first.factors[i] * second.factors[y];
                }
            }
            return new Polynomial(result);
        }
        #endregion

        #region Operator ==
        public static bool operator ==(Polynomial first, Polynomial second)
        {
            if (first.factors.Length != second.factors.Length) return false;
            for (int i = 0; i < first.factors.Length; i++)
            {
                if (first.factors[i] != second.factors[i]) return false;
            }
            return true;
        }
        #endregion

        #region Operator !=
        public static bool operator !=(Polynomial first, Polynomial second)
        {
            return !(first == second);
        }
        #endregion
    }
}
