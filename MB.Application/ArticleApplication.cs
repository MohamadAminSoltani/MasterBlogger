﻿using MB.Application.Contracts.Article;
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
            var article = new Article(command.Title, command.ShortDescription,command.Content, command.Image, command.ArticleCategoryId);
            _articleRepository.CreateAndSave(article);
        }

        public List<ArticleViewModel> GetList()
        {
            return _articleRepository.GetList();
        }
    }
}
