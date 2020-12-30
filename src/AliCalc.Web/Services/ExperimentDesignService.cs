using AliCalc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliCalc.Web.Services
{
    public class ExperimentDesignService
    {
        public event Action OnStateChange;

        private string _drugName;
        public bool DrugNameIsValid { get; private set; }
        public string DrugName
        {
            get => _drugName;
            set
            {
                _drugName = value;
                DrugNameIsValid = !string.IsNullOrWhiteSpace(value);
                OnStateChange?.Invoke();
            }
        }

        private string _molecularWeight;
        public bool MolecularWeightIsValid { get; private set; }
        public string MolecularWeight
        {
            get => _molecularWeight;
            set
            {
                _molecularWeight = value;
                MolecularWeightIsValid = IsPositiveNumber(value);
                OnStateChange?.Invoke();
            }
        }

        private string _drugMmass;
        public bool DrugMassIsValid { get; private set; }
        public string DrugMass
        {
            get => _drugMmass;
            set
            {
                _drugMmass = value;
                DrugMassIsValid = IsPositiveNumber(value);
                OnStateChange?.Invoke();
            }
        }

        public readonly string[] Solvents = { "water", "DMSO" };
        private string _solvent;
        public bool SolventIsValid { get; private set; }
        public string Solvent
        {
            get => _solvent;
            set
            {
                _solvent = value;
                SolventIsValid = Solvents.Contains(value);
                OnStateChange?.Invoke();
            }
        }

        private string _stockConcentratration;
        public bool StockConcentrationIsValid { get; private set; }
        public string StockConcentration
        {
            get => _stockConcentratration;
            set
            {
                _stockConcentratration = value;
                StockConcentrationIsValid = IsPositiveNumber(value);
                OnStateChange?.Invoke();
            }
        }

        private string _bathConcentration;
        public bool BathConcentrationIsValid { get; private set; }
        public string BathConcentration
        {
            get => _bathConcentration;
            set
            {
                _bathConcentration = value;
                BathConcentrationIsValid = IsPositiveNumber(value);
                OnStateChange?.Invoke();
            }
        }

        public bool AllValid =>
            DrugNameIsValid && SolventIsValid && MolecularWeightIsValid &&
            DrugMassIsValid && StockConcentrationIsValid && BathConcentrationIsValid;

        private bool IsPositiveNumber(string text)
        {
            bool canParse = double.TryParse(text, out double result);
            bool isPositive = result > 0;
            return canParse && isPositive;
        }

        public string InstructionsStock { get; private set; }
        public string InstructionsAliquot { get; private set; }
        public string InstructionsSyringe { get; private set; }
        public string InstructionsBath { get; private set; }
        private void RecalculateStrings()
        {
            if (AllValid)
            {
                var drug = new Drug(DrugName, Mass.FromGrams(double.Parse(DrugMass)), double.Parse(MolecularWeight), "DMSO");
                var stock = new StockConcentration(Concentration.MilliMol(double.Parse(StockConcentration)));
                var bath = new BathConcentration(Concentration.MicroMol(double.Parse(BathConcentration)));
                var plan = new AliquotPlan(drug, stock, bath);

                InstructionsStock = plan.InstructionToMakeStock;
                InstructionsAliquot = plan.InstructionToAliquotStock;
                InstructionsSyringe = plan.InstructionSyringe;
                InstructionsBath = plan.InstructionBath;
            }
            else
            {
                InstructionsStock = "invalid input";
                InstructionsAliquot = "invalid input";
                InstructionsSyringe = "invalid input";
                InstructionsBath = "invalid input";
            }
        }

        public ExperimentDesignService()
        {
            LoadDefaults();
            OnStateChange += RecalculateStrings;
        }

        public void LoadDefaults()
        {
            DrugName = "picrotoxin";
            Solvent = "DMSO";
            MolecularWeight = "602.59";
            DrugMass = "1000";
            StockConcentration = "100";
            BathConcentration = "100";
        }
    }
}
