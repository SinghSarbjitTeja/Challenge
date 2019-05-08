using Microsoft.AspNetCore.Mvc;
using Product.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Persistence.Domain.Contracts
{
   public interface IContactService
    {
        Task<ContactDTO> GetByIdAsync(int id);
        Task<bool> UpdateContact(ContactDTO contact);
        bool DeleteContact(int contactId);
        IEnumerable<ContactDTO> GetContactList();
        bool AddNewContact(ContactDTO Contact);
    }
}
