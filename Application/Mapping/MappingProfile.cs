using Application.BookingCQRS.Commands.BookTicket;
using Application.CustomerCQRS.Commands.CreateCustomer;
using Application.DTOs.BookingDtos;
using Application.DTOs.CustomerDtos;
using Application.DTOs.EventDtos;
using Application.EventCQRS.Commands.CreateEvent;
using Application.EventCQRS.Commands.UpdateEvent;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateEventDto, CreateEventCommand>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => Enum.Parse<TypeOfEvent>(src.Type, true)));

            CreateMap<UpdateEventDto, UpdateEventCommand>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => Enum.Parse<TypeOfEvent>(src.Type, true)));

            CreateMap<BookTicketDto, BookTicketCommand>();

            CreateMap<CreateCustomerDto, CreateCustomerCommand>();

            CreateMap<Ticket, BookingHistoryDto>()
                .ForMember(dest => dest.EventName, opt => opt.MapFrom(src => src.Event.Name))
                .ForMember(dest => dest.TicketId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.EventDate, opt => opt.MapFrom(src => src.Event.StartDate))
                .ForMember(dest => dest.BookingDate, opt => opt.MapFrom(src => src.BookingDate))
                .ForMember(dest => dest.AvailableTicketsLeft, opt => opt.MapFrom(src => src.Event.AvailableTickets))  
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Event.Location));
        }
    }
}
