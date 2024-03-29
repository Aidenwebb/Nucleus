﻿using System.Reflection;
using Nucleus.Application.Common.Interfaces;
using Nucleus.Domain.Entities;
using Nucleus.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nucleus.Domain.CompanyAggregate.Entities;
using Nucleus.Domain.ContactAggregate.Entities;
using Nucleus.Domain.TicketAggregate.Entities;
using Nucleus.Domain.TimeEntryAggregate.Entities;

namespace Nucleus.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<TodoList> TodoLists => Set<TodoList>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    public DbSet<Company> Companies => Set<Company>();
    
    public DbSet<Contact> Contacts => Set<Contact>();
    
    public DbSet<Ticket> Tickets => Set<Ticket>();

    public DbSet<TimeEntry> TimeEntries => Set<TimeEntry>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
