using System;
using System.Collections.Generic;
using System.Text;

namespace AliCalc.Model
{
    public class Drug
    {
        public readonly string Name;
        public readonly double GramsPerMole;
        public readonly Mass Mass;
        public double Moles => Mass.g / GramsPerMole;

        public Drug(string name, Mass mass, double gramsPerMol) =>
            (Name, Mass, GramsPerMole) = (name, mass, gramsPerMol);
    }
}
