using System;
using System.Diagnostics;
using System.Linq;
using Hospital.Models;
using Xunit;
using Xunit.Abstractions;

namespace Hospital.Test
{
    public class QueryTests
    {
        private readonly ITestOutputHelper output;
        public QueryTests(ITestOutputHelper output)
        {
            this.output = output;
        }
        
        [Fact]
        public void Queries()
        {
            string[] args = new[] { "" };
            var ctxFactory = new HospitalContextFactory();

            using(var ctx = ctxFactory.CreateDbContext(args))
            {
                output.WriteLine("Selecting all Employees starting with Last Name S");
                var query = from e in ctx.Employees
                    where e.LastName.Trim().StartsWith("S")
                    select e;
                
                foreach(var emp in query)
                    output.WriteLine($"{emp.FirstName} {emp.LastName}");
                output.WriteLine("");
            }
            
            using(var ctx = ctxFactory.CreateDbContext(args))
            {
                output.WriteLine("Selecting all Employees working at a Ward");

                var ward = ctx.Wards.Random();
                var query = from o in ctx.PhysicianStation
                    where o.WardId == ward.WardId
                    select new {o.Physician, o.Ward};

                foreach(var emp in query)
                    output.WriteLine($"{emp.Physician.FirstName} {emp.Physician.LastName} {emp.Ward.Name}");
            }
            
            using(var ctx = ctxFactory.CreateDbContext(args))
            {
                output.WriteLine("Selecting all Employees working at a Hospital");
            //
            //     var facility = ctx.HospitalFacilities.Random();
            //     var query = from o in ctx.PhysicianStation
            //         join sub1 in (from w in ctx.Wards where w.HospitalFacilityId == facility.FacilityId select w.WardId)
            //             on o.WardId equals sub1
            //         select new {o.Physician, o.Ward.HospitalFacility.};
            //
            //     foreach(var emp in query)
            //         output.WriteLine($"{emp.Physician.FirstName} {emp.Physician.LastName} {emp.Ward.Name}");
             }
            
            using(var ctx = ctxFactory.CreateDbContext(args))
            {
                output.WriteLine("Selecting all Employees working at a Hospital");

                var facility = ctx.HospitalFacilities.Random();
                // var query = from o in ctx.PhysicianStation
                //     join sub1 in (from w in ctx.Wards where w.HospitalFacilityId == facility.FacilityId select w.WardId)
                //         on o.WardId equals sub1
                //     select new {o.Physician, o.Ward.HospitalFacility.};
                //
                // var query2 = from
            //     foreach(var emp in query)
            //         output.WriteLine($"{emp.Physician.FirstName} {emp.Physician.LastName} {emp.Ward.Name}");
             }

        
        }
        
        [Fact]
        public void QueryTest()
        {
            var factory = new HospitalContextFactory();
            using var ctx = factory.CreateDbContext(null);
            {
                var hospital = ctx.HospitalFacilities.Random();
                Stopwatch myStopwatch = new Stopwatch();
                myStopwatch.Start();
                var query = from h in ctx.HospitalFacilities
                    join sub1 in ctx.Wards on h.FacilityId equals sub1.HospitalFacilityId into grp
                    select new {Name = h.Name, Wards = grp};
              
                myStopwatch.Stop();

                foreach (var x in query)
                {
                    output.WriteLine($"Hospital Name: {x.Name}");
                    foreach (var w in x.Wards.ToList())
                    {
                        output.WriteLine($"\tWard: {w.Name}");
                    }
                }
                output.WriteLine($"Elapsed Time {myStopwatch.Elapsed}");
            }
        }

    }
}