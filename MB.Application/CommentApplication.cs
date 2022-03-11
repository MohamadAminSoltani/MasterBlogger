using _01_Framework.Infrastructure;
using MB.Application.Contracts.Comments;
using MB.Domain.CommentAgg;

namespace MB.Application
{
    public class CommentApplication: ICommentApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommentRepository _commentRepository;
        public CommentApplication(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
            _commentRepository = commentRepository;
        }

        public void Add(AddComment command)
        {
            _unitOfWork.BeginTran();
            var comment = new Comment(command.Name,command.Email,command.Message,command.ArticleId);
            _commentRepository.Create(comment);
            _unitOfWork.CommitTran();
        }

        public void Cancel(long id)
        {
            _unitOfWork.BeginTran();
            var comment = _commentRepository.Get(id);
            comment.Cancel();
            _unitOfWork.CommitTran();
        }

        public void Confirm(long id)
        {
            _unitOfWork.BeginTran();
            var comment = _commentRepository.Get(id);
            comment.Confirm();
            _unitOfWork.CommitTran();
        }

        public List<CommentViewModel> GetComments()
        {
            return _commentRepository.GetList();
        }
    }
}
