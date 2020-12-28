namespace AliCalc.Model
{
    public class Drug
    {
        public readonly string Name;
        public readonly double GramsPerMole;
        public readonly Mass Mass;
        public double Moles => Mass.g / GramsPerMole;
        public string Solvent;

        public Drug(string name, Mass mass, double gramsPerMol, string solvent) =>
            (Name, Mass, GramsPerMole, Solvent) = (name, mass, gramsPerMol, solvent);
    }
}
