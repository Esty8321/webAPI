using AutoMapper;
using DTOs;
using Entities;
using repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        IMapper _mapper;
        ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
              _categoryRepository= categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> GetAllCategories()
        {
             List < Category > categories=await _categoryRepository.GetAllCategories();
            List<CategoryDTO> categoriesToReturn = _mapper.Map<List<CategoryDTO>>(categories);
            return categoriesToReturn;
        }
    }
}
