using Global.News.UI.DTOs.ArticleDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.News.UI.DTOs.RootDTOs
{
    internal class RootDto
    {
        public string Status { get; set; }

        public int TotalResults { get; set; }

        public List<ArticleDto> Articles { get; set; }
    }
}
