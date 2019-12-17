using EvolentHealthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolentHealthAPI.Interface
{
   public interface IContact
    {
        List<Contact> GetAllData();

        bool AddData(Contact _ObjCon);

        bool UpdateData(Contact _ObjCon);


        bool DeleteData(string Id);
    }
}
