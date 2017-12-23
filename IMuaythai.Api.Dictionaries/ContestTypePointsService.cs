using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Dictionaries;
using IMuaythai.Repositories.Dictionaries;

namespace IMuaythai.Dictionaries
{
    public class ContestTypePointsService : IContestTypePointsService
    {
        private readonly IContestTypePointsRepository _repository;
        private readonly IMapper _mapper;

        public ContestTypePointsService(IContestTypePointsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContestPointsModel>> GetAllContestTypePoints()
        {
            var contestTypePointsList = await _repository.GetAll();
            return _mapper.Map<IEnumerable<ContestPointsModel>>(contestTypePointsList);
        }

        public async Task<ContestPointsModel> GetContestTypePoints(int id)
        {
            var contestTypePoints = await _repository.Get(id);
            return _mapper.Map<ContestPointsModel>(contestTypePoints);
        }

        public async Task<ContestPointsModel> SaveContestTypePoints(ContestPointsModel contestPointsModel)
        {
            var contestTypePoints = _mapper.Map<ContestTypePoints>(contestPointsModel);
            await _repository.Save(contestTypePoints);
            return _mapper.Map<ContestPointsModel>(contestTypePoints);
        }

        public async Task RemoveContestTypePoints(int id)
        {
            await _repository.Remove(id);
        }
    }
}