using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Dictionaries;
using IMuaythai.Repositories.Dictionaries;

namespace IMuaythai.Dictionaries
{
    public interface IContestCategoriesService
    {
        Task<ContestCategoryModel> GetCategory(int id);
        Task<IEnumerable<ContestCategoryModel>> GetAllCategories();
        Task<ContestCategoryModel> SaveCategory(ContestCategoryModel categoryModel);
        Task RemoveCategory(int id);
    }

    public class ContestCategoriesService : IContestCategoriesService
    {
        private readonly IContestCategoriesRepository _repository;
        private readonly IMapper _mapper;

        public ContestCategoriesService(IContestCategoriesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ContestCategoryModel> GetCategory(int id)
        {
            var category = await _repository.Get(id);
            return _mapper.Map<ContestCategoryModel>(category);
        }

        public async Task<IEnumerable<ContestCategoryModel>> GetAllCategories()
        {
            var categories = await _repository.GetAll();
            return _mapper.Map<IEnumerable<ContestCategoryModel>>(categories);
        }

        public async Task<ContestCategoryModel> SaveCategory(ContestCategoryModel categoryModel)
        {
            var category = _mapper.Map<ContestCategory>(categoryModel);
            await _repository.Save(category);
            categoryModel.Id = category.Id;
            return categoryModel;
        }

        public async Task RemoveCategory(int id)
        {
            await _repository.Remove(id);
        }
    }
}                           