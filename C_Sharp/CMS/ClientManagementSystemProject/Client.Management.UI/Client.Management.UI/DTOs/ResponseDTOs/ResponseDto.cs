using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Management.UI.DTOs.ResponseDTOs
{
    public class ResponseDto
    {
        public object? Result { get; set; }

        public string Message { get; set; } = string.Empty;

        public bool IsSuccess { get; set; }
    }
}
