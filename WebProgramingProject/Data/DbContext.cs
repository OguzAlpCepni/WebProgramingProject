using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using WebProgramingProject.Models;

namespace WebProgramingProject.Data
{
		public class ApplicationDbContext : IdentityDbContext
		{
		// I Created Table for Entitys
			public Microsoft.EntityFrameworkCore.DbSet<Category> Category { get; set; }
			public Microsoft.EntityFrameworkCore.DbSet<Movie> Movie { get; set; }
			public Microsoft.EntityFrameworkCore.DbSet<Person> Person { get; set; }
			public Microsoft.EntityFrameworkCore.DbSet<Review> Review { get; set; }
			public Microsoft.EntityFrameworkCore.DbSet<MovieCategory> MovieCategory { get; set; }
			public Microsoft.EntityFrameworkCore.DbSet<MoviePerson> MoviePerson { get; set; }
			public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
				: base(options)
			{
			}

		}
	}