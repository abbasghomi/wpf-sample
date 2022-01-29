using WPFSample.Infrastructure.Interfaces;
using WPFSample.Infrastructure.Models;

namespace WPFSample.Infrastructure.Services
{
    public class CsvHelper : ICsvHelper
    {
        private List<ContactData> MockList = new List<ContactData>
        {
            #region MockData
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
                Phone2="504-845-1427",
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
                Phone2="810-374-9840",
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
                State ="NJ",
                City ="Bridgeport",
                Zip="8014",
                Phone1="856-636-8749",
                Phone2="856-264-4130",
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
                Phone2="907-921-2010",
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
                Phone2="513-549-4561",
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
                Phone2="419-800-6759",
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
                State ="IL",
                City ="Chicago",
                Zip="60632",
                Phone1="773-573-6914",
                Phone2="773-924-8565",
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
                Phone2="408-813-1105",
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
                Phone2="605-794-4895",
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
                Phone2="410-804-4694",
                Email="kris@gmail.com",
            },
        };
        #endregion

        public List<ContactData> GetContacts()
        {
            return MockList;
        }

        public ContactData ReadContact(int id)
        {
            return MockList.FirstOrDefault();
        }
        public bool UpdateContact(ContactData contact)
        {
            var flag = false;
            for (var i = 0; i < MockList.Count; i++)
            {
                if (MockList[i].Id == contact.Id)
                {
                    MockList[i] = contact;
                    flag = true;
                }
            }
            return flag;
        }

        public bool DeleteContact(ContactData contact)
        {
            var flag = false;
            for (var i = 0; i < MockList.Count; i++)
            {
                if (MockList[i].Id == contact.Id)
                {
                    MockList.Remove(MockList[i]);
                    flag = true;
                }
            }
            return flag;
        }

        public bool CreateContact(ContactData contact)
        {
            bool flag = true;
            try
            {
                MockList.Add(contact);
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
            if (MockList.Count > 0)
            {
                newId = MockList.Select(i => i.Id).Max() + 1;
            }
            return newId;
        }
    }
}
