using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper.Oracle;

namespace DataAccess.Concrete.Repository
{
    public class PersonRepo
    {

        public List<Person> GetList()
        {
            return new DbContext<Person>().GetList("SELECT * FROM public.person order by id desc").ToList();
        }

        public bool AddPerson(Person person)
        {
            return new DbContext<Person>().Insert("INSERT INTO public.person (Name,Surname,Phone,Adress,BloodGroup) VALUES (@Name,@Surname,@Phone,@Adress,@BloodGroup)", person);
        }

        public List<Person> GetInvoices()
        {

            string procedureName = "";
            OracleDynamicParameters parameters = new OracleDynamicParameters();
            parameters.Add("PARAM1", 2, OracleMappingType.Int32);

            parameters.Add("tempParameter", dbType: OracleMappingType.RefCursor, direction: System.Data.ParameterDirection.Output);
            return new DbContext<Person>().GetListByProcudure(procedureName, parameters).ToList();
        }
    }
}
