using AliCalc.Model;
using NUnit.Framework;

namespace Alicalc.Test
{
    public class CalculationTests
    {
        [Test]
        public void Test_KnownCalculation_PTX()
        {
            var drug = new Drug("picrotoxin", Mass.FromGrams(1), 602.59, "DMSO");
            var stock = new StockConcentration(Concentration.MilliMol(100));
            var bath = new BathConcentration(Concentration.MicroMol(100));
            var plan = new AliquotPlan(drug, stock, bath);

            Assert.AreEqual(16.595, plan.TotalStockVolume.mL, .01);
            Assert.AreEqual(500, plan.AliquotVolume.uL);
            Assert.AreEqual(33.19, plan.AliquotCount, .01);
        }

        [Test]
        public void Test_KnownCalculation_OT()
        {
            var drug = new Drug("oxytocin", Mass.FromMilligrams(1), 1007.19, "water");
            var stock = new StockConcentration(Concentration.MilliMol(1));
            var bath = new BathConcentration(Concentration.NanoMol(200));
            var plan = new AliquotPlan(drug, stock, bath);

            Assert.AreEqual(0.993, plan.TotalStockVolume.mL, .01);
            Assert.AreEqual(100, plan.AliquotVolume.uL, .01);
            Assert.AreEqual(9.93, plan.AliquotCount, .01);
        }
    }
}