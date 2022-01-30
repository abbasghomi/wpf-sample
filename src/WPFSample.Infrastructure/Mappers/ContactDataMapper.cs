using CsvHelper.Configuration;
using WPFSample.Infrastructure.Models;

namespace WPFSample.Infrastructure.Mappers
{
    public class ContactDataMapper : ClassMap<ContactData>
    {
        public ContactDataMapper()
        {
            Map(m => m.Id).Name("id");
            Map(m => m.FirstName).Name("first_name");
            Map(m => m.LastName).Name("last_name");
            Map(m => m.CompanyName).Name("company_name");
            Map(m => m.Address).Name("address");
            Map(m => m.City).Name("city");
            Map(m => m.Country).Name("county");
            Map(m => m.State).Name("state");
            Map(m => m.Zip).Name("zip");
            Map(m => m.Phone1).Name("phone1");
            Map(m => m.Phone).Name("phone");
            Map(m => m.Email).Name("email");
        }
    }
}
