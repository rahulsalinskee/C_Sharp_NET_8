using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.News.Library.DTOs.ResponseDTOs
{
    public class ResponseDto
    {
        public object? Result { get; set; }

        public bool IsSuccess { get; set; } = default;

        public string Message { get; set; } = string.Empty;
    }
}
