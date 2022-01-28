using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Sibly.Dtos;
using Sibly.Models;

namespace Sibly.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>().ForMember(c	=>	c.CustomerId,	opt	=>	opt.Ignore());
            Mapper.CreateMap<CustomerDto,Customer>().ForMember(c	=>	c.CustomerId,	opt	=>	opt.Ignore());
            Mapper.CreateMap<Movie, MovieDto>().ForMember(m	=>	m.MovieId,	opt	=>	opt.Ignore());
            Mapper.CreateMap<MovieDto,Movie>().ForMember(m	=>	m.MovieId,	opt	=>	opt.Ignore());
        }
    }
}



					