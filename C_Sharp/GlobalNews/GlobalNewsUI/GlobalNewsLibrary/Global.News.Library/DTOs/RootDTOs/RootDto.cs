using Global.News.Library.DTOs.ArticleDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.News.Library.DTOs.RootDTOs
{
    public class RootDto
    {
        public string Status { get; set; }

        public int TotalResults { get; set; }

        public List<ArticleDto> Articles { get; set; }
    }
}
