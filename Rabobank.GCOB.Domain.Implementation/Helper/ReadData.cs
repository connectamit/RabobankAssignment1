namespace Rabobank.GCOB.Domain.Implementation.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class ReadData
    {
        /// <summary>
        /// This method is used for reading the records from csv file.
        /// </summary>
        /// <returns>A <see cref="List{T}"/>returns client data.</returns>
        protected internal List<string[]> GetData()
        {
            try
            {
                var data = System.IO.File.ReadAllLines(@"Data\Data.csv", Encoding.Default);
                var records = data.Select(r => r.Split(',')).ToList();
                return records;
            }
            catch (Exception ex)
            {
                throw new Exception(AppConstants.CustomExceptionMessageReadingData, ex); 
            }
        }
    }
}
