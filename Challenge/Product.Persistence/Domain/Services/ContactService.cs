using Product.Persistence.Domain.Contracts;
using Product.Persistence.Models;
using Product.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Product.Persistence.Domain.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IEnumerable<ContactDTO> GetContactList()
        {
            var listOfContacts = _contactRepository.GetContacts();
            var list = listOfContacts.Select(x => new ContactDTO
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Phone = x.Phone
            }).ToList();

            return list;
        }

        public async Task<ContactDTO> GetByIdAsync(int id)
        {
            var contact = await _contactRepository.GetByIdAsync(id);
            var result = new ContactDTO
            {
                Id = contact.Id,
                Name = contact.Name,
                Email = contact.Email,
                Phone = contact.Phone
            };
            return result;
        }

        public bool AddNewContact(ContactDTO Contact)
        {

            try
            {
                var newContact = new Contacts
                {
                    Name = Contact.Name,
                    Email = Contact.Email,
                    Phone = Contact.Phone,
                };

                using (var scope = new TransactionScope())
                {
                    _contactRepository.InsertContact(newContact);
                    scope.Complete();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        //Task<bool> UpdateContact(ContactDTO contact);
        public async Task<bool> UpdateContact(ContactDTO contact)
        {
            try
            {
                var newContact = new Contacts
                {
                    Id = contact.Id,
                    Name = contact.Name,
                    Email = contact.Email,
                    Phone = contact.Phone,
                };
                await _contactRepository.UpdateContact(newContact);
                return true;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool DeleteContact(int contactId)
        {
            _contactRepository.DeleteContact(contactId);
            return true;
        }
    }
}
