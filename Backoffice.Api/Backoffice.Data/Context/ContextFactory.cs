using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Backoffice.Data.Context;

public class ContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {        
        var connectionString = "Server=localhost; Database=Backoffice; User Id=userBackoffice; Password=!Backoffice@7;TrustServerCertificate=true;";
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(connectionString);     
        return new AppDbContext(optionsBuilder.Options);

    }
}

