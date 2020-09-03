using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace musicalog_api.Model
{
    public class BaseResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public object Result { get; set; }
    }
}
