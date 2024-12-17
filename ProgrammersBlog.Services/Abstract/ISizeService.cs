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
    public interface ISizeService
    {
        Task<IDataResult<SizeUpdateDto>> GetSizeUpdateDtoAsync(int bedenlerId);
        Task<IDataResult<SizeListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<SizeDto>> AddAsync(SizeAddDto sizeAddDto, string createdByName);
        Task<IDataResult<SizeDto>> UpdateAsync(SizeUpdateDto sizeUpdateDto, string modifiedByName);
        Task<IDataResult<SizeDto>> DeleteAsync(int sizeId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int sizeId);
        Task<IDataResult<int>> CountAsync();
    }
}
