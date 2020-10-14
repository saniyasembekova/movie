using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Movie.Models;

namespace Movie.Web.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string Producer { get; set; }
        public string AuthorId { get; set; }
        public User Author { get; set; }
        public byte[] Poster { get; set; }
        public IFormFile NewPoster { get; set; }
    }
}
