using AutoMapper;
using Phrase.Entities;
using Phrase.Models;


namespace Phrase.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Palindrom, PalindromModel>();
            
        }
    }
}