using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using ProgrammersBlog.Entities.ComplexTypes;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;

namespace ProgrammersBlog.Services.Abstract
{
    public interface IPersonService
    {
        Task<IDataResult<PersonUpdateDto>> GetPersonelUpdateDtoAsync(int personelId);
        Task<IDataResult<PersonListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<PersonDto>> AddAsync(PersonAddDto personelAddDto, string createdByName);
        Task<IDataResult<PersonDto>> UpdateAsync(PersonUpdateDto personelUpdateDto, string modifiedByName);
        Task<IDataResult<PersonDto>> DeleteAsync(int personelId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int personelId);
        Task<IDataResult<int>> CountAsync();
    }
}
