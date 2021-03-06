using System.Collections.Generic;
using System.Threading.Tasks;
using Orneholm.PEAccountingNet.Helpers;
using Orneholm.PEAccountingNet.Models;
using Orneholm.PEAccountingNet.Models.Native;

namespace Orneholm.PEAccountingNet
{
    public class PeaAuthenticationApi : IPeaAuthenticationApi
    {
        private readonly IPeaApiHttpClient _httpClient;

        public PeaAuthenticationApi() : this(new PeaApiHttpClient())
        {
        }

        public PeaAuthenticationApi(IPeaApiHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Authenticate

        public async Task<IEnumerable<AccessibleCompany>> GetAccessibleCompaniesAsync(string email, string password)
        {
            var result = await _httpClient.PostAsync<userauthentication, accessiblecompanies>("/access/authenticate", new userauthentication()
            {
                email = email,
                password = password
            });

            return TransformLists.TransformListResult(result, x => x.accessiblecompany, AccessibleCompany.FromNative);
        }
    }
}