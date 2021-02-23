using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore;

using Surveys.Models;

namespace Surveys.Data
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> opt) : base(opt)
        {
            
        }

        public DbSet<Contact> Contacts { get; set; }
        
        // configuration of sql
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseMySQL("server=127.0.0.1;database=mysql;user=root;password=password");

        // }
        // enable configuration of attributes of the model
        // protected override void OnModelCreating(ModelBuilder mb)
        // {
        //     base.OnModelCreating(mb);

        //     mb.Entity<Contact>(entity =>
        //    {
        //    entity.HasKey(e => e.Id);
        //    entity.Property(e => e.FirstName).IsRequired();
        //    entity.Property(e => e.Message).IsRequired();
        //    });
        //}
    }
}