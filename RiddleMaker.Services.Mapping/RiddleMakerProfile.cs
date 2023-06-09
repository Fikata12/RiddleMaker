﻿using AutoMapper;

using RiddleMaker.Data.Models;
using RiddleMaker.Web.ViewModels;

namespace RiddleMaker.Services.Mapping
{
    public class RiddleMakerProfile : Profile
    {
        public RiddleMakerProfile()
        {
            //Add riddle
            CreateMap<AddRiddleViewModel, Riddle>()
                .ForMember(d => d.Text,
                         opt => opt.MapFrom(s => s.Riddle))
                .ForMember(d => d.Answer,
                         opt => opt.MapFrom(s => new Answer()
                         {
                             Text = s.Answer
                         }));

            //Get riddle
            CreateMap<Riddle, GetRiddleViewModel>()
                .ForMember(d => d.Riddle, 
                         opt => opt.MapFrom(s => s.Text));
        }
    }
}
