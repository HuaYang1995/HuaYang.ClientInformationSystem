using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class InteractionsService :IInteractionsService
    {
        private readonly IInteractionRepository _interactionRepository;
        public InteractionsService(IInteractionRepository interactionRepository)
        {
            _interactionRepository = interactionRepository;
        }



        public async Task<List<InteractionsResponseModel>> GetInteractions()
        {
            var getinteractions = await _interactionRepository.GetAllInteractions();

            var interactionsInfo = new List<InteractionsResponseModel>();

            foreach (var interactions in getinteractions)
            {
                interactionsInfo.Add(new InteractionsResponseModel
                {
                    ClientId = interactions.ClientId,
                    EmpId = interactions.EmpId,
                    IntType = interactions.IntType,
                    IntDate = interactions.IntDate,
                    Remarks = interactions.Remarks

                });
            }
            return interactionsInfo;
        }

        public async Task<Interactions> PostInteraction(InteractionsRequestModel model)
        {
            var interaction = new Interactions
            {
                ClientId = model.ClientId,
                EmpId = model.EmpId,
                IntType = model.IntType,
                IntDate = model.IntDate,
                Remarks = model.Remarks

            };
            var interactions = await _interactionRepository.AddAsync(interaction);
            return interactions;

        }

        public async Task<Interactions> PutInteraction(PutInteractionsRequestModel model)
        {
            var interaction = new Interactions
            {
                Id = model.Id,
                ClientId = model.ClientId,
                EmpId = model.EmpId,
                IntType = model.IntType,
                IntDate = model.IntDate,
                Remarks = model.Remarks

            };
            var interactions = await _interactionRepository.UpdateAsync(interaction);
            return interactions;

        }

        public async Task DeleteInteraction(DeleteInteractionsRequestModel model)
        {
            var interaction = new Interactions
            {

                Id=model.Id
            };

            await _interactionRepository.DeleteAsync(interaction);
        }



    }
}
