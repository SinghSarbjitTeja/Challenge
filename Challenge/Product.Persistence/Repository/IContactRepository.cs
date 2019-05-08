using Product.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Persistence.Repository
{
   public interface IContactRepository
    {
        IEnumerable<Contacts> GetContacts();
        Task<Contacts> GetByIdAsync(int id);
        Task UpdateContact(Contacts contact);
        void InsertContact(Contacts contact);
        void DeleteContact(int contactId);
        void Save();
    }
}
