namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }

        public ArticleCategory(string title)
        {
            Title = title;
            IsDeleted = false;
            CreationDate = DateTime.Now;
        }

        public void Rename(string title)
        {
            Title = title;
        }
    }
}
