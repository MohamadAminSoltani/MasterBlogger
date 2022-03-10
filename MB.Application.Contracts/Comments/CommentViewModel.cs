
namespace MB.Application.Contracts.Comments
{
    public class CommentViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public string CreationDate { get; set; }
        public string Article { get; set; }
    }
}
