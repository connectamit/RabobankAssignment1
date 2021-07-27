namespace Rabobank.GCOB.Domain.Implementation.Helper
{
    using System;
    using System.Threading.Tasks;
    using Rabobank.GCOB.Domain.Interfaces.Models;

    public class ClientDataReader
    {
        /// <summary>
        /// This method is used for processing generating client object from the file records.
        /// </summary>
        /// <param name="lineItem"> passes lineitem from. </param>
        /// <returns>A <see cref="Client"/>returns client.</returns>
        protected internal Client OperateClientData(string[] lineItem)
        {
            Client client = new Client();
            Address address = new Address();

            try
            {
                if (!string.IsNullOrEmpty(lineItem[1]))
                {
                    client.FullName = lineItem[1];

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

                address.Line1 = lineItem[2];
                address.Line2 = lineItem[3];
                address.Line3 = lineItem[4];
                address.City = lineItem[5];
                address.PostCode = lineItem[6];
                address.Country = lineItem[7];
                client.Address = address;

                decimal turnOver = 0;

                if (decimal.TryParse(lineItem[8], out turnOver))
                {
                    client.Turnover = turnOver;
                }

                if (string.Compare(lineItem[0], AppConstants.LegaEntity, true) == 0)
                {
                    EntityType entityType;
                    if (Enum.TryParse<EntityType>(lineItem[9], out entityType))
                    {
                        client.EntityType = entityType;
                    }
                }
                else
                {
                    client.EntityType = EntityType.Unknown;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(AppConstants.CustomExceptionMessageClientDataReader, ex);
            }

            return client;
        }
    }
}
