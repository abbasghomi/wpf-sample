using CsvHelper;
using System.Globalization;
using WPFSample.Infrastructure.Interfaces;
using WPFSample.Infrastructure.Mappers;
using WPFSample.Infrastructure.Models;

namespace WPFSample.Infrastructure.Services
{
    public class CsvHelperService : ICsvHelperService
    {
        private string csvFilePath = "DataFiles\\100-contacts.csv";

        private List<ContactData> contacts = new List<ContactData>();

        #region MockData
        private List<ContactData> MockData = new List<ContactData>
        {
            new ContactData
            {
                Id =1,
                FirstName="James",
                LastName ="Butt",
                CompanyName="Benton, John B Jr",
                Address="6649 N Blue Gum St",
                Country="Orleans",
                State ="LA",
                City ="New Orleans",
                Zip="70116",
                Phone1="504-621-8927",
                Phone="504-845-1427",
                Email="jbutt@gmail.com",
            },
            new ContactData
            {
                Id =2,
                FirstName="Josephine",
                LastName ="Darakjy",
                CompanyName="Chanay, Jeffrey A Esq",
                Address="4 B Blue Ridge Blvd",
                Country="Livingston",
                State ="MI",
                City ="Brighton",
                Zip="48116",
                Phone1="810-292-9388",
                Phone="810-374-9840",
                Email="josephine_darakjy@darakjy.org",
            },
            new ContactData
            {
                Id =3,
                FirstName="Art",
                LastName ="Venere",
                CompanyName="Chemel, James L Cpa",
                Address="8 W Cerritos Ave #54",
                Country="Gloucester",
                State ="TX",
                City ="Bridgeport",
                Zip="8014",
                Phone1="856-636-8749",
                Phone="856-264-4130",
                Email="art@venere.org",
            },
            new ContactData
            {
                Id =4,
                FirstName="Lenna",
                LastName ="Paprocki",
                CompanyName="Feltz Printing Service",
                Address="639 Main St",
                Country="Anchorage",
                State ="AK",
                City ="Anchorage",
                Zip="99501",
                Phone1="907-385-4412",
                Phone="907-921-2010",
                Email="lpaprocki@hotmail.com",
            },
            new ContactData
            {
                Id =5,
                FirstName="Donette",
                LastName ="Foller",
                CompanyName="Printing Dimensions",
                Address="34 Center St",
                Country="Butler",
                State ="OH",
                City ="Hamilton",
                Zip="45011",
                Phone1="513-570-1893",
                Phone="513-549-4561",
                Email="donette.foller@cox.net",
            },
            new ContactData
            {
                Id =6,
                FirstName="Simona",
                LastName ="Morasca",
                CompanyName="Chapman, Ross E Esq",
                Address="3 Mcauley Dr",
                Country="Ashland",
                State ="OH",
                City ="Ashland",
                Zip="44805",
                Phone1="419-503-2484",
                Phone="419-800-6759",
                Email="simona@morasca.com",
            },
            new ContactData
            {
                Id =7,
                FirstName="Mitsue",
                LastName ="Tollner",
                CompanyName="Morlong Associates",
                Address="7 Eads St",
                Country="Cook",
                State ="TX",
                City ="Chicago",
                Zip="60632",
                Phone1="773-573-6914",
                Phone="773-924-8565",
                Email="mitsue_tollner@yahoo.com",
            },
            new ContactData
            {
                Id =8,
                FirstName="Leota",
                LastName ="Dilliard",
                CompanyName="Commercial Press",
                Address="7 W Jackson Blvd",
                Country="Santa Clara",
                State ="CA",
                City ="San Jose",
                Zip="95111",
                Phone1="408-752-3500",
                Phone="408-813-1105",
                Email="leota@hotmail.com",
            },
            new ContactData
            {
                Id =9,
                FirstName="Sage",
                LastName ="Wieser",
                CompanyName="Truhlar And Truhlar Attys",
                Address="5 Boston Ave #88",
                Country="Minnehaha",
                State ="SD",
                City ="Sioux Falls",
                Zip="57105",
                Phone1="605-414-2147",
                Phone="605-794-4895",
                Email="sage_wieser@cox.net",
            },
            new ContactData
            {
                Id =10,
                FirstName="Kris",
                LastName ="Marrier",
                CompanyName="King, Christopher A Esq",
                Address="228 Runamuck Pl #2808",
                Country="Baltimore",
                State ="MD",
                City ="Baltimore City",
                Zip="21224",
                Phone1="410-655-8723",
                Phone="410-804-4694",
                Email="kris@gmail.com",
            },
        };
        #endregion

        private void ReadContactsFromCsvFile()
        {
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<ContactDataMapper>();
                contacts = csv.GetRecords<ContactData>().ToList();
            }
        }

        private void WriteContactsFromCsvFile()
        {
            using (var writer = new StreamWriter(csvFilePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<ContactDataMapper>();
                csv.WriteRecords(contacts);
            }
        }

        public List<ContactData> GetContacts()
        {
            ReadContactsFromCsvFile();
            return contacts;
        }

        public ContactData ReadContact(int id)
        {
            return contacts.FirstOrDefault();
        }
        public bool UpdateContact(ContactData contact)
        {
            var flag = false;
            for (var i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].Id == contact.Id)
                {
                    contacts[i] = contact;
                    flag = true;
                    WriteContactsFromCsvFile();
                }
            }
            return flag;
        }

        public bool DeleteContact(ContactData contact)
        {
            var flag = false;
            for (var i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].Id == contact.Id)
                {
                    contacts.Remove(contacts[i]);
                    flag = true;
                    WriteContactsFromCsvFile();
                }
            }
            return flag;
        }
        public bool DeleteContactById(int id)
        {
            var flag = false;
            for (var i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].Id == id)
                {
                    contacts.Remove(contacts[i]);
                    flag = true;
                    WriteContactsFromCsvFile();
                }
            }
            return flag;
        }

        public bool CreateContact(ContactData contact)
        {
            bool flag = true;
            try
            {
                contacts.Add(contact);
                WriteContactsFromCsvFile();
            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }

        public int GetNewId()
        {
            var newId = 1;
            if (contacts.Count > 0)
            {
                newId = contacts.Select(i => i.Id).Max() + 1;
            }
            return newId;
        }
    }
}
