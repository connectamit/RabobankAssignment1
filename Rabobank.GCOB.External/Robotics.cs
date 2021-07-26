using System;
using System.Threading.Tasks;

namespace Rabobank.GCOB.External
{
    public static class Robotics
    {
        public static Task<string> ScreeningAsync(string name, string countryOfRegistration)
        {
            //Note: actual implementation hidden for brevity
            if (name.Contains("Arms")) return Task.FromResult("Failed");
            if (countryOfRegistration != "Netherlands") return Task.FromResult("Inconclusive");
            return Task.FromResult("Success");
        }
    }
}
