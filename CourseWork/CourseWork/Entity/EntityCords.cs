using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Entity
{
    public class EntityCords
    {
        private static readonly double DEFAULT_AMOUNT_OF_THINGS = 0;

        private double r0 = DEFAULT_AMOUNT_OF_THINGS;
        private double P = DEFAULT_AMOUNT_OF_THINGS;
        private double b = DEFAULT_AMOUNT_OF_THINGS;
        private double h = DEFAULT_AMOUNT_OF_THINGS;
        private double l = DEFAULT_AMOUNT_OF_THINGS;
        private double E = DEFAULT_AMOUNT_OF_THINGS;
        private double t0 = DEFAULT_AMOUNT_OF_THINGS;
        private double tk = DEFAULT_AMOUNT_OF_THINGS;
        private double th = DEFAULT_AMOUNT_OF_THINGS;

        private List<double> cordsY = new List<double>();
        private List<double> cordsT = new List<double>();

        public EntityCords(double r0, double P, double b, double h, double l, double E, double t0, double tk, double th)
        {
            this.r0 = r0;
            this.P = P;
            this.b = b;
            this.h = h;
            this.l = l;
            this.E = E;
            this.t0 = t0;
            this.tk = tk;
            this.th = th;
        }

        public void Clear()
        {
            cordsT.Clear();
            cordsY.Clear();
        }

        public double GetTH()
        {
            return th;
        }

        public double GetTK()
        {
            return tk;
        }

        public double GetT0()
        {
            return t0;
        }

        public double GetE()
        {
            return E;
        }

        public double GetL()
        {
            return l;
        }

        public double GetH()
        {
            return h;
        }

        public double GetB()
        {
            return b;
        }

        public double GetR()
        {
            return r0;
        }

        public double GetP()
        {
            return P;
        }


        public void AddY(double y)
        {
            cordsY.Add(y);
        }

        public void AddT(double t)
        {
            cordsT.Add(t);
        }

        public List<double> GetListY()
        {
            return cordsY;
        }

        public List<double> GetListT()
        {
            return cordsT;
        }


    }
}
