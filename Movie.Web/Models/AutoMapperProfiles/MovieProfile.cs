using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Internal;
using Microsoft.AspNetCore.Http;
using Movie.Models;
using MovieModel = Movie.Models.Movie;

namespace Movie.Web.Models.AutoMapperProfiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieModel, MovieViewModel>();
            CreateMap<MovieViewModel, MovieModel>()
                .ForMember(dest => dest.Poster, opt => opt
                    .MapFrom(src => src.NewPoster==null ? src.Poster : GetBytesFromFile(src.NewPoster)));
        }

        private byte[] GetBytesFromFile(IFormFile file)
        {
            if (file != null)
            {
                byte[] imageData = null;

                using (var binaryReader = new BinaryReader(file.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)file.Length);
                }
                return imageData;
            }

            return null;
        }
    }
}
