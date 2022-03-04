using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void Create(CreateArticle command)
        {
            var article = new Article(command.Title, command.ShortDescription,command.Image, command.Content, command.ArticleCategoryId);
            _articleRepository.CreateAndSave(article);
        }

        public void Edit(EditArticle command)
        {
            var article = _articleRepository.Get(command.Id);
            article.Edit(command.Title,command.ShortDescription,command.Image,command.Content,command.ArticleCategoryId);
            _articleRepository.Save();
        }

        public EditArticle Get(long id)
        {
            var article = _articleRepository.Get(id);
            return new EditArticle()
            {
                Id = id,
                Title = article.Title,
                Image = article.Image,
                Content = article.Content,
                ShortDescription = article.ShortDescription,
                ArticleCategoryId = article.ArticleCategoryId
            };
        }

        public List<ArticleViewModel> GetList()
        {
            return _articleRepository.GetList();
        }
    }
}
