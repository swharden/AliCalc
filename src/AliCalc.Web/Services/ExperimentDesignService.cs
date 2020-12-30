using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliCalc.Web.Services
{
    public class ExperimentDesignService
    {
        public string DrugName { get; set; }
        public bool DrugNameIsValid => !string.IsNullOrWhiteSpace(DrugName);

        public string MolecularWeight { get; set; }
        public bool MolecularWeightIsValid => IsPositiveNumber(MolecularWeight);

        public string Mass { get; set; }
        public bool MassIsValid => IsPositiveNumber(Mass);

        public readonly string[] Solvents = { "water", "DMSO" };
        public string Solvent { get; set; }
        public bool SolventIsValid => Solvents.Contains(Solvent);

        public string StockConcentration { get; set; }
        public bool StockConcentrationIsValid => IsPositiveNumber(StockConcentration);

        public string BathConcentration { get; set; }
        public bool BathConcentrationIsValid => IsPositiveNumber(BathConcentration);

        public bool AllValid =>
            DrugNameIsValid && SolventIsValid && MolecularWeightIsValid &&
            MassIsValid && StockConcentrationIsValid && BathConcentrationIsValid;

        private bool IsPositiveNumber(string text)
        {
            bool canParse = double.TryParse(text, out double result);
            bool isPositive = result > 0;
            return canParse && isPositive;
        }

        public ExperimentDesignService()
        {
            LoadDefaults();
        }

        public void LoadDefaults()
        {
            DrugName = "picrotoxin";
            Solvent = "DMSO";
            MolecularWeight = "602.59";
            Mass = "1000";
            StockConcentration = "100";
            BathConcentration = "100";
        }
    }
}
