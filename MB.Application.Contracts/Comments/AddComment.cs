﻿
namespace MB.Application.Contracts.Comments
{
    public class AddComment
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public long ArticleId { get; set; }
    }
}
