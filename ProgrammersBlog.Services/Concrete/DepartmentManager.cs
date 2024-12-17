using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Services.Utilities;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;

namespace ProgrammersBlog.Services.Concrete
{
    public class DepartmentManager:ManagerBase,IDepartmentService
    {
        public DepartmentManager(IUnitOfWork unitOfWork, IMapper mapper):base(unitOfWork,mapper)
        {
        }

        public async Task<IDataResult<DepartmentUpdateDto>> GetDepartmanUpdateDtoAsync(int departmentId)
        {
            var result = await UnitOfWork.Department.AnyAsync(c => c.Id == departmentId);
            if (result)
            {
                var department = await UnitOfWork.Department.GetAsync(c => c.Id == departmentId);
                var departmentUpdateDto = Mapper.Map<DepartmentUpdateDto>(department);
                return new DataResult<DepartmentUpdateDto>(ResultStatus.Success,departmentUpdateDto);
            }
            else
            {
                return new DataResult<DepartmentUpdateDto>(ResultStatus.Error,Messages.Departman.NotFound(isPlural:false),null);
            }
        }
        public async Task<IDataResult<DepartmentListDto>> GetAllByNonDeletedAsync()
        {
            var department = await UnitOfWork.Department.GetAllAsync(c => !c.IsDeleted);
            if (department.Count > -1)
            {
                return new DataResult<DepartmentListDto>(ResultStatus.Success, new DepartmentListDto
                {
                    Departments = department,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<DepartmentListDto>(ResultStatus.Error, Messages.Departman.NotFound(isPlural: true), new DepartmentListDto
            {
                Departments = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Departman.NotFound(isPlural: true)
            });
        }
        public async Task<IDataResult<DepartmentListDto>> GetAllByDeletedAsync()
        {
            var department = await UnitOfWork.Department.GetAllAsync(c => c.IsDeleted);
            if (department.Count > -1)
            {
                return new DataResult<DepartmentListDto>(ResultStatus.Success, new DepartmentListDto
                {
                    Departments = department,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<DepartmentListDto>(ResultStatus.Error, Messages.Departman.NotFound(isPlural: true), null);
        }
        public async Task<IDataResult<DepartmentDto>> AddAsync(DepartmentAddDto departmanAddDto, string createdByName)
        {
            var department = Mapper.Map<Department>(departmanAddDto);
            var addedDepartment = await UnitOfWork.Department.AddAsync(department);
            await UnitOfWork.SaveAsync();
            return new DataResult<DepartmentDto>(ResultStatus.Success,Messages.Departman.Add(addedDepartment.Name),new DepartmentDto
            {
                Department = addedDepartment,
                ResultStatus = ResultStatus.Success,
                Message = Messages.Departman.Add(addedDepartment.Name)
            });
        }
        public async Task<IDataResult<DepartmentDto>> UpdateAsync(DepartmentUpdateDto departmentUpdateDto, string modifiedByName)
        {
            var oldDepartment= await UnitOfWork.Department.GetAsync(c => c.Id == departmentUpdateDto.Id);
            var department = Mapper.Map<DepartmentUpdateDto,Department>(departmentUpdateDto, oldDepartment);
           var updatedDepartment= await UnitOfWork.Department.UpdateAsync(department);
            await UnitOfWork.SaveAsync();
            return new DataResult<DepartmentDto>(ResultStatus.Success, Messages.Departman.Update(updatedDepartment.Name),new DepartmentDto
            {
                Department = updatedDepartment,
                ResultStatus = ResultStatus.Success,
                Message = Messages.Departman.Update(updatedDepartment.Name)
            });
        }
        public async Task<IDataResult<DepartmentDto>> DeleteAsync(int departmentId, string modifiedByName)
        {
            var department = await UnitOfWork.Department.GetAsync(c => c.Id == departmentId);
            if (department != null)
            {
                department.IsDeleted = true;
                department.IsActive = false;
                var deletedDepartment= await UnitOfWork.Department.UpdateAsync(department);
                await UnitOfWork.SaveAsync();
                return new DataResult<DepartmentDto>(ResultStatus.Success, Messages.Departman.Delete(deletedDepartment.Name), new DepartmentDto
                {
                    Department = deletedDepartment,
                    ResultStatus = ResultStatus.Success,
                    Message = Messages.Departman.Delete(deletedDepartment.Name)
                });
            }
            return new DataResult<DepartmentDto>(ResultStatus.Error, Messages.Departman.NotFound(isPlural: false), new DepartmentDto
            {
                Department = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Departman.NotFound(isPlural: false)
            });
        }
        public async Task<IResult> HardDeleteAsync(int departmentId)
        {
            var department = await UnitOfWork.Department.GetAsync(c => c.Id == departmentId);
            if (department != null)
            {
                await UnitOfWork.Department.DeleteAsync(department);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Departman.HardDelete(department.Name));
            }
            return new Result(ResultStatus.Error, Messages.Departman.NotFound(isPlural: false));
        }
        public async Task<IDataResult<int>> CountAsync()
        {
            var departmentsCount = await UnitOfWork.Department.CountAsync();
            if (departmentsCount > -1)
            {
               return new DataResult<int>(ResultStatus.Success, departmentsCount); 
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error,$"Beklenmeyen bir hata ile karşılaşıldı.",-1);
            }
        }

    }
}
