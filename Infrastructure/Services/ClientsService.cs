using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ClientsService : IClientsService
    {
        private readonly IClientsRepository _clientsRepository;
        private readonly IInteractionRepository _interactionRepository;

        public ClientsService(IClientsRepository clientsRepository , IInteractionRepository interactionRepository)
        {
            _clientsRepository = clientsRepository;
            _interactionRepository = interactionRepository;
        }

        public async Task<List<ClientsResponseModel>> GetClients()
        {
            var getclients = await _clientsRepository.GetAllClients();

            var clientsInfo = new List<ClientsResponseModel>();

            foreach (var client in getclients)
            {
                clientsInfo.Add(new ClientsResponseModel
                {
                  Id = client.Id,
                  Name = client.Name,
                  Email = client.Email,
                  phones = client.Phones

                });
            }
            return clientsInfo;
        }

        public async Task<List<InteractionsResponseModel>> GetInteractionByClientId(int id)
        {
            var interactions = await _interactionRepository.GetInterationsByClientId(id);

            var interactionclient = new List<InteractionsResponseModel>();

            foreach (var interaction in interactions)
            {
                interactionclient.Add(new InteractionsResponseModel
                {
                    Id =interaction.Id,
                    IntType = interaction.IntType,
                    IntDate = interaction.IntDate,
                    Remarks = interaction.Remarks,
                    EmployeeName = interaction.Employees.Name

                }) ;

            }
            return interactionclient;
        }

        public async Task<Clients> PostClient (ClientsRequestModel model)
        {
            var client = new Clients { 
            Name  = model.Name,
            Email = model.Email,
            Phones = model.Phones,
            Address = model.Address,
          
            };
            var clients = await _clientsRepository.AddAsync(client);
            return clients;

        }

        public async Task<Clients> PutClient(PutClientsRequestModel model)
        {
            var client = new Clients
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Phones = model.Phones,
                Address = model.Address,


            };
            var clients = await _clientsRepository.UpdateAsync(client);
            return clients;

        }

        public async Task DeleteClient(DeleteClientsRequestModel model)
        {
            var client = new Clients
            {
                Id=model.Id

            };

            await _clientsRepository.DeleteAsync(client);
        }

    }
}
