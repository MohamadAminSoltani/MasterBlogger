using _01_Framework.Domain;
using MB.Domain.ArticleAgg;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory:DomainBase<long>
    {
        public string Title { get; private set; }
        public bool IsDeleted { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ArticleCategory(string title)
        {
            Title = title;
            IsDeleted = false;
            Articles = new List<Article>();
        }

        public void Rename(string title)
        {
            Title = title;
        }
         public void Remove()
        {
            IsDeleted = true;
        }
        public void Activate()
        {
            IsDeleted = false;
        }
    }
}
