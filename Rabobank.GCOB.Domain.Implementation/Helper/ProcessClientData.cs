using Rabobank.GCOB.Domain.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabobank.GCOB.Domain.Implementation.Helper
{
    #region ProcessClientData is one of the helper class and can be used in many classes as base class
    public class ProcessClientData
    {
        /// <summary>
        /// OperateClientData is the method for generating client object
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public Task<Interfaces.Models.Client> OperateClientData(string[] file)
        {
            Client client = new Client();
            Address address = new Address();

            if (!string.IsNullOrEmpty(file[1]))
            {
                client.FullName = file[1];

                if (client.FullName.LastIndexOf(" ") >= 0)
                {
                    client.FirstName = client.FullName.Substring(0, client.FullName.LastIndexOf(" "));
                    client.LastName = client.FullName.Substring(client.FullName.LastIndexOf(" ")).Trim();
                }
                else
                {
                    client.FirstName = client.FullName;
                }
            }

            address.Line1 = file[2];
            address.Line2 = file[3];
            address.Line3 = file[4];
            address.City = file[5];
            address.PostCode = file[6];
            address.Country = file[7];
            client.Address = address;

            decimal turnOver = 0;

            if (decimal.TryParse(file[8], out turnOver))
            {
                client.Turnover = turnOver;
            }

            if (string.Compare(file[0], "LegalEntity", true) == 0)
            {
                EntityType entityType;
                if (Enum.TryParse<EntityType>(file[9], out entityType))
                {
                    client.EntityType = entityType;
                }
            }
            else
            {
                client.EntityType = EntityType.Unknown;
            }

            return Task.FromResult(client);
        }
    }
    #endregion
}
