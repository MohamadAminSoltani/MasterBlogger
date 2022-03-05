using MB.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MB.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly MasterBloggerContext _context;

        public ArticleQuery(MasterBloggerContext context)
        {
            _context = context;
        }

        public ArticleQueryView GetArticle(long id)
        {
            return _context.Articles
                .Include(x => x.ArticleCategory)
                .Select(x =>
                    new ArticleQueryView
                    {
                        Id = x.Id,
                        Title = x.Title,
                        ArticleCategory = x.ArticleCategory.Title,
                        CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                        ShortDescription = x.ShortDescription,
                        Image = x.Image,
                        IsDeleted = x.IsDeleted,
                        Content = x.Content,
                    }).FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleQueryView> GetArticles()
        {
            return _context.Articles
                .Include(x => x.ArticleCategory)
                .Select(x =>
                    new ArticleQueryView
                    {
                        Id = x.Id,
                        Title = x.Title,
                        ArticleCategory = x.ArticleCategory.Title,
                        CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                        ShortDescription = x.ShortDescription,
                        Image = x.Image,
                        IsDeleted = x.IsDeleted,
                    }).ToList();
        }
    }
}
