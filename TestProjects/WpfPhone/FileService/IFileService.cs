using System.Collections.Generic;
using WpfPhone.Model;

namespace WpfPhone.FileService
{
    public interface IFileService
    {
        List<Phone> Open(string filename);
        void Save(string filename, List<Phone> phones);
    }
}