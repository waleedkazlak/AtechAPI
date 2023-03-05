using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtechAPI.Models
{
    public class MethodResult<T> 
    {
        public bool IsSuccess = false;
        public List<string> Errors = new List<string>();
        public string Message { get; set; }

        public bool IsNotAuthorized { get; set; }

        public int InsertedId { get; set; }

        
        public T Data { get; set; }
    }
}
