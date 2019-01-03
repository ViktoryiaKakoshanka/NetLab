using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using WpfPhone.Model;

namespace WpfPhone.FileService
{
    public class JsonFileService : IFileService
    {
        public List<Phone> Open(string filename)
        {
            List<Phone> phones;
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Phone>));

            using (var fileStream = new FileStream(filename, FileMode.OpenOrCreate))
            {
                phones = jsonFormatter.ReadObject(fileStream) as List<Phone>;
            }

            return phones;
        }

        public void Save(string filename, List<Phone> phones)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Phone>));

            using (var fileStream = new FileStream(filename, FileMode.Create))
            {
                jsonFormatter.WriteObject(fileStream, phones);
            }
        }
    }
}
