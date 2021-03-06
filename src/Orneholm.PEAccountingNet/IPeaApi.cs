using System.Collections.Generic;
using System.Threading.Tasks;
using Orneholm.PEAccountingNet.Models;
using Orneholm.PEAccountingNet.Filters;

namespace Orneholm.PEAccountingNet
{
    public interface IPeaApi
    {
        // Company

        Task<CompanyInformation> GetCompanyInfoAsync();

        //User

        Task<User> GetMyUserAsync();
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserAsync(int userId);

        // Clients

        Task<IEnumerable<Client>> GetClientsAsync();

        // Projects

        Task<IEnumerable<Project>> GetProjectsAsync();

        // Client projects

        Task<IEnumerable<ClientProject>> GetClientProjectsAsync();
        Task<IEnumerable<ClientProject>> GetClientProjectsAsync(ClientProjectFilter filter);
        Task<ClientProject> GetClientProjectAsync(int clientProjectId);

        // Expenses

        /// <summary>
        /// Fetch all the expenses that belongs to the user, which the token is tied to
        /// </summary>
        Task<IEnumerable<Expense>> GetExpensesAsync();

        /// <summary>
        /// Search all the expenses that belongs to the user, which the token is tied to
        /// </summary>
        Task<IEnumerable<Expense>> GetExpensesAsync(ExpenseFilter filter);

        // Activities

        Task<IEnumerable<Activity>> GetActivitiesAsync();
        Task<Activity> GetActivityAsync(int activityId);

        // Events

        Task<IEnumerable<Event>> GetEventsAsync();
        Task<IEnumerable<Event>> GetEventsAsync(EventFilter filter);
        Task<Event> GetEventAsync(int eventId);
        Task CreateEventAsync(EventCreate item);
        Task<Deleted> DeleteEventAsync(int eventId);

        // Client invoices

        Task<IEnumerable<ClientInvoice>> GetClientInvoicesAsync();
        Task<IEnumerable<ClientInvoice>> GetClientInvoicesAsync(ClientInvoiceFilter filter);
        Task<ItemCreated> CreateClientInvoiceAsync(ClientInvoiceCreate item);
        Task<ItemCreated> CreateClientInvoiceAsync(ClientInvoiceCreate item, ClientInvoiceCreateOptions options);

        // Client invoice templates

        /// <summary>
        /// Contains both debit and credit templates
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ClientInvoiceTemplate>> GetClientInvoiceTempatesAsync();

        // Client delivery types

        /// <summary>
        /// Supported delivery types
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ClientDeliveryType>> GetClientDeliveryTypesAsync();

        // Dimensions

        /// <summary>
        /// Dimensions (categories)
        /// </summary>
        Task<IEnumerable<Dimension>> GetDimensionsAsync();

        /// <summary>
        /// Entries for dimensions (categories)
        /// </summary>
        Task<IEnumerable<DimensionEntry>> GetDimensionEntriesAsync(int dimensionId);

        // Products

        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(int productId);
    }
}