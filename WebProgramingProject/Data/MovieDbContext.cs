
using Microsoft.EntityFrameworkCore;
using WebProgramingProject.Models;

namespace WebProgramingProject.Data
{
		public class MovieDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
		
		// I Created Table for Entitys
			public Microsoft.EntityFrameworkCore.DbSet<Category> Category { get; set; }
			public Microsoft.EntityFrameworkCore.DbSet<Movie> Movie { get; set; }
			public Microsoft.EntityFrameworkCore.DbSet<Person> Person { get; set; }
			public Microsoft.EntityFrameworkCore.DbSet<Review> Review { get; set; }
			public Microsoft.EntityFrameworkCore.DbSet<MovieCategory> MovieCategory { get; set; }
			public Microsoft.EntityFrameworkCore.DbSet<MoviePerson> MoviePerson { get; set; }

            public MovieDbContext(DbContextOptions<MovieDbContext> options)
				: base(options)
			{
			}

		}
	}