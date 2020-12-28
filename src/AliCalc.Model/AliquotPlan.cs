using System;
using System.Collections.Generic;
using System.Text;

namespace AliCalc.Model
{
    public class AliquotPlan
    {
        public readonly Syringe Syringe;
        public readonly Volume TotalStockVolume;
        public readonly Volume AliquotVolume;
        public double AliquotCount => TotalStockVolume / AliquotVolume;

        public AliquotPlan(Drug drug, StockConcentration stockConcentration, BathConcentration bathConcentration)
        {
            Syringe = new Syringe(Volume.MilliLiters(10), bathConcentration, 50);
            TotalStockVolume = Volume.Liters(drug.Moles / stockConcentration.MolesPerLiter);
            AliquotVolume = Syringe.Volume / (stockConcentration / Syringe.Concentration);
        }
    }
}
