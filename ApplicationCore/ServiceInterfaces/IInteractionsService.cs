using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IInteractionsService
    {

        Task<List<InteractionsResponseModel>> GetInteractions();

        Task<Interactions> PostInteraction(InteractionsRequestModel model);

        Task<Interactions> PutInteraction(PutInteractionsRequestModel model);

        Task DeleteInteraction(DeleteInteractionsRequestModel model);


    }
}
