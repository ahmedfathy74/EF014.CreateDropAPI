
// first trial add create database without migration

//using EF014.CreateDropAPI.Data;
//using Microsoft.EntityFrameworkCore;

//using (var context = new AppDbContext())
//{
//    // Database will be created if it does not exist
//    await context.Database.EnsureCreatedAsync();

//    // this line will get for me script that will be generted for migration without do it
//    var sqlScript = context.Database.GenerateCreateScript();

//    // delay the task
//    await Task.Delay(30000);

//    // Detabase will be deleted if it does exist

//    await context.Database.EnsureDeletedAsync();

//}

// Seeding Data with insert in configuration file foreach table

/*
namespace EF014.CreateDropAPI
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.ReadKey();
        }
    }
}
*/


// Seeding Data WithOut insert in configuration file foreach table

using EF014.CreateDropAPI.Data;
using EF014.CreateDropAPI.Entities;
using EF014.CreateDropAPI.SeedDataModel;
using Microsoft.EntityFrameworkCore;

namespace EF014.CreateDropAPI
{
    class Program
    {
        public static async void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                await context.Database.EnsureCreatedAsync();

                if (!await context.Set<Individual>().AnyAsync())
                {
                    context.Set<Individual>().AddRange(SeedData.LoadIndividuals());
                }
                if (!await context.Set<Corporate>().AnyAsync())
                {
                    context.Set<Corporate>().AddRange(SeedData.LoadCorporates());
                }
                if (!await context.Set<Course>().AnyAsync())
                {
                    context.Set<Course>().AddRange(SeedData.LoadCourses());
                }
                if (!await context.Set<Office>().AnyAsync())
                {
                    context.Set<Office>().AddRange(SeedData.LoadOffices());
                }
                if (!await context.Set<Schedule>().AnyAsync())
                {
                    context.Set<Schedule>().AddRange(SeedData.LoadSchedules());
                }
                if (!await context.Set<Instructor>().AnyAsync())
                {
                    context.Set<Instructor>().AddRange(SeedData.LoadInstructors());
                }
                if (!await context.Set<Section>().AnyAsync())
                {
                    // will added later
                    //context.Set<Section>().AddRange(SeedData.LoadSections());
                }
                if (!await context.Set<Enrollment>().AnyAsync())
                {
                    context.Set<Enrollment>().AddRange(SeedData.LoadEnrollments());
                }

                await context.SaveChangesAsync();
            }
            Console.ReadKey();
        }
    }
}
