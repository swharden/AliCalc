using System;
using System.Collections.Generic;
using System.Text;

namespace AliCalc.Model
{
    public class Solution
    {
        public readonly Volume Volume;
        public readonly Concentration Concentration;

        public Solution(Volume volume, Concentration concentration) =>
            (Volume, Concentration) = (volume, concentration);
    }
}
