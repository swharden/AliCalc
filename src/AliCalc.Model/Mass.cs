using System;
using System.Collections.Generic;
using System.Text;

namespace AliCalc.Model
{
    public class Mass
    {
        public readonly double g;
        public double mg => g * 1e3;
        public double ug => g * 1e6;
        public double ng => g * 1e9;
        public double pg => g * 1e12;

        private Mass(double grams) => g = grams;

        public static Mass FromGrams(double g) => new Mass(g);
        public static Mass FromMilligrams(double mM) => new Mass(mM / 1e3);
        public static Mass FromMicrograms(double uM) => new Mass(uM / 1e6);
        public static Mass FromNanograms(double nM) => new Mass(nM / 1e9);
        public static Mass FromPicograms(double pM) => new Mass(pM / 1e12);
    }
}
