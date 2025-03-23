using System.Collections.Generic;

namespace vstupna.Services
{
    public static class ReferenceDataService
    {
        public static List<string> LoadGuarantors(string filePath)
        {
            // Dummy implementation: in real usage, parse the CSV file
            return new List<string> { "Guarantor1", "Guarantor2", "Guarantor3" };
        }
    }
}
