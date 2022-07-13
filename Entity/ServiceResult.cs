using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class ServiceResult<T> where T : class
    {
        //generic sonuc yapisi
        public ServiceResult(bool isSuccess, string message = "", List<T> datas = null)
        {
            IsSuccess = isSuccess;
            Message = message;
            Datas = datas;
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<T> Datas { get; set; }
    }
}
