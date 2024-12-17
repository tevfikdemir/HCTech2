using AutoMapper;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete;
using ProgrammersBlog.Entities.ComplexTypes;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Services.Utilities;
using ProgrammersBlog.Shared.Entities.Concrete;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static ProgrammersBlog.Services.Utilities.Messages;


namespace ProgrammersBlog.Services.Concrete
{
    public class PersonWorkManager : ManagerBase, IPersonWorkService
    {
        public PersonWorkManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }


        public async Task<IDataResult<PersonWorkListDto>> GetAllAsync()
        {
            var personWorks = await UnitOfWork.PersonWorks.GetAllAsync(null,
                        pw => pw.OrderOperation,
                        pw => pw.Operations,
                        pw => pw.Orders,
                        PersonWork=>PersonWork.Persons);
            if (personWorks != null)
            {
                var personWorkDtos = personWorks.Select(pw =>
                {
                    var dto = Mapper.Map<PersonWorkDto>(pw);
                    dto.OperationTarget = pw.OrderOperation.OperationTarget; // OperationTarget'ı ekle
                    return dto;
                }).ToList();

                var personWorkListDto = new PersonWorkListDto
                {
                    PersonWorks = personWorkDtos
                };

                return new DataResult<PersonWorkListDto>(ResultStatus.Success, personWorkListDto);
            }

            return new DataResult<PersonWorkListDto>(ResultStatus.Error, Messages.Order.NotFound(isPlural: true), null);
        }
        public async Task<IDataResult<PersonWorkDto>> AddAsync(PersonWorkAddDto orderpersonsizeAddDto)
        {


            var orderpersonsize = Mapper.Map<PersonWork>(orderpersonsizeAddDto);


            var addedOrderPersonSize = await UnitOfWork.PersonWorks.AddAsync(orderpersonsize);
            await UnitOfWork.SaveAsync();
            var orderDto = Mapper.Map<PersonWorkDto>(addedOrderPersonSize);
            return new DataResult<PersonWorkDto>(ResultStatus.Success, Messages.Order.Add(addedOrderPersonSize.OperationId.ToString()), orderDto);
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var ordersCount = await UnitOfWork.PersonWorks.CountAsync();
            if (ordersCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, ordersCount);
            }
            return new DataResult<int>(ResultStatus.Error, "Beklenmeyen bir hata ile karşılaşıldı.", -1);
        }
         
        public async Task<IDataResult<PersonWorkDto>> GetAsync(int orderId, int operationId)
        {
            var personwork = await UnitOfWork.PersonWorks.GetAsync(a => a.OrderOperationOrderId == orderId && a.OrderOperationOperationId == operationId);
            if (personwork != null)
            {
                return new DataResult<PersonWorkDto>(ResultStatus.Success, new PersonWorkDto
                {
                    PersonWork = personwork,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<PersonWorkDto>(ResultStatus.Error, Messages.Article.NotFound(isPlural: false), null);
        }

        public async Task<IDataResult<PersonWorkDto>> GetByIdAsync(int pwId)
        {
            List<Expression<Func<PersonWork, bool>>> predicates = new List<Expression<Func<PersonWork, bool>>>();
            List<Expression<Func<PersonWork, object>>> includes = new List<Expression<Func<PersonWork, object>>>();
            includes.Add(a => a.OrderOperation);
            includes.Add(a => a.Operations);
            includes.Add(a => a.Orders);


            predicates.Add(a => a.Id == pwId);
            var personworks = await UnitOfWork.PersonWorks.GetAsyncV2(predicates, includes);
            if (personworks == null)
            {
                return new DataResult<PersonWorkDto>(ResultStatus.Warning, Messages.General.ValidationError(), null,
                    new List<ValidationError>
                    {
                        new ValidationError
                        {
                            PropertyName = "pwId",
                            Message = Messages.Article.NotFoundById(pwId)
                        }
                    });
            }

            return new DataResult<PersonWorkDto>(ResultStatus.Success, new PersonWorkDto
            {
                PersonWork = personworks
            });
        }

        public async Task<IDataResult<List<PersonPerformansDTO>>> GetAllPersonWorkDtosAsync()
        {
            var personWorks = await UnitOfWork.PersonWorks.GetAllAsync(null,
                pw => pw.OrderOperation,
                pw => pw.Operations,
                pw => pw.Orders,
                pw => pw.Persons);

            if (personWorks != null)
            {
                var personPerformansDtos = personWorks.Select(pw =>
                {
                    var dto = Mapper.Map<PersonPerformansDTO>(pw);
                    dto.OperationName = pw.Operations.OperationName;
                    dto.PersonName = pw.Persons.FirstName; // Assuming `Name` is a property in `Person`
                    dto.Target = pw.OrderOperation.OperationTarget; // Hedef
                    dto.OrderType = pw.Orders.OrderType;
                    dto.Quantity = pw.Quantity;
                    dto.Performance = (double)pw.Quantity / pw.OrderOperation.OperationTarget * 100;
                    return dto;
                }).ToList();

                return new DataResult<List<PersonPerformansDTO>>(ResultStatus.Success, personPerformansDtos);
            }

            return new DataResult<List<PersonPerformansDTO>>(ResultStatus.Error, Messages.Order.NotFound(isPlural: true), null);

        }
    }

}
