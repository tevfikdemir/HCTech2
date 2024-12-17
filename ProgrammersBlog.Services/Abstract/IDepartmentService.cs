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
    public interface IDepartmentService
    {
        Task<IDataResult<DepartmentUpdateDto>> GetDepartmanUpdateDtoAsync(int departmentId);
        Task<IDataResult<DepartmentListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<DepartmentDto>> AddAsync(DepartmentAddDto departmentAddDto,string createdByName);
        Task<IDataResult<DepartmentDto>> UpdateAsync(DepartmentUpdateDto departmentUpdateDto, string modifiedByName);
        Task<IDataResult<DepartmentDto>> DeleteAsync(int departmentId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int departmentId);
        Task<IDataResult<int>> CountAsync();
    }
}
