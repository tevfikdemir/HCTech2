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
    public interface IGorevlerService
    {
        Task<IDataResult<GorevlerUpdateDto>> GetGorevlerUpdateDtoAsync(int gorevlerId);
        Task<IDataResult<GorevlerListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<GorevlerDto>> AddAsync(GorevlerAddDto gorevlerAddDto, string createdByName);
        Task<IDataResult<GorevlerDto>> UpdateAsync(GorevlerUpdateDto gorevlerUpdateDto, string modifiedByName);
        Task<IDataResult<GorevlerDto>> DeleteAsync(int gorevlerId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int gorevlerId);
        Task<IDataResult<int>> CountAsync();
    }
}
