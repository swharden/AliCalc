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
        public static Volume MicroLiters(double uL) => new Volume(uL / 1e6);
        public static Volume MilliLiters(double mL) => new Volume(mL / 1e3);
        public static Volume Liters(double L) => new Volume(L);

        public static double operator /(Volume a, Volume b) => a.L / b.L;
        public static Volume operator /(Volume a, double b) => new Volume(a.L / b);
        public static Volume operator *(Volume a, double b) => new Volume(a.L * b);
        public static Volume operator *(double a, Volume b) => new Volume(a * b.L);
    }
}
