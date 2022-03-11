using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using System.Globalization;
using System.Linq;

namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public void Create(CreateArticleCategory command)
        {
            var articleCategory = new ArticleCategory(command.Title);
            _articleCategoryRepository.Create(articleCategory);
        }



        public List<ArticleCategoryViewModel> List()
        {
            var articleCategories = _articleCategoryRepository.GetAll();
            return articleCategories.Select(articleCategory => new ArticleCategoryViewModel()
            {
                Title = articleCategory.Title,
                Id = articleCategory.Id,
                IsDeleted = articleCategory.IsDeleted,
                CreationDate = articleCategory.CreationDate.ToString(CultureInfo.InvariantCulture)
            }).OrderByDescending(x => x.Id).ToList();
        }

        public void Rename(RenameArticleCategory command)
        {
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            articleCategory.Rename(command.Title);
            //_articleCategoryRepository.Save();
        }

        public RenameArticleCategory Get(long id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            return new RenameArticleCategory
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title,
            };
        }

        public void Remove(long id)
        {
            var articeCategory = _articleCategoryRepository.Get(id);
            articeCategory.Remove();
            //_articleCategoryRepository.Save();
        }

        public void Activate(long id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Activate();
            //_articleCategoryRepository.Save();
        }
    }
}
