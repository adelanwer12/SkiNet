using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductTypesRepository
    {
        Task<IEnumerable<ProductType>> GetProductTypesAsync();
    }
}