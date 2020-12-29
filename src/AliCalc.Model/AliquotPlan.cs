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

        public readonly string InstructionToMakeStock;
        public readonly string InstructionToAliquotStock;
        public readonly string InstructionSyringe;
        public readonly string InstructionBath;

        public AliquotPlan(Drug drug, StockConcentration stockConcentration, BathConcentration bathConcentration)
        {
            Syringe = new Syringe(Volume.MilliLiters(10), bathConcentration, 50);
            TotalStockVolume = Volume.Liters(drug.Moles / stockConcentration.MolesPerLiter);
            AliquotVolume = Syringe.Volume / (stockConcentration / Syringe.Concentration);

            InstructionToMakeStock = $"Dissolve {drug.Mass.mg} mg {drug.Name} into {TotalStockVolume.mL:0.###} mL {drug.Solvent} to make {stockConcentration.mM} mM stock.";
            InstructionToAliquotStock = $"Divide stock into {AliquotVolume.uL:0.###} µL aliquots (makes {AliquotCount:.##}) of {stockConcentration.mM} mM {drug.Name} in {drug.Solvent}.";
            InstructionSyringe = $"Use 1 aliquot to {Syringe.Volume.mL} mL ACSF in a {Syringe.DilutionFactor}x syringe for {bathConcentration.uM} µM bath.";
            InstructionBath = $"Add 1 aliquot to {Syringe.Volume.mL * Syringe.DilutionFactor} mL ACSF for {bathConcentration.uM} µM bath.";
        }
    }
}
