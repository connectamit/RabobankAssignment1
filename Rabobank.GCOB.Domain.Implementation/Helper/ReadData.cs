using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabobank.GCOB.Domain.Implementation.Helper
{
    internal class ReadData
    {
        protected internal List<string[]> GetData()
        {
            var a = System.IO.File.ReadAllLines(@"Data\Data.csv", Encoding.Default);
            var b = a.Select(r => r.Split(',')).ToList();
            return b;
        }
    }
}
