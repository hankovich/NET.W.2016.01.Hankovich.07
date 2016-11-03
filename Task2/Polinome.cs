using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{

    public class Polinome
    {
        private readonly double[] factors;

        public Polinome(Polinome old)
        {
            factors = new double[old.factors.Length];
            old.factors.CopyTo(factors, factors.Length);
        }

        public Polinome(params double[] resource)
        {
            if (resource == null)
                throw new ArgumentNullException();
            if (resource.Length == 0)
                throw new ArgumentException();

            int expectedDegree = resource.Length - 1;

            for (; expectedDegree >= 0; expectedDegree--)
                if (!resource[expectedDegree].Equals(0))
                    break;

            if (expectedDegree == 0)
            {
                factors = new double[expectedDegree + 1];
                factors[0] = resource[0];
                return;
            }

            factors = new double[expectedDegree + 1];
            for (int i = 0; i <= expectedDegree; i++)
                factors[i] = resource[i];
        }

        public int Degree => factors.Length - 1;
        public double[] Factors => factors;

        public static Polinome operator +(Polinome a, Polinome b)
        {
            if (b.Degree > a.Degree)
            {
                Swap(ref a, ref b);
            }

            double[] newFactors = new double[a.Degree + 1];

            a.factors.CopyTo(newFactors, 0);

            for (int i = 0; i <= b.Degree; i++)
            {
                checked
                {
                    newFactors[i] += b.factors[i];
                }
            }

            return new Polinome(newFactors);
        }

        public static Polinome operator -(Polinome a, Polinome b)
        {
            return a + (-b);
        }

        public static Polinome operator *(Polinome a, Polinome b)
        {
            int degRes = a.Degree + b.Degree;
            double[] coefficentsRes = new double[degRes + 2];
            for (int i = 0; i <= a.Degree; i++)
                for (int j = 0; j <= b.Degree; j++)
                    checked
                    {
                        coefficentsRes[i + j] += a.factors[i] * b.factors[j];
                    }
            return new Polinome(coefficentsRes);
        }

        public static Polinome operator -(Polinome a)
        {
            return -1*a;
        }

        public static Polinome operator +(Polinome a)
        {
            return +1*a;
        }

        public static Polinome operator *(double k, Polinome a)
        {
            double[] newFactors = new double[a.Degree + 1];
            for (int i = 0; i <= a.Degree; i++)
                newFactors[i] = k*a.factors[i];
            return new Polinome(newFactors);
        }

        public static Polinome operator *(Polinome a, double k)
        {
            return k*a;
        }

        public static bool operator ==(Polinome a, Polinome b)
        {
            if (a.Degree != b.Degree)
                return false;
            for (int i = 0; i <= a.Degree; i++)
            {
                if (!a.factors[i].Equals(b.factors[i]))
                    return false;
            }
            return true;
        }

        public static bool operator !=(Polinome a, Polinome b)
        {
            return (!(a == b));
        }

        public double ValueAtPoint(double x)
        {
            double result = factors[Degree];

            for (int i = Degree - 1; i >= 0; i--)
            {
                result = result*x + factors[i];
            }
            return result;
        }

        public override string ToString()
        {
            var result = new StringBuilder(string.Empty);
            for (int i = Degree; i > 1; i--)
            {
                if (!factors[i].Equals(0))
                    result.Append($"{Sign(factors[i], i)}{Math.Abs(factors[i])}x^{i}");
            }
            if (Degree >= 1 && !factors[1].Equals(0))
                result.Append($"{Sign(factors[1], 1)}{Math.Abs(factors[1])}x");
            if (!factors[0].Equals(0))
                result.Append($"{Sign(factors[0], 0)}{Math.Abs(factors[0])}");

            if (result.ToString().Equals(string.Empty))
                return "0";
            return result.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 0;
            for (int i = 0; i <= Degree; i++)
            {
                hash += RsHash(factors[i].ToString());
            }
            return hash;
        }

        public override bool Equals(object pol)
        {
            var polinome = pol as Polinome;
            return polinome?.factors != null && factors.SequenceEqual(polinome.factors);
        }

        #region private methods     

        private string Sign(double a, int number)
        {
            if (number == this.Degree)
                return (a > 0) ? string.Empty : "-";
            return (a > 0) ? "+" : "-";
        }


        private static void Swap(ref Polinome a, ref Polinome b)
        {
            Polinome temp;
            temp = a;
            a = b;
            b = temp;
        }

        private static int RsHash(string str)
        {
            const int b = 378551;
            int a = 63689;
            int hash = 0;

            foreach (char t in str)
            {
                hash = hash*a + t;
                a *= b;
            }
            return hash;
        }

        #endregion
    }

}
