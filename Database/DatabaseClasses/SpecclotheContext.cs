using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SpecClothes.Database.DatabaseClasses;

public partial class SpecclotheContext : DbContext
{
    private static SpecclotheContext _context;
    public SpecclotheContext()
    {
    }
    public static SpecclotheContext GetContext()
    {
        if (_context == null)
            _context = new SpecclotheContext();
        return _context;
    }

    public SpecclotheContext(DbContextOptions<SpecclotheContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clothe> Clothes { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Variable> Variables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\admin\\Source\\Repos\\SpecClothes2\\Database\\specclothe.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clothe>(entity =>
        {
            entity.HasKey(e => e.Idclothes);

            entity.ToTable("clothes");

            entity.Property(e => e.Idclothes).HasColumnName("idclothes");
            entity.Property(e => e.Clothe1).HasColumnName("clothe");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Term).HasColumnName("term");
            entity.Property(e => e.VariableIdVariable).HasColumnName("Variable_idVariable");

            entity.HasOne(d => d.VariableIdVariableNavigation).WithMany(p => p.Clothes)
                .HasForeignKey(d => d.VariableIdVariable)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.Iddelivery);

            entity.ToTable("delivery");

            entity.Property(e => e.Iddelivery).HasColumnName("iddelivery");
            entity.Property(e => e.ClothesIdclothes).HasColumnName("clothes_idclothes");
            entity.Property(e => e.Datato).HasColumnName("datato");
            entity.Property(e => e.Datatrade).HasColumnName("datatrade");
            entity.Property(e => e.EmployeesIdEmployees).HasColumnName("Employees_idEmployees");

            entity.HasOne(d => d.ClothesIdclothesNavigation).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.ClothesIdclothes)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.EmployeesIdEmployeesNavigation).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.EmployeesIdEmployees)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Iddepartment);

            entity.ToTable("departments");

            entity.Property(e => e.Iddepartment).HasColumnName("iddepartment");
            entity.Property(e => e.Department1).HasColumnName("department");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdEmployees);

            entity.ToTable("employees");

            entity.Property(e => e.IdEmployees).HasColumnName("idEmployees");
            entity.Property(e => e.DepartmentsIddepartment).HasColumnName("departments_iddepartment");
            entity.Property(e => e.Fio).HasColumnName("FIO");
            entity.Property(e => e.PositionIdposition).HasColumnName("position_idposition");

            entity.HasOne(d => d.DepartmentsIddepartmentNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentsIddepartment)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.PositionIdpositionNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionIdposition)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Idposition);

            entity.ToTable("position");

            entity.Property(e => e.Idposition).HasColumnName("idposition");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.Posi).HasColumnName("posi");
        });

        modelBuilder.Entity<Variable>(entity =>
        {
            entity.HasKey(e => e.IdVariable);

            entity.ToTable("variable");

            entity.Property(e => e.IdVariable).HasColumnName("idVariable");
            entity.Property(e => e.Variable1).HasColumnName("variable");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
