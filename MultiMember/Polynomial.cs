using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiMember
{
    public sealed class Polynomial
    {
        private double[] factors;
        private int exponent;
        public double Exponent
        {
            get { return exponent; }
        }

        #region Indexer
        public double this[int number]
        {
            private set
            {
                try
                {
                    this.factors[number] = value;
                }
                catch { throw new FormatException("NotFoundExeption"); }
            }
            get
            {
                try
                {
                    return factors[number];
                }
                catch { throw new FormatException("NotFoundExeption"); }
            }
        }
        #endregion

        #region Constructor
        private Polynomial() { }

        public Polynomial(params double[] coefficients)
        {
            if (coefficients == null) throw new NullReferenceException();
            this.factors = new double[coefficients.Length];
            coefficients.CopyTo(this.factors, 0);
            this.exponent = coefficients.Length - 1;
        }
        public Polynomial(Polynomial polynomial)
            : this(polynomial.factors)
        {

        }
        #endregion

        #region ToString
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < factors.Length - 1; i++)
            {
                if (this[i] == 0) continue;
                if (this[i] == 1)
                {
                    result.AppendFormat("x^{0}+", exponent - i);
                }
                else
                {
                    result.AppendFormat("{0}x^{1}+", this[i], exponent - i);
                }
            }
            if (factors[factors.Length - 1] != 0) result.Append(this[factors.Length - 1]);
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
            if (obj == null || !(obj is Polynomial)) return false;
            Polynomial temp = (Polynomial)obj;
            if (this.factors.Length != temp.factors.Length) return false;
            for (int i = 0; i < temp.factors.Length; i++)
            {
                if (this[i] != temp[i]) return false;
            }
            return true;
        }
        #endregion

        #region GetHashCode
        public override int GetHashCode()
        {
            return factors.GetHashCode();
        }
        #endregion

        #region Derivative();
        public Polynomial Derivative()
        {
            Polynomial result = new Polynomial(new double[this.factors.Length - 1]);
            for (int i = 0; i < this.factors.Length - 1; i++)
            {
                result[i] = this[i] * (this.Exponent - i);
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
                result = (result + this[i]) * number;
            }
            result += this[factors.Length - 1];
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
                result[y] += second[i];
            }
            return new Polynomial(result);
        }
        #endregion

        #region Operator -
        public static Polynomial operator -(Polynomial first, Polynomial second)
        {
            return first + (-second);
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
                    result[i + y] += first[i] * second[y];
                }
            }
            return new Polynomial(result);
        }
        #endregion

        #region Operator ==
        public static bool operator ==(Polynomial first, Polynomial second)
        {
            return first.Equals(second);
        }
        #endregion

        #region Operator !=
        public static bool operator !=(Polynomial first, Polynomial second)
        {
            return !(first == second);
        }
        #endregion

        #region Operator -
        public static Polynomial operator -(Polynomial first)
        {
            Polynomial result = new Polynomial(first);
            for (int i = 0; i < result.factors.Length; i++)
            {
                result[i] = -result[i];
            }
            return result;
        }
        #endregion

    }
}
