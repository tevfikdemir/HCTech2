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
using Size = ProgrammersBlog.Entities.Concrete.Size;

namespace ProgrammersBlog.Services.Concrete
{
    public class SizeManager:ManagerBase, ISizeService
    {
        public SizeManager(IUnitOfWork unitOfWork, IMapper mapper):base(unitOfWork,mapper)
        {
        }

        public async Task<IDataResult<SizeUpdateDto>> GetSizeUpdateDtoAsync(int sizeId)
        {
            var result = await UnitOfWork.Size.AnyAsync(c => c.Id == sizeId);
            if (result)
            {
                var size = await UnitOfWork.Size.GetAsync(c => c.Id == sizeId);
                var sizeUpdateDto = Mapper.Map<SizeUpdateDto>(size);
                return new DataResult<SizeUpdateDto>(ResultStatus.Success,sizeUpdateDto);
            }
            else
            {
                return new DataResult<SizeUpdateDto>(ResultStatus.Error,Messages.Bedenler.NotFound(isPlural:false),null);
            }
        }
        public async Task<IDataResult<SizeListDto>> GetAllByNonDeletedAsync()
        {
            var size = await UnitOfWork.Size.GetAllAsync(c => !c.IsDeleted);
            if (size.Count > -1)
            {
                return new DataResult<SizeListDto>(ResultStatus.Success, new SizeListDto
                {
                    Sizes = size,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<SizeListDto>(ResultStatus.Error, Messages.Bedenler.NotFound(isPlural: true), new SizeListDto
            {
                Sizes = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Bedenler.NotFound(isPlural: true)
            });
        }
        public async Task<IDataResult<SizeDto>> AddAsync(SizeAddDto sizeAddDto, string createdByName)
        {
            var size = Mapper.Map<Size>(sizeAddDto);
            var addedSize = await UnitOfWork.Size.AddAsync(size);
            await UnitOfWork.SaveAsync();
            return new DataResult<SizeDto>(ResultStatus.Success,Messages.Bedenler.Add(addedSize.SizeName),new SizeDto
            {
                Size = addedSize,
                ResultStatus = ResultStatus.Success,
                Message = Messages.Bedenler.Add(addedSize.SizeName)
            });
        }
        public async Task<IDataResult<SizeDto>> UpdateAsync(SizeUpdateDto bedenlerUpdateDto, string modifiedByName)
        {
            var oldSize= await UnitOfWork.Size.GetAsync(c => c.Id == bedenlerUpdateDto.Id);
            var size = Mapper.Map<SizeUpdateDto,Size>(bedenlerUpdateDto, oldSize);
           var updatedSize= await UnitOfWork.Size.UpdateAsync(size);
            await UnitOfWork.SaveAsync();
            return new DataResult<SizeDto>(ResultStatus.Success, Messages.Bedenler.Update(updatedSize.SizeName),new SizeDto
            {
                Size = updatedSize,
                ResultStatus = ResultStatus.Success,
                Message = Messages.Bedenler.Update(updatedSize.SizeName)
            });
        }
        public async Task<IDataResult<SizeDto>> DeleteAsync(int sizeId, string modifiedByName)
        {
            var size = await UnitOfWork.Size.GetAsync(c => c.Id == sizeId);
            if (size != null)
            {
                size.IsDeleted = true;
                size.IsActive = false;
                var deletedSize= await UnitOfWork.Size.UpdateAsync(size);
                await UnitOfWork.SaveAsync();
                return new DataResult<SizeDto>(ResultStatus.Success, Messages.Bedenler.Delete(deletedSize.SizeName), new SizeDto
                {
                    Size = deletedSize,
                    ResultStatus = ResultStatus.Success,
                    Message = Messages.Bedenler.Delete(deletedSize.SizeName)
                });
            }
            return new DataResult<SizeDto>(ResultStatus.Error, Messages.Bedenler.NotFound(isPlural: false), new SizeDto
            {
                Size = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Bedenler.NotFound(isPlural: false)
            });
        }
        public async Task<IResult> HardDeleteAsync(int sizeId)
        {
            var size = await UnitOfWork.Size.GetAsync(c => c.Id == sizeId);
            if (size != null)
            {
                await UnitOfWork.Size.DeleteAsync(size);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Bedenler.HardDelete(size.SizeName));
            }
            return new Result(ResultStatus.Error, Messages.Bedenler.NotFound(isPlural: false));
        }
        public async Task<IDataResult<int>> CountAsync()
        {
            var sizeCount = await UnitOfWork.Size.CountAsync();
            if (sizeCount > -1)
            {
               return new DataResult<int>(ResultStatus.Success, sizeCount); 
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error,$"Beklenmeyen bir hata ile karşılaşıldı.",-1);
            }
        }

    }
}
