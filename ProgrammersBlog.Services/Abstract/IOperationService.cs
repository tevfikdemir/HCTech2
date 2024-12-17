using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;

namespace ProgrammersBlog.Services.Abstract
{
    public interface IOperationService
    {
        Task<IDataResult<OperationUpdateDto>> GetOperationUpdateDtoAsync(int operasyonId);
        Task<IDataResult<OperationListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<OperationDto>> AddAsync(OperationAddDto operasyonAddDto, string createdByName);
        Task<IDataResult<OperationDto>> UpdateAsync(OperationUpdateDto operasyonUpdateDto, string modifiedByName);
        Task<IDataResult<OperationDto>> DeleteAsync(int operasyonId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int operasyonId);
        Task<IDataResult<int>> CountAsync();
    }
}
