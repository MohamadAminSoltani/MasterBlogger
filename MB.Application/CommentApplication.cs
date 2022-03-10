using MB.Application.Contracts.Comments;

namespace MB.Application
{
    public class CommentApplication: ICommentApplication
    {
        private readonly ICommentApplication _commentApplication;
        public CommentApplication(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }
    }
}
