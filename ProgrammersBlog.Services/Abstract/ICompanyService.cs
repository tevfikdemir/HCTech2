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
    public interface ICompanyService
    {
        Task<IDataResult<CompanyUpdateDto>> GetFirmalarUpdateDtoAsync(int firmaId);
        Task<IDataResult<CompanyListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<CompanyDto>> AddAsync(CompanyAddDto firmalarAddDto,string createdByName);
        Task<IDataResult<CompanyDto>> UpdateAsync(CompanyUpdateDto firmalarUpdateDto, string modifiedByName);
        Task<IDataResult<CompanyDto>> DeleteAsync(int firmaId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int firmaId);
        Task<IDataResult<int>> CountAsync();
    }
}
