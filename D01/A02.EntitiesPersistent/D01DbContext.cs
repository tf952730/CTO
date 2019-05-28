using ContosoUniversity.A01.Entities;
using D01.A01.Entities;
using Microsoft.EntityFrameworkCore;

public class D01DbContext : DbContext
{
    public D01DbContext(DbContextOptions<D01DbContext> options)
        : base(options)
    { }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Person> People { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 重定义了由DbSet<T>属性名表示的对应数据库表名
        modelBuilder.Entity<Person>().ToTable("person");
        base.OnModelCreating(modelBuilder);
    }
}