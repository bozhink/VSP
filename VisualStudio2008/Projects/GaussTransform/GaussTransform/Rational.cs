namespace Rational
{
    class Rational
    {
        public ulong Numerator;
        public ulong Denominator;

        public Rational(ulong _N, ulong _D)
        {
            this.Numerator = _N;
            this.Denominator = _D;
            this.rungcd();
        }

        public Rational(ulong _N)
        {
            this.Numerator = _N;
            this.Denominator = 1;
        }

        public Rational(Rational _S)
        {
            this.Numerator = _S.Numerator;
            this.Denominator = _S.Denominator;
        }

        public void rungcd()
        {
            ulong x = gcd(this.Numerator, this.Denominator);
            this.Numerator = this.Numerator / x;
            this.Denominator = this.Denominator / x;
        }

        public static ulong gcd(ulong u, ulong v)
        {
            if (u == v) return v;
            if (u == 0) return v;
            if (v == 0) return u;
            if (u % 2 == 0)
            {
                if (v % 2 == 0) return (2 * gcd(u / 2, v / 2));
                else return gcd(u / 2, v);
            }
            else if (v % 2 == 0) return gcd(u, v / 2);
            else
            {
                if (u >= v) return gcd((u - v) / 2, v);
                else return gcd((v - u) / 2, u);
            }
        }

        public void inv()
        {
            ulong x = this.Denominator; 
            this.Denominator = this.Numerator;
            this.Numerator = x;
        }

        public Rational Reciprocal()
        {
            return new Rational(this.Denominator, this.Numerator);
        }

        public static Rational sum(Rational a, Rational b)
        {
            ulong zn = gcd(a.Numerator, b.Numerator);
            ulong zd = gcd(a.Denominator, b.Denominator); ;
            ulong an = a.Numerator / zn;
            ulong bn = b.Numerator / zn;
            ulong ad = a.Denominator / zd;
            ulong bd = b.Denominator / zd;
            ulong dd = gcd(zn, zd);
            return new Rational((zn / dd) * (an * bd + bn * ad), ad * bd * (zd / dd));
        }
    }

    static class Gauss
    {
        static Rational Zero = new Rational(0, 1);

        public static Rational Gauss1(Rational a, Rational b)
        {
            Rational Result = new Rational(a.Denominator * b.Numerator, a.Numerator * b.Numerator + b.Denominator * a.Denominator);
            Result.rungcd();
            return (Rational.sum(a, b.Reciprocal())).Reciprocal();
        }

        public static Rational GaussCode(Rational[] a)
        {
            int n = a.Length;
            int i;
            Rational tmp = a[n-1];
            for (i = n - 2; i >= 0; i--)
            {
                tmp = Gauss1(a[i], tmp);
                tmp.inv();
            }
            tmp.inv();
            return tmp;
        }

        public static Rational phi(Rational x)
        {
            if (x.Numerator != 0)
            {
                return new Rational(x.Denominator - (x.Denominator / x.Numerator) * x.Numerator, x.Numerator);
            }
            else
            {
                return Zero;
            }
        }

        public static void GaussDecode(Rational x, int Length, out ulong[] Result)
        {
            Result = new ulong[Length];
            int i;
            Rational s = new Rational(x);
            for (i = 0; i < Length; i++)
            {
                if (s.Numerator != 0)
                {
                    Result[i] = s.Denominator / s.Numerator;
                }
                else
                {
                    Result[i] = 0;
                }
                s = phi(s);
            }
        }


    }
}