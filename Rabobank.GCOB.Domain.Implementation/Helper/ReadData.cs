using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabobank.GCOB.Domain.Implementation.Helper
{
    #region ReadData is one of the helper class whose prime objective is to read data from csv
    internal class ReadData
    {
        /// <summary>
        /// This method is used to read data from CSV files
        /// </summary>
        /// <returns></returns>
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
    #endregion
}
