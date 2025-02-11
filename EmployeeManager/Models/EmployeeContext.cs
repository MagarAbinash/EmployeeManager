﻿using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeModel> Employee { get; set; }
    }
}
