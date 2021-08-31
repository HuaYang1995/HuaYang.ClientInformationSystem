using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IInteractionRepository: IAsyncRepository<Interactions>
    {
        Task<IEnumerable<Interactions>> GetInterationsByClientId(int clientid);
        Task<IEnumerable<Interactions>> GetInterationsByEmployeeId(int employeeid);

        Task<IEnumerable<Interactions>> GetAllInteractions();
    }
}
