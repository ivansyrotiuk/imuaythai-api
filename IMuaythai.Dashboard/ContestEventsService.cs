using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IMuaythai.Models.Dashboard;
using IMuaythai.Repositories.Contests;

namespace IMuaythai.Dashboard
{
    public class ContestEventsService : IContestEventsService
    {
        private readonly IContestRepository _contestRepository;
        private readonly IMapper _mapper;

        public ContestEventsService(IContestRepository contestRepository, IMapper mappper)
        {
            _contestRepository = contestRepository;
            _mapper = mappper;
        }

        public async Task<IEnumerable<ContestEvent>> GetContestEvents()
        {
            var contests = await _contestRepository.GetAll();
            var contestEvents = _mapper.Map<List<ContestEvent>>(contests);
            return contestEvents;
        }
    }
}
