using System;
using System.Collections.Generic;
using System.Linq;
using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Xunit;

namespace Hospital.Test
{
    public class DatabaseTests
    {
        [Theory]
        [InlineData("")]
        public void DataTest(params string[] args)
        {
            // DO NOT RUN IN PRODUCTION I REPEAT DO NOT RUN IN PRODUCTION
            
            var factory = new HospitalContextFactory();
            // Empty Database
            using (var context = factory.CreateDbContext(args))
            {
                context.Database.ExecuteSqlRaw("DELETE FROM PHYSICIAN_STATION_JT WHERE 1 = 1");
                context.Database.ExecuteSqlRaw("DELETE FROM WARDS WHERE 1 = 1");
                context.Database.ExecuteSqlRaw("DELETE FROM HOSPITAL_FACILITIES WHERE 1 = 1");
                context.Database.ExecuteSqlRaw("DELETE FROM EMPLOYEES WHERE 1 = 1");
                context.Database.ExecuteSqlRaw("DELETE FROM CARE_TAKERS WHERE 1 = 1");
                context.Database.ExecuteSqlRaw("DELETE FROM PHYSICIANS WHERE 1 = 1");
            }

            Random r = new Random();
            using (var context = factory.CreateDbContext(args))
            {
                for (int i = 0; i < 10; i++)
                    context.Employees.Add(Generator.Employee());
                
                context.CareTakers.Add(Generator.CareTaker(null));
                context.SaveChanges();

                for (int i = 0; i < 10; i++)
                {
                    context.CareTakers.Add(Generator.CareTaker(context.CareTakers.Random()));
                    context.SaveChanges();
                }

                for (int i = 0; i < 10; i++)
                    context.Physicians.Add(Generator.Physician());

                List<string> takenHospitalNames = new List<string>();
                for (int i = 0; i < 10; i++)
                    context.HospitalFacilities.Add(Generator.HospitalFacility(takenHospitalNames));
                
                context.SaveChanges();
                List<Physician> takenLeadPhysicians = new List<Physician>();
                for (int i = 0; i < 10; i++)
                    takenLeadPhysicians.Add(context.Wards.Add(Generator.Ward(context.HospitalFacilities.Random(), context.Physicians.Random(takenLeadPhysicians))).Entity.LeadPhysician);
                
                context.SaveChanges();

                List<Physician> takenPhysicians = new List<Physician>();
                for (int i = 0; i < 5; i++)
                {
                    var p = context.Physicians.Random(takenPhysicians);
                    takenPhysicians.Add(context.PhysicianStation.Add(new PhysicianStation()
                    {
                        Physician = p,
                        Ward = context.Wards.Random(),
                        WorkingHours = r.Next(10, 80),
                        PhysicianId = p.EmployeeId,
                    }).Entity.Physician);
                }
                  
                
                context.SaveChanges();
            }
        }
    }
}