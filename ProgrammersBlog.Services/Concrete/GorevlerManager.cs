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
    public class GorevlerManager:ManagerBase, IGorevlerService
    {
        public GorevlerManager(IUnitOfWork unitOfWork, IMapper mapper):base(unitOfWork,mapper)
        {
        }

        public async Task<IDataResult<GorevlerUpdateDto>> GetGorevlerUpdateDtoAsync(int gorevlerId)
        {
            var result = await UnitOfWork.Gorevler.AnyAsync(c => c.Id == gorevlerId);
            if (result)
            {
                var gorevler = await UnitOfWork.Gorevler.GetAsync(c => c.Id == gorevlerId);
                var gorevlerUpdateDto = Mapper.Map<GorevlerUpdateDto>(gorevler);
                return new DataResult<GorevlerUpdateDto>(ResultStatus.Success,gorevlerUpdateDto);
            }
            else
            {
                return new DataResult<GorevlerUpdateDto>(ResultStatus.Error,Messages.Gorevler.NotFound(isPlural:false),null);
            }
        }

        public async Task<IDataResult<GorevlerListDto>> GetAllByNonDeletedAsync()
        {
            var gorevlers = await UnitOfWork.Gorevler.GetAllAsync(c => !c.IsDeleted);
            if (gorevlers.Count > -1)
            {
                return new DataResult<GorevlerListDto>(ResultStatus.Success, new GorevlerListDto
                {
                   Gorevlers  = gorevlers,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<GorevlerListDto>(ResultStatus.Error, Messages.Gorevler.NotFound(isPlural: true), new GorevlerListDto
            {
                Gorevlers = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Gorevler.NotFound(isPlural: true)
            });
        }
        public async Task<IDataResult<GorevlerDto>> AddAsync(GorevlerAddDto gorevlerAddDto, string createdByName)
        {
            var gorevler = Mapper.Map<Entities.Concrete.Gorevler>(gorevlerAddDto);
            var addedGorevler= await UnitOfWork.Gorevler.AddAsync(gorevler);
            await UnitOfWork.SaveAsync();
            return new DataResult<GorevlerDto>(ResultStatus.Success,Messages.Departman.Add(addedGorevler.Name),new GorevlerDto
            {
                Gorevler = addedGorevler,
                ResultStatus = ResultStatus.Success,
                Message = Messages.Gorevler.Add(addedGorevler.Name)
            });
        }
        public async Task<IDataResult<GorevlerDto>> UpdateAsync(GorevlerUpdateDto gorevlerUpdateDto, string modifiedByName)
        {
            var oldGorevler= await UnitOfWork.Gorevler.GetAsync(c => c.Id == gorevlerUpdateDto.Id);
            var gorevler = Mapper.Map<GorevlerUpdateDto, Entities.Concrete.Gorevler>(gorevlerUpdateDto, oldGorevler);
           var updatedGorevler= await UnitOfWork.Gorevler.UpdateAsync(gorevler);
            await UnitOfWork.SaveAsync();
            return new DataResult<GorevlerDto>(ResultStatus.Success, Messages.Departman.Update(updatedGorevler.Name),new GorevlerDto
            {
                Gorevler = updatedGorevler,
                ResultStatus = ResultStatus.Success,
                Message = Messages.Gorevler.Update(updatedGorevler.Name)
            });
        }
        public async Task<IDataResult<GorevlerDto>> DeleteAsync(int gorevlerId, string modifiedByName)
        {
            var gorevler = await UnitOfWork.Gorevler.GetAsync(c => c.Id == gorevlerId);
            if (gorevler != null)
            {
                gorevler.IsDeleted = true;
                gorevler.IsActive = false;
                var deletedGorevler= await UnitOfWork.Gorevler.UpdateAsync(gorevler);
                await UnitOfWork.SaveAsync();
                return new DataResult<GorevlerDto>(ResultStatus.Success, Messages.Gorevler.Delete(deletedGorevler.Name), new GorevlerDto
                {
                    Gorevler = deletedGorevler,
                    ResultStatus = ResultStatus.Success,
                    Message = Messages.Gorevler.Delete(deletedGorevler.Name)
                });
            }
            return new DataResult<GorevlerDto>(ResultStatus.Error, Messages.Gorevler.NotFound(isPlural: false), new GorevlerDto
            {
                Gorevler = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Gorevler.NotFound(isPlural: false)
            });
        }
        public async Task<IResult> HardDeleteAsync(int gorevlerId)
        {
            var gorevler = await UnitOfWork.Gorevler.GetAsync(c => c.Id == gorevlerId);
            if (gorevler != null)
            {
                await UnitOfWork.Gorevler.DeleteAsync(gorevler);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Gorevler.HardDelete(gorevler.Name));
            }
            return new Result(ResultStatus.Error, Messages.Gorevler.NotFound(isPlural: false));
        }
        public async Task<IDataResult<int>> CountAsync()
        {
            var gorevlerCount = await UnitOfWork.Gorevler.CountAsync();
            if (gorevlerCount > -1)
            {
               return new DataResult<int>(ResultStatus.Success, gorevlerCount); 
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error,$"Beklenmeyen bir hata ile karşılaşıldı.",-1);
            }
        }
    }
}
