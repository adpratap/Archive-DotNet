PostgreSQL: Entity Framework Core.

Tools: Entity Framework Core 

Design: Entity Framework Core 



DB:
------appsetting.json---------

"ConnectionStrings": {
  "DbConnectionString": "<DB String>"
}

------program.cs------- before <builder.build()>

builder.Services.AddDbContext<ArchiveDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnectionString")));

---------<Create DB Context File>-----------

public class ArchiveDbContext : DbContext
{
    public ArchiveDbContext(DbContextOptions options) : base(options) { 
    }

    public DbSet<ArchiveModel> Archives { get; set; }
}


--------Add-Migration YourMigrationName
--------Update-Database


public virtual ICollection<DocumentsData> Documents { get; set; }

inside Doc --->
[ForeignKey("User")]
public Guid UserID { get; set; }

public virtual UserData User { get; set; }


