using MB.Domain.CommentAgg;
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
                        CommentsCount = x.Comments.Count(z => z.Status == Statuses.Confirmed),
                        Comments = MapComments(x.Comments.Where(z => z.Status == Statuses.Confirmed))
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
                        CommentsCount = x.Comments.Count(z => z.Status == Statuses.Confirmed)
                    }).ToList();
        }

        private static List<CommentQueryView> MapComments(IEnumerable<Comment> comments)
        {
            return comments.Select(comment => new CommentQueryView
            {
                Name = comment.Name,
                CreationDate = comment.CreationDate.ToString(CultureInfo.InvariantCulture),
                Message = comment.Message
            }).ToList();
        }
    }
}
