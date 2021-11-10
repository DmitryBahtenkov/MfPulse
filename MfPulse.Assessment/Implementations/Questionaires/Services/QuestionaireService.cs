using System;
using System.Linq;
using System.Threading.Tasks;
using MfPulse.Assessment.Contract.Questionaires.Models;
using MfPulse.Assessment.Contract.Questionaires.Models.Requests;
using MfPulse.Assessment.Contract.Questionaires.Models.Responses;
using MfPulse.Assessment.Contract.Questionaires.Operations;
using MfPulse.Assessment.Contract.Questionaires.Services;
using MfPulse.Auth.Contract.Groups.Models;
using MfPulse.Auth.Contract.Groups.Operations;
using MfPulse.Auth.Contract.Users.Services;
using MfPulse.CrossCutting.Exceptions;
using MfPulse.EventBus;
using MfPulse.EventBus.Events;
using MfPulse.Mongo.Helpers;

namespace MfPulse.Assessment.Implementations.Questionaires.Services
{
    public class QuestionaireService : IQuestionaireService
    {
        private readonly IQuestionaireGetOperations _questionaireGetOperations;
        private readonly IQuestionaireWriteOperations _questionaireWriteOperations;
        private readonly IGroupGetOperations _groupGetOperations;
        private readonly IUserIdentity _userIdentity;
        private readonly EventInvoker<QuestionaireDocument> _eventInvoker;
        private readonly IServiceProvider _serviceProvider; 

        public QuestionaireService(IQuestionaireGetOperations questionaireGetOperations,
            IQuestionaireWriteOperations questionaireWriteOperations,
            IGroupGetOperations groupGetOperations,
            IUserIdentity userIdentity, 
            EventInvoker<QuestionaireDocument> eventInvoker,
            IServiceProvider serviceProvider)
        {
            _questionaireGetOperations = questionaireGetOperations;
            _questionaireWriteOperations = questionaireWriteOperations;
            _groupGetOperations = groupGetOperations;
            _userIdentity = userIdentity;
            _eventInvoker = eventInvoker;
            _serviceProvider = serviceProvider;
        }

        public async Task<QuestionaireResponse> Create(CreateQuestionaireRequest request)
        {
            var newDocument = new QuestionaireDocument
            {
                Id = IdGen.New,
                Name = request.Name,
                CompanyId = _userIdentity.CompanyId,
                GroupId = request.GroupId
            };

            newDocument = await _questionaireWriteOperations.Insert(newDocument);

            return Map(newDocument);
        }

        public async Task<QuestionaireResponse> Update(string id, UpdateQuestionaireRequest request)
        {
            var document = await _questionaireWriteOperations.UpdateInfo(id, request.Name, request.GroupId);
            
            return Map(document);
        }

        public async Task<AllQuestionairesResponse> All()
        {
            var docs = await _questionaireGetOperations.All();

            return new()
            {
                Questionaires = docs.Select(Map).ToList()
            };
        }

        public async Task Delete(string id)
        {
            var document = await _questionaireGetOperations.ById(id);
            if (document is not null)
            {
                await _eventInvoker.OnDocumentDeleted(
                    new DocumentDeletedEvent<QuestionaireDocument>(_serviceProvider, document));
                
                await _questionaireWriteOperations.Delete(document);
            }
        }

        public async Task<QuestionaireResponse> Get(string id)
        {
            var document = await _questionaireGetOperations.ById(id);
            if (document is null)
            {
                throw new NotFoundException();
            }

            return Map(document);
        }

        public async Task<AllQuestionairesResponse> ByGroup(string groupId)
        {
            var docs = await _questionaireGetOperations.All();

            return new()
            {
                Questionaires = docs.Select(Map).ToList()
            };
        }

        private QuestionaireResponse Map(QuestionaireDocument document)
        {
            return new()
            {
                Id = document.Id,
                GroupId = document.GroupId,
                Name = document.Name
            };
        }
    }
}