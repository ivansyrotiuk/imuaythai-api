using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Dictionaries;
using IMuaythai.Repositories.Dictionaries;

namespace IMuaythai.Dictionaries
{
    public interface IWeightAgeCategoriesService
    {
        Task<IEnumerable<WeightAgeCategoryModel>> GetWeightAgeCategories();
        Task<WeightAgeCategoryModel> GetWeightAgeCategory(int id);
        Task<WeightAgeCategoryModel> Save(WeightAgeCategoryModel categoryModel);
        Task Remove(int categoryId);
    }

    public class WeightAgeCategoriesService : IWeightAgeCategoriesService
    {
        private readonly IWeightAgeCategoriesRepository _repository;
        private readonly IMapper _mapper;

        public WeightAgeCategoriesService(IWeightAgeCategoriesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WeightAgeCategoryModel>> GetWeightAgeCategories()
        {
            var categories = await _repository.GetAll();
            return _mapper.Map<IEnumerable<WeightAgeCategoryModel>>(categories);
        }

        public async Task<WeightAgeCategoryModel> GetWeightAgeCategory(int id)
        {
            var category = await _repository.Get(id);
            return _mapper.Map<WeightAgeCategoryModel>(category);
        }

        public async Task<WeightAgeCategoryModel> Save(WeightAgeCategoryModel categoryModel)
        {
            var category = _mapper.Map<WeightAgeCategory>(categoryModel);
            await _repository.Save(category);
            categoryModel.Id = category.Id;
            return categoryModel;
        }

        public async Task Remove(int categoryId)
        {
            await _repository.Remove(categoryId);
        }
    }
}