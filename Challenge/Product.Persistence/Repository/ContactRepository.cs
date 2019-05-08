using Microsoft.EntityFrameworkCore;
using Product.Persistence.DBContexts;
using Product.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Persistence.Repository
{
    public class _contactRepository : IContactRepository
    {
        private readonly ContactContext _dbContext;

        public _contactRepository(ContactContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteContact(int contactId)
        {
            var contact = _dbContext.Contacts.Find(contactId);
            _dbContext.Contacts.Remove(contact);
            Save();
        }

        public Contacts GetContactByID(int contactId)
        {
            return _dbContext.Contacts.Find(contactId);
        }
        public async Task<Contacts> GetByIdAsync(int id)
        {
            try
            {
                var foundById = _dbContext.Contacts.Find(id);
                return foundById;
            }
            catch (Exception e)
            {
                await Task.Delay(1000);
                throw e;
            }

            throw new ApplicationException("Hit retry limit while trying to query MongoDB");
        }

        public async Task UpdateContact(Contacts contact)
        {
            try
            {
                var k = _dbContext.Contacts.Find(contact.Id);
                if (k != null)
                {

                    k.Name = contact.Name;
                    k.Email = contact.Email;
                    k.Phone = contact.Phone;
                }
                //       _dbContext.Entry(contact).State = EntityState.Modified;
                Save();
            }
            catch (Exception e)
            {
                await Task.Delay(1000);
                throw e;
            }
        }

        public IEnumerable<Contacts> GetContacts()
        {
            return _dbContext.Contacts.ToList();
        }

        public void InsertContact(Contacts contact)
        {
            _dbContext.Add(contact);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }


    }
}
