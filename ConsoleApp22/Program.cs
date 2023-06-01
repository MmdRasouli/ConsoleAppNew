using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp22
{
    class Program
    {
        static void Main(string[] args)
        {
            DemoContext context = new DemoContext();
            // context.Database.EnsureCreated();

           List<Students> Mylist = context.Students.ToList();
            foreach (var item in Mylist)
            {
                Console.WriteLine(item.Name  + "  " + item.Surname);

            }
        }

        private static void NewMethod(DemoContext context)
        {
            Students Student = new Students()
            {
                StudentId = 1,
                Name = "Ali",
                Surname = "Akbari11",
                Age = 20,

            };
            context.Students.Update(Student);
            context.SaveChanges();

            Console.WriteLine("Done");
        }

        public class DemoContext : DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-SH0S214;Database=myDataBase2;Trusted_Connection=True;");
            }

            public DbSet<Students> Students { get; set; }

        }

        public class Students
        {
            [Key]
            public int StudentId { get; set; }

            public string Name { get; set; }

            public string Surname { get; set; }

            public int Age { get; set; }

        }
    }
}
