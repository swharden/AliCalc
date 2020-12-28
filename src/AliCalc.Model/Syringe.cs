using System;
using System.Collections.Generic;
using System.Text;

namespace AliCalc.Model
{
    public class Syringe : Solution
    {
        public readonly double DilutionFactor;

        public Syringe(Volume volume, BathConcentration concentration, double dilutionFactor) : base(volume, concentration * dilutionFactor)
        {
            DilutionFactor = dilutionFactor;
        }
    }
}
