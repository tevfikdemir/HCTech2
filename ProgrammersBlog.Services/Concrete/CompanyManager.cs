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
    public class CompanyManager:ManagerBase, ICompanyService
    {
        public CompanyManager(IUnitOfWork unitOfWork, IMapper mapper):base(unitOfWork,mapper)
        {
        }

        public async Task<IDataResult<CompanyUpdateDto>> GetFirmalarUpdateDtoAsync(int firmaId)
        {
            var result = await UnitOfWork.Companies.AnyAsync(c => c.Id == firmaId);
            if (result)
            {
                var firmalar = await UnitOfWork.Companies.GetAsync(c => c.Id == firmaId);
                var firmalarUpdateDto = Mapper.Map<CompanyUpdateDto>(firmalar);
                return new DataResult<CompanyUpdateDto>(ResultStatus.Success,firmalarUpdateDto);
            }
            else
            {
                return new DataResult<CompanyUpdateDto>(ResultStatus.Error,Messages.Firmalar.NotFound(isPlural:false),null);
            }
        }

        public async Task<IDataResult<CompanyListDto>> GetAllByNonDeletedAsync()
        {
            var Firmalar = await UnitOfWork.Companies.GetAllAsync(c => !c.IsDeleted);
            if (Firmalar.Count > -1)
            {
                return new DataResult<CompanyListDto>(ResultStatus.Success, new CompanyListDto
                {
                    Companies = Firmalar,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CompanyListDto>(ResultStatus.Error, Messages.Firmalar.NotFound(isPlural: true), new CompanyListDto
            {
                Companies = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Firmalar.NotFound(isPlural: true)
            });
        }

        public async Task<IDataResult<CompanyDto>> AddAsync(CompanyAddDto firmalarAddDto, string createdByName)
        {
            var firmalar = Mapper.Map<Company>(firmalarAddDto);
            var addedFirmalar = await UnitOfWork.Companies.AddAsync(firmalar);
            await UnitOfWork.SaveAsync();
            return new DataResult<CompanyDto>(ResultStatus.Success,Messages.Firmalar.Add(addedFirmalar.Name),new CompanyDto
            {
                Company = addedFirmalar,
                ResultStatus = ResultStatus.Success,
                Message = Messages.Firmalar.Add(addedFirmalar.Name)
            });
        }

        public async Task<IDataResult<CompanyDto>> UpdateAsync(CompanyUpdateDto firmalarUpdateDto, string modifiedByName)
        {
            var oldFirmalar = await UnitOfWork.Companies.GetAsync(c => c.Id == firmalarUpdateDto.Id);
            var firmalar = Mapper.Map<CompanyUpdateDto, Company>(firmalarUpdateDto, oldFirmalar);
           var updatedFirmalar = await UnitOfWork.Companies.UpdateAsync(firmalar);
            await UnitOfWork.SaveAsync();
            return new DataResult<CompanyDto>(ResultStatus.Success, Messages.Firmalar.Update(updatedFirmalar.Name),new CompanyDto
            {
                Company = updatedFirmalar,
                ResultStatus = ResultStatus.Success,
                Message = Messages.Firmalar.Update(updatedFirmalar.Name)
            });
        }

        public async Task<IDataResult<CompanyDto>> DeleteAsync(int firmaId, string modifiedByName)
        {
            var firmalar = await UnitOfWork.Companies.GetAsync(c => c.Id == firmaId);
            if (firmalar!=null)
            {
                firmalar.IsDeleted = true;
                firmalar.IsActive = false;
                var deletedFirmalar = await UnitOfWork.Companies.UpdateAsync(firmalar);
                await UnitOfWork.SaveAsync();
                return new DataResult<CompanyDto>(ResultStatus.Success, Messages.Firmalar.Delete(deletedFirmalar.Name), new CompanyDto
                {
                    Company = deletedFirmalar,
                    ResultStatus = ResultStatus.Success,
                    Message = Messages.Firmalar.Delete(deletedFirmalar.Name)
                });
            }
            return new DataResult<CompanyDto>(ResultStatus.Error, Messages.Firmalar.NotFound(isPlural: false), new CompanyDto
            {
                Company = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Firmalar.NotFound(isPlural: false)
            });
        }

        public async Task<IResult> HardDeleteAsync(int firmaId)
        {
            var firmalar = await UnitOfWork.Companies.GetAsync(c => c.Id == firmaId);
            if (firmalar != null)
            {
                await UnitOfWork.Companies.DeleteAsync( firmalar);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Firmalar.HardDelete(firmalar.Name));
            }
            return new Result(ResultStatus.Error, Messages.Firmalar.NotFound(isPlural: false));
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var firmalarCount = await UnitOfWork.Companies.CountAsync();
            if (firmalarCount>-1)
            {
               return new DataResult<int>(ResultStatus.Success,firmalarCount); 
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error,$"Beklenmeyen bir hata ile karşılaşıldı.",-1);
            }
        }

    }
}
