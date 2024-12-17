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
using static ProgrammersBlog.Services.Utilities.Messages;
using Operation = ProgrammersBlog.Entities.Concrete.Operation;

namespace ProgrammersBlog.Services.Concrete
{
    public class OperationManager:ManagerBase, IOperationService
    {
        public OperationManager(IUnitOfWork unitOfWork, IMapper mapper):base(unitOfWork,mapper)
        {
        }

        public async Task<IDataResult<OperationUpdateDto>> GetOperationUpdateDtoAsync(int operasyonId)
        {
            var result = await UnitOfWork.Operation.AnyAsync(c => c.Id == operasyonId);
            if (result)
            {
                var Operation = await UnitOfWork.Operation.GetAsync(c => c.Id == operasyonId);
                var operasyonUpdateDto = Mapper.Map<OperationUpdateDto>(Operation);
                return new DataResult<OperationUpdateDto>(ResultStatus.Success, operasyonUpdateDto);
            }
            else
            {
                return new DataResult<OperationUpdateDto>(ResultStatus.Error,Messages.Operation.NotFound(isPlural:false),null);
            }
        }
        public async Task<IDataResult<OperationListDto>> GetAllByNonDeletedAsync()
        {
            var Operation = await UnitOfWork.Operation.GetAllAsync(c => !c.IsDeleted);
            if (Operation.Count > -1)
            {
                return new DataResult<OperationListDto>(ResultStatus.Success, new OperationListDto
                {
                    Operations = Operation,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<OperationListDto>(ResultStatus.Error, Messages.Operation.NotFound(isPlural: true), new OperationListDto
            {
                Operations = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Operation.NotFound(isPlural: true)
            });
        }
        public async Task<IDataResult<OperationDto>> AddAsync(OperationAddDto operasyonAddDto, string createdByName)
        {
            var Operation = Mapper.Map<Operation>(operasyonAddDto);
            var addedOperasyon = await UnitOfWork.Operation.AddAsync(Operation);
            await UnitOfWork.SaveAsync();
            return new DataResult<OperationDto>(ResultStatus.Success,Messages.Operation.Add(addedOperasyon.OperationName),new OperationDto
            {
                Operation = addedOperasyon,
                ResultStatus = ResultStatus.Success,
                Message = Messages.Bedenler.Add(addedOperasyon.OperationName)
            });
        }

        public async Task<IDataResult<OperationDto>> UpdateAsync(OperationUpdateDto operasyonUpdateDto, string modifiedByName)
        {
            var oldBedenler= await UnitOfWork.Operation.GetAsync(c => c.Id == operasyonUpdateDto.Id);
            var Operation = Mapper.Map<OperationUpdateDto, Operation>(operasyonUpdateDto, oldBedenler);
           var updatedBedenler= await UnitOfWork.Operation.UpdateAsync(Operation);
            await UnitOfWork.SaveAsync();
            return new DataResult<OperationDto>(ResultStatus.Success, Messages.Bedenler.Update(updatedBedenler.OperationName),new OperationDto
            {
                Operation = updatedBedenler,
                ResultStatus = ResultStatus.Success,
                Message = Messages.Bedenler.Update(updatedBedenler.OperationName)
            });
        }

        public async Task<IDataResult<OperationDto>> DeleteAsync(int bedenlerId, string modifiedByName)
        {
            var bedenler = await UnitOfWork.Operation.GetAsync(c => c.Id == bedenlerId);
            if (bedenler != null)
            {
                bedenler.IsDeleted = true;
                bedenler.IsActive = false;
                var deletedBedenler= await UnitOfWork.Operation.UpdateAsync(bedenler);
                await UnitOfWork.SaveAsync();
                return new DataResult<OperationDto>(ResultStatus.Success, Messages.Bedenler.Delete(deletedBedenler.OperationName), new OperationDto
                {
                    Operation = deletedBedenler,
                    ResultStatus = ResultStatus.Success,
                    Message = Messages.Bedenler.Delete(deletedBedenler.OperationName)
                });
            }
            return new DataResult<OperationDto>(ResultStatus.Error, Messages.Operation.NotFound(isPlural: false), new OperationDto
            {
                Operation = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Operation.NotFound(isPlural: false)
            });
        }

        public async Task<IResult> HardDeleteAsync(int bedenlerId)
        {
            var bedenler = await UnitOfWork.Operation.GetAsync(c => c.Id == bedenlerId);
            if (bedenler != null)
            {
                await UnitOfWork.Operation.DeleteAsync(bedenler);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Operation.HardDelete(bedenler.OperationName));
            }
            return new Result(ResultStatus.Error, Messages.Operation.NotFound(isPlural: false));
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var bedenlerCount = await UnitOfWork.Operation.CountAsync();
            if (bedenlerCount > -1)
            {
               return new DataResult<int>(ResultStatus.Success, bedenlerCount); 
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error,$"Beklenmeyen bir hata ile karşılaşıldı.",-1);
            }
        }

    }
}
