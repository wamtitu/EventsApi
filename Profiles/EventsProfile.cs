using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Events.Models;
using Events.Requests;

namespace Events.Profiles
{
    public class EventsProfile : Profile
    {
        public EventsProfile(){

         CreateMap<CreateEvent, Event>().ReverseMap();
         CreateMap<CreateUser, User>().ReverseMap();
        }
    }
}