using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicDLL
{
    public class MathLogic
    {

        private static readonly int MIN_I = 1;
        private static readonly int MAX_I = 15;
        private static readonly double DEFAULT_X_MULTIPLIER = 0.5;
        private static readonly double DEFAULT_VALUE = 0;
        private static readonly int DEFAULT_DIVIDER = 12;
        private static readonly int DEFAULT_MULTIPLIER = 2;
        private static readonly int SECOND_POWER = 2;
        private static readonly int THIRD_POWER = 3;
        private static readonly int FORTH_POWER = 4;
        private static readonly int FIFTH_POWER = 5;


        public double CountY(double r0, double b, double h, double l, double E, double t, double P)
        {

            double secondPart = DEFAULT_VALUE;

            double I = CountI(b, h);
            double x = CountX(l);

            double firstPart = ((DEFAULT_MULTIPLIER * P * Math.Pow(l, THIRD_POWER * FORTH_POWER)) / (Math.Pow(Math.PI, FIFTH_POWER) * E * I));

            for (int i = MIN_I; i < MAX_I; i++)
            {

                double Pi = CountPi(i, l, E, r0, b, h);
                double sin = Math.Sin((i * Math.PI * x / l));
                double cos = Math.Cos(Pi * t);
                double addedPart = (-1 * Math.Exp(i - 1 / 2) / Math.Pow(i, FORTH_POWER)) * sin * cos;

                secondPart += addedPart;

            }

            double result = firstPart * secondPart;

            return result;
        }

        private double CountX(double l)
        {

            double result = l * DEFAULT_X_MULTIPLIER;

            return result;
        }

        private double CountPi(int i, double l, double E, double r0, double b, double h)
        {

            double F = CountF(b, h);
            double I = CountI(b, h);

            double firstPart = (Math.Pow(i, SECOND_POWER) * Math.Pow(Math.PI, SECOND_POWER)) / Math.Pow(l, SECOND_POWER);
            double sqrtPart = Math.Sqrt((E * I) / (r0 * F));

            double result = firstPart * sqrtPart;

            return result;

        }

        private double CountI(double b, double h)
        {

            double result = (b * Math.Pow(h, THIRD_POWER)) / DEFAULT_DIVIDER;

            return result;

        }

        private double CountF(double b, double h)
        {

            double result = b * h;

            return result;

        }

    }
}
