using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Movie.Models
{
    public class User: IdentityUser
    {
        public ICollection<Movie> Movies { get; set; }
    }
}
