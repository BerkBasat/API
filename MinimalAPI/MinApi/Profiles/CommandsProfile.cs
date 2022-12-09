using AutoMapper;
using MINAPI.DTOs;
using MINAPI.Models;

namespace MINAPI.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //Source -> Target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
        }
    }
}