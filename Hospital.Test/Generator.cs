using System;
using System.Collections.Generic;
using System.Linq;
using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Test
{
    public static class Generator
    {
        private static Random r = new Random();
        
        public static Employee Employee()
        {
            return new Employee()
            {
                FirstName = _firstNames[r.Next(0, _firstNames.Length)],
                LastName = _lastNames[r.Next(0, _lastNames.Length)],
                SVNR = r.Next(1, 99999),
                Salary = r.Next(10000, 100000)
            };
        }

        public static CareTaker CareTaker(CareTaker Supervisor)
        {
            return new CareTaker()
            {
                FirstName = _firstNames[r.Next(0, _firstNames.Length)],
                LastName = _lastNames[r.Next(0, _lastNames.Length)],
                SVNR = r.Next(1, 99999),
                Salary = r.Next(10000, 100000),
                Supervisor = Supervisor,
            };
        }

        public static Physician Physician()
        {
            return new Physician()
            {
                FirstName = _firstNames[r.Next(0, _firstNames.Length)],
                LastName = _lastNames[r.Next(0, _lastNames.Length)],
                SVNR = r.Next(1, 99999),
                Salary = r.Next(10000, 100000),
                JobSpecialisation = getRandom<EJobSpecialisation>()
            };
        }

        public static HospitalFacility HospitalFacility(List<string> takenHospitalNames)
        {
            string name;
            int tryCount = 0;
            do
            {
                name = _hospitalName[r.Next(_hospitalName.Length)];
            } while (takenHospitalNames.Contains(name) && ++tryCount < _hospitalName.Length * 4);
            takenHospitalNames.Add(name);
            
            return new HospitalFacility()
            {
                Name = name,
                PhoneNumber = _generatePhoneNumber()
            };
        }

        public static Ward Ward(HospitalFacility hospitalFacility, Physician leadPhysician)
        {
            return new Ward()
            {
                Name = _wardName[r.Next(_wardName.Length)],
                CarryingCapacity = r.Next(10, 100),
                HospitalFacility = hospitalFacility,
                LeadPhysician = leadPhysician,
            };
        }

        private static string[] _firstNames = new []
        {
            "Jack", "Richard", "Curtis", "Ben", "Frederick", "Jay", "Christopher"
        };

        private static string[] _lastNames = new []
        {
            "Smith", "Gates", "Trump", "Kennedy"
        };

        private static string[] _hospitalName = new []
        {
            "St. Mary", "St. Judes", "St. Edwards", "St. Janes", "Hay on Wye", "Wilhelm",
            "Blair", "Christopher", "Philipps", "Childrens Hospital", "Lincolns", "Mary Janes"
        };

        private static string[] _countryCodes = new []
        {
            "+43", "+44", "+31", "+16"
        };

        private static string[] _wardName = new[]
        {
            "ICU", "Neonatal", "XRay", "Accidents"
        };

        public static T getRandom<T>() where T : Enum
        {
            var values = Enum.GetValues(typeof(T));
            return (T) values.GetValue(r.Next(values.Length));
        }

        private static string _generatePhoneNumber()
        {
            string result = _countryCodes[r.Next(_countryCodes.Length)] + " ";
            for (int i = 0; i < 4; i++)
            {
                result += r.Next(0, 10);
            }

            result += " ";
            
            for (int i = 0; i < 7; i++)
            {
                result += r.Next(0, 10);
            }

            return result;
        }

        public static T Random<T>(this DbSet<T> set) where T : class
        {
            T value;
            int setCount = set.AsEnumerable().Count();
            int toSkip = r.Next(0, set.Count());
            value = set.Skip(toSkip).Take(1).First();
         
            return value;
        }
        
        public static T Random<T>(this DbSet<T> set, List<T> ignore) where T : class
        {
            T value;
            int setCount = set.AsEnumerable().Count();
            int tryCount = 0;
            do
            {
                int toSkip = r.Next(0, set.Count());
                value = set.Skip(toSkip).Take(1).First();
            } while (ignore.Contains(value) && ++tryCount < setCount * 4);

            if (tryCount >= setCount * 4)
            {
                return null;
            }

            return value;
        }
    }
}