using System;


namespace GeometryLib
{
    public abstract class TGeometryRoot
    {
        public abstract double GetResult();
    }

    public class TTriangle : TGeometryRoot
    {
        public double dA, dB, dC;
        public TTriangle (double a,double b, double c)
        {
            dA = a;
            dB = b;
            dC = c;
        }
        override public double GetResult()
        {
            double p = (dA + dB + dC) / 2;

            return Math.Sqrt(p * (p - dA) * (p - dB) * (p - dC));

        }
    }

    public class TCircle:TGeometryRoot
    {
        public double dR;
        public TCircle(double r)
        {
            dR = r;
        }
        public override double GetResult()
        {
            return Math.PI * dR * dR;
        }
    }
}
