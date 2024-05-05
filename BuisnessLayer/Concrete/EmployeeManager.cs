using BuisnessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        public void TAdd(Emergency t)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Employee t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Emergency t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Employee t)
        {
            throw new NotImplementedException();
        }

        public Emergency TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Emergency> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Emergency t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Employee t)
        {
            throw new NotImplementedException();
        }

        Employee IGenericService<Employee>.TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        List<Employee> IGenericService<Employee>.TGetList()
        {
            throw new NotImplementedException();
        }
    }
}
