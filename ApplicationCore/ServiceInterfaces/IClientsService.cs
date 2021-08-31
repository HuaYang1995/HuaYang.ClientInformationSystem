using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IClientsService
    {
        Task<List<ClientsResponseModel>> GetClients();
        Task<List<InteractionsResponseModel>> GetInteractionByClientId(int id);

        Task<Clients> PostClient(ClientsRequestModel model);

        Task<Clients> PutClient(PutClientsRequestModel model);

        Task DeleteClient(DeleteClientsRequestModel model);

    }
}
