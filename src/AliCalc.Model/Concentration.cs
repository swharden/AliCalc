using System;
using System.Collections.Generic;
using System.Text;

namespace AliCalc.Model
{
    /// <summary>
    /// Final concentration of solute in the bath
    /// </summary>
    public class BathConcentration : Concentration
    {
        public BathConcentration(double molarity) : base(molarity) { }
        public BathConcentration(Concentration c) : base(c.M) { }
    }

    /// <summary>
    /// Concentration of solute in the stock solution used to make freezer aliquots
    /// </summary>
    public class StockConcentration : Concentration
    {
        public StockConcentration(double molarity) : base(molarity) { }
        public StockConcentration(Concentration c) : base(c.M) { }
    }

    /// <summary>
    /// Describes a concentration in Mol/L
    /// </summary>
    public class Concentration
    {
        public readonly double M;
        public double mM => M * 1e3;
        public double uM => M * 1e6;
        public double nM => M * 1e9;
        public double pM => M * 1e12;

        protected Concentration(double molarity) => M = molarity;

        public static Concentration operator *(Concentration c, double value) => new Concentration(c.M * value);
        public static Concentration operator /(Concentration c, double value) => new Concentration(c.M * value);

        public static Concentration MilliMol(double mM) => new Concentration(mM / 1e3);
        public static Concentration MicroMol(double uM) => new Concentration(uM / 1e6);
        public static Concentration NanoMol(double nM) => new Concentration(nM / 1e9);
        public static Concentration PicoMol(double pM) => new Concentration(pM / 1e12);
    }
}
