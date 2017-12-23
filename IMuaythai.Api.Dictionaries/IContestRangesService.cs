﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Dictionaries;
using IMuaythai.Repositories.Dictionaries;

namespace IMuaythai.Dictionaries
{
    public interface IContestRangesService
    {
        Task<IEnumerable<ContestRangeModel>> GetContestRanges();
        Task<ContestRangeModel> GetContestRange(int id);
        Task<ContestRangeModel> SaveContestRange(ContestRangeModel contestRangeModel);
        Task RemoveContestRange(int id);
    }

    public class ContestRangesService : IContestRangesService
    {
        private readonly IContestRangesRepository _repository;
        private readonly IMapper _mapper;

        public ContestRangesService(IContestRangesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContestRangeModel>> GetContestRanges()
        {
            var contestRanges = await _repository.GetAll();
            return _mapper.Map<IEnumerable<ContestRangeModel>>(contestRanges);
        }

        public async Task<ContestRangeModel> GetContestRange(int id)
        {
            var contestRange = await _repository.Get(id);
            return _mapper.Map<ContestRangeModel>(contestRange);
        }

        public async Task<ContestRangeModel> SaveContestRange(ContestRangeModel contestRangeModel)
        {
            var range = _mapper.Map<ContestRange>(contestRangeModel);
            await _repository.Save(range);
            return _mapper.Map<ContestRangeModel>(range);
        }

        public async Task RemoveContestRange(int id)
        {
            await _repository.Remove(id);
        }
    }

    public interface IRoundsSevice
    {
        Task<IEnumerable<RoundModel>> GetRounds();
        Task<RoundModel> GetRound(int id);
        Task<RoundModel> SaveRound(RoundModel roundModel);
        Task RemoveRound(int id);
    }

    public class RoundsService : IRoundsSevice
    {
        private readonly IRoundsRepository _repository;
        private readonly IMapper _mapper;


        public RoundsService(IRoundsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoundModel>> GetRounds()
        {
            var rounds = await _repository.GetAll();
            return _mapper.Map<IEnumerable<RoundModel>>(rounds);
        }

        public async Task<RoundModel> GetRound(int id)
        {
            var round = await _repository.Get(id);
            return _mapper.Map<RoundModel>(round);
        }

        public async Task<RoundModel> SaveRound(RoundModel roundModel)
        {
            var round = _mapper.Map<Round>(roundModel);
            await _repository.Save(round);
            return _mapper.Map<RoundModel>(round);
        }

        public async Task RemoveRound(int id)
        {
            await _repository.Remove(id);
        }
    }
}