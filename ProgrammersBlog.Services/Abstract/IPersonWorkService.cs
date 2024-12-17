using ProgrammersBlog.Entities.ComplexTypes;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Abstract
{
    public interface  IPersonWorkService
    {
        Task<IDataResult<PersonWorkDto>> GetAsync(int orderId,int operationId);

        Task<IDataResult<PersonWorkListDto>> GetAllAsync();
        Task<IDataResult<PersonWorkDto>> AddAsync(PersonWorkAddDto orderoperationsizeAddDto);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<PersonWorkDto>> GetByIdAsync(int pwId);
        Task<IDataResult<List<PersonPerformansDTO>>> GetAllPersonWorkDtosAsync();
    }
}
