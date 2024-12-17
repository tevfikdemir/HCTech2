using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.ComplexTypes;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Services.Utilities;
using ProgrammersBlog.Shared.Entities.Concrete;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;

namespace ProgrammersBlog.Services.Concrete
{
    public class PersonManager : ManagerBase, IPersonService
    {
        public PersonManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IDataResult<PersonUpdateDto>> GetPersonelUpdateDtoAsync(int personId)
        {
            var result = await UnitOfWork.Persons.AnyAsync(c => c.Id == personId);
            if (result)
            {
                var person = await UnitOfWork.Persons.GetAsync(c => c.Id == personId);
                var personUpdateDto = Mapper.Map<PersonUpdateDto>(person);
                return new DataResult<PersonUpdateDto>(ResultStatus.Success, personUpdateDto);
            }
            else
            {
                return new DataResult<PersonUpdateDto>(ResultStatus.Error, Messages.Personel.NotFound(isPlural: false), null);
            }
        }
        public async Task<IDataResult<PersonListDto>> GetAllByNonDeletedAsync()
        {
            var persons = await UnitOfWork.Persons.GetAllAsync(c => !c.IsDeleted, ar => ar.Department, ar => ar.Gorevler);
            if (persons.Count > -1)
            {
                return new DataResult<PersonListDto>(ResultStatus.Success, new PersonListDto
                {
                    Persons = persons,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<PersonListDto>(ResultStatus.Error, Messages.Personel.NotFound(isPlural: true), new PersonListDto
            {
                Persons = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Personel.NotFound(isPlural: true)
            });
        }
        public async Task<IDataResult<PersonDto>> AddAsync(PersonAddDto personAddDto, string createdByName)
        {
            var person = Mapper.Map<Person>(personAddDto);
            var addedPerson = await UnitOfWork.Persons.AddAsync(person);
            await UnitOfWork.SaveAsync();
            return new DataResult<PersonDto>(ResultStatus.Success, Messages.Personel.Add(addedPerson.FirstName), new PersonDto
            {
                Person = addedPerson,
                ResultStatus = ResultStatus.Success,
                Message = Messages.Personel.Add(addedPerson.FirstName)
            });
        }
        public async Task<IDataResult<PersonDto>> UpdateAsync(PersonUpdateDto personUpdateDto, string modifiedByName)
        {
            var oldPerson = await UnitOfWork.Persons.GetAsync(c => c.Id == personUpdateDto.Id);
            var person = Mapper.Map<PersonUpdateDto, Person>(personUpdateDto, oldPerson);
            var updatedPerson = await UnitOfWork.Persons.UpdateAsync(person);
            await UnitOfWork.SaveAsync();
            return new DataResult<PersonDto>(ResultStatus.Success, Messages.Personel.Update(updatedPerson.FirstName), new PersonDto
            {
                Person = updatedPerson,
                ResultStatus = ResultStatus.Success,
                Message = Messages.Personel.Update(updatedPerson.FirstName)
            });
        }
        public async Task<IDataResult<PersonDto>> DeleteAsync(int personId, string modifiedByName)
        {
            var person = await UnitOfWork.Persons.GetAsync(c => c.Id == personId);
            if (person != null)
            {
                person.IsDeleted = true;
                person.IsActive = false;
                var deletedPerson = await UnitOfWork.Persons.UpdateAsync(person);
                await UnitOfWork.SaveAsync();
                return new DataResult<PersonDto>(ResultStatus.Success, Messages.Personel.Delete(deletedPerson.FirstName), new PersonDto
                {
                    Person = deletedPerson,
                    ResultStatus = ResultStatus.Success,
                    Message = Messages.Personel.Delete(deletedPerson.FirstName)
                });
            }
            return new DataResult<PersonDto>(ResultStatus.Error, Messages.Personel.NotFound(isPlural: false), new PersonDto
            {
                Person = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.Personel.NotFound(isPlural: false)
            });
        }
        public async Task<IResult> HardDeleteAsync(int personId)
        {
            var person = await UnitOfWork.Persons.GetAsync(c => c.Id == personId);
            if (person != null)
            {
                await UnitOfWork.Persons.DeleteAsync(person);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Personel.HardDelete(person.FirstName));
            }
            return new Result(ResultStatus.Error, Messages.Personel.NotFound(isPlural: false));
        }
        public async Task<IDataResult<int>> CountAsync()
        {
            var personsCount = await UnitOfWork.Persons.CountAsync();
            if (personsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, personsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
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
