using System;
using System.Collections.Generic;
using System.Text;

namespace AliCalc.Model
{
    public class AliquotPlan
    {
        public const double SyringeVolume_L = 10 * 1e-3;
        public const double SyringeDilutionFactor = 50;

        public readonly double TotalStockVolume_L = double.NaN;
        public readonly double AliquotVolume_L = double.NaN;
        public double AliquotCount => TotalStockVolume_L / AliquotVolume_L;

        public readonly string Drug;
        public readonly string Solvent;
        public readonly double DrugMassG;
        public readonly double DrugMW;
        public readonly double StockM;
        public readonly double BathM;

        public AliquotPlan(string drug, double massG, double mw, string solvent, double stockM, double bathM)
        {
            (Drug, Solvent, DrugMassG, DrugMW, StockM, BathM) = (drug, solvent, massG, mw, stockM, bathM);

            // size aliquots so 1 aliquot per 10mL syringe
            double totalMols = massG / mw;
            TotalStockVolume_L = totalMols / stockM;
            double dilutionsToSyringe = stockM / (SyringeDilutionFactor * bathM);
            AliquotVolume_L = SyringeVolume_L / dilutionsToSyringe;
        }

        public AliquotPlan(Drug drug, string solvent, StockConcentration stock, BathConcentration bath)
        {
            TotalStockVolume_L = drug.Moles / stock.M;

            Concentration syringe = bath * SyringeDilutionFactor;
            double dilutionsToSyringe = stock.M / syringe.M;

            AliquotVolume_L = SyringeVolume_L / dilutionsToSyringe;
        }
    }
}
