using System.Threading.Tasks;

namespace Rabobank.GCOB.External
{
    public static class Robotics
    {
        /// <summary>
        /// This method is used to screen the name and country for saving the information
        /// </summary>
        /// <param name="name"></param>
        /// <param name="countryOfRegistration"></param>
        /// <returns></returns>
        public static Task<string> ScreeningAsync(string name, string countryOfRegistration)
        {
            //Note: actual implementation hidden for brevity
            if (name.Contains("Arms")) return Task.FromResult("Failed");
            if (countryOfRegistration != "Netherlands") return Task.FromResult("Inconclusive");
            return Task.FromResult("Success");
        }
    }
}
