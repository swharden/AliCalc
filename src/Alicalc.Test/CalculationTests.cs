using AliCalc.Model;
using NUnit.Framework;

namespace Alicalc.Test
{
    public class CalculationTests
    {
        // These values were determined using AliCalc (ReactJS):
        // https://github.com/swharden/AliCalc/blob/master/src/tests/AliquotPlan.test.js
        // https://swharden.com/software/alicalc/
        [TestCase("picrotoxin", 1e-3, 602.59, 100 * 1e-3, 100 * 1e-6, 33.19, 500 * 1e-6, 16.595 * 1e-3)]
        [TestCase("oxytocin", 1e-3, 1007.19, 1 * 1e-3, .2 * 1e-6, 9.93, 100 * 1e-6, 0.993 * 1e-3)]
        public void Test_Calculations_AgainstKnownValues(string solute, double massG, double mw, double stockM, double bathM,
            double aliquotCount, double aliquotVolume, double stockVolume)
        {
            var plan = new AliquotPlan(solute, massG, mw, "water", stockM, bathM);
            Assert.AreEqual(aliquotCount, plan.AliquotCount, .01);
            Assert.AreEqual(aliquotVolume, plan.AliquotVolume_L, .01);
            Assert.AreEqual(stockVolume, plan.TotalStockVolume_L, .01);
        }
    }
}