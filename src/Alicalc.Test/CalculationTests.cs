using AliCalc.Model;
using NUnit.Framework;

namespace Alicalc.Test
{
    public class CalculationTests
    {
        [Test]
        public void Test_KnownCalculation_PTX()
        {
            var drug = new Drug("picrotoxin", Mass.FromGrams(1), 602.59);
            var stock = new StockConcentration(Concentration.MilliMol(100));
            var bath = new BathConcentration(Concentration.MicroMol(100));
            var plan = new AliquotPlan(drug, "water", stock, bath);

            Assert.AreEqual(33.19, plan.AliquotCount, .01);
            Assert.AreEqual(500 * 1e-6, plan.AliquotVolume_L, .01);
            Assert.AreEqual(16.595 * 1e-3, plan.TotalStockVolume_L, .01);
        }

        [Test]
        public void Test_KnownCalculation_OT()
        {
            var drug = new Drug("oxytocin", Mass.FromMilligrams(1), 1007.19);
            var stock = new StockConcentration(Concentration.MilliMol(1));
            var bath = new BathConcentration(Concentration.NanoMol(200));
            var plan = new AliquotPlan(drug, "DMSO", stock, bath);

            Assert.AreEqual(9.93, plan.AliquotCount, .01);
            Assert.AreEqual(100 * 1e-6, plan.AliquotVolume_L, .01);
            Assert.AreEqual(0.993 * 1e-3, plan.TotalStockVolume_L, .01);
        }
    }
}