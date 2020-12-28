using System;
using System.Collections.Generic;
using System.Text;

namespace AliCalc.Model
{
    public class Volume
    {
        public readonly double L;
        public double mL => L * 1e3;
        public double uL => L * 1e6;
        public double nL => L * 1e9;
        public double pL => L * 1e12;

        public Volume(double L) => this.L = L;
        public static Volume MilliLiters(double mL) => new Volume(mL / 1e3);
    }
}
