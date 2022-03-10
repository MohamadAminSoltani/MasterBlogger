using MB.Application.Contracts.Comments;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        void CreateAndSave(Comment comment);
        List<CommentViewModel> GetList();
        Comment Get(long id);
        void Save();    
    }
}
