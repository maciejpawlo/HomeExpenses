using AutoMapper;
using HomeExpenses.Tracking.Application.Shared.DTOs;
using HomeExpenses.Tracking.Domain.Entities.Expense;
using HomeExpenses.Tracking.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeExpenses.Tracking.Application.Shared.MappingProfiles
{
    public class DomainToDTOProfile : Profile
    {
        public DomainToDTOProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<ExpenseDTO, Expense>().ReverseMap();
        }
    }
}
