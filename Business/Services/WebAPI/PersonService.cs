using DataAccess.Concrete.Repository;
using Entity;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
namespace Business.Services.WebAPI
{
    public class PersonService
    {
        private readonly PersonRepo personRepo;

        public PersonService(PersonRepo _personRepo)
        {
            personRepo = _personRepo;
        }
        //kisi listesi cekme servisi
        public ServiceResult<Person> GetPersons()
        {
            try
            {
               return new ServiceResult<Person>(true, datas: personRepo.GetList());
             
            }
            catch(Exception ex)
            {
                return new ServiceResult<Person>(false, message:"Kişi Listesi Alınırken Bir Hata Oluştu",new List<Person>());
            }
        }

        public ServiceResult<Person> GetInvoices()
        {
            try
            {
                return new ServiceResult<Person>(true, datas: personRepo.GetInvoices());

            }
            catch (Exception ex)
            {
                return new ServiceResult<Person>(false, message: "Fatura Listesi Alınırken Bir Hata Oluştu", new List<Person>());
            }
        }

        //yeni kisi ekleme servisi
        public ServiceResult<Person> AddPerson(Person person)
        {
            try
            {
                return new ServiceResult<Person>(isSuccess:personRepo.AddPerson(person),message:"Kişi başarıyla eklendi.");

            }
            catch(Exception ex)
            {
                return new ServiceResult<Person>(false, message: "Kişi Eklenirken Bir Hata Oluştu");
            }
        }
    }
}
