using Microsoft.EntityFrameworkCore;
using TransactionManagment.Models;

namespace TransactionManagment.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext

{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
         
    }
    
    
    public DbSet<GoalModel> Goals { get; set; } //declaring that they are persistent collections for the table 

    public DbSet<TransactionModel> Transactions { get; set; } //declaring that they are persistent collections for the table 
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TransactionModel>()
            .HasOne(p => p.GoalModel).WithMany(e => e.Transactions).HasForeignKey(t => t.FinancialGoalsId);

        modelBuilder.Entity<GoalModel>().Property(g => g.CurrentBalance).HasPrecision(18, 2);
        
        
        modelBuilder.Entity<GoalModel>()
            .Property(g => g.TargetQuantity)
            .HasPrecision(18, 2);

        // Para o TransactionModel
        modelBuilder.Entity<TransactionModel>()
            .Property(t => t.Quantity)
            .HasPrecision(18, 2);


    }
}


