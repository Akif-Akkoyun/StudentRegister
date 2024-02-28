using Bogus;
using OgrenciBilgi.Api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OgrenciBilgi.Api.Data
{
    public class DbSeed
    {
        public static async Task SeedAsync(DataBaseContext dbContext)
        {
            for (int i = 1; i <= 50; i++)
            {
                var students = new Faker<StudentEntity>()
                                    .RuleFor(student => student.Id, x => x.IndexFaker)
                                    .RuleFor(student => student.FirstName, x => x.Name.FirstName())
                                    .RuleFor(student => student.LastName, x => x.Name.LastName())
                                    .RuleFor(student => student.Ardress, x => x.Address.County())
                                    .RuleFor(student => student.StudentClass, x => x.PickRandomParam("12/A","12/B","11/A","11/B","10/A","10/B","9/A","9/B"));
                dbContext.Students.Add(students);
            }            
            await dbContext.SaveChangesAsync();
        }
    }
}
