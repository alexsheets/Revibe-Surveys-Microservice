using AutoMapper;
using Surveys.Models;
using Surveys.Dtos;

namespace Surveys.Profiles
{
    public class ContactsProfile : Profile
    {
        public ContactsProfile()
        {
            CreateMap<Contact, ContactReadDto>();
            CreateMap<ContactCreateDto, Contact>();
            CreateMap<Contact, SendEmailDto>();
            CreateMap<SendEmailDto, Contact>();
        }
    }
}
