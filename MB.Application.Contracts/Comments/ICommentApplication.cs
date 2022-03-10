
namespace MB.Application.Contracts.Comments
{
    public interface ICommentApplication
    {
        List<CommentViewModel> GetComments();
        void Add(AddComment command);
    }
}
