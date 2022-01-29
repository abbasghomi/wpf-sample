using AutoMapper;
using WPFSample.Applicationz.Models;
using WPFSample.Infrastructure.Models;

namespace WPFSample.Applicationz.Mappers
{
    public static class ContactMapper
    {
        public static ContactModel ToContactModel(this ContactData contact)
        {
            var configuration = new MapperConfiguration(c => {
                c.CreateMap<ContactData, ContactModel>();
            });
            var mapper = configuration.CreateMapper();
            return mapper.Map<ContactData, ContactModel>(contact);
        }

        public static ContactData ToContactData(this ContactModel contact)
        {
            var configuration = new MapperConfiguration(c => {
                c.CreateMap<ContactModel,  ContactData> ();
            });
            var mapper = configuration.CreateMapper();
            return mapper.Map<ContactModel, ContactData>(contact);
        }

        public static List<ContactModel> ToContactModels(this List<ContactData> contacts)
        {
            var configuration = new MapperConfiguration(c => {
                c.CreateMap<ContactData, ContactModel>();
            });
            var mapper = configuration.CreateMapper();
            return mapper.Map<List<ContactData>, List<ContactModel>>(contacts);
        }

        public static List<ContactData> ToContactDatas(this List<ContactModel> contacts)
        {
            var configuration = new MapperConfiguration(c => {
                c.CreateMap<ContactModel, ContactData>();
            });
            var mapper = configuration.CreateMapper();
            return mapper.Map<List<ContactModel>, List<ContactData>>(contacts);
        }
    }
}
