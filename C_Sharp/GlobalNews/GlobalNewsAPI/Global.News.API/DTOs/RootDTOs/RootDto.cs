using Global.News.API.DTOs.ArticleDTOs;

namespace Global.News.API.DTOs.RootDTOs
{
    public class RootDto
    {
        public string Status { get; set; }

        public int TotalResults { get; set; }

        public List<ArticleDto> Articles { get; set; }
    }
}
