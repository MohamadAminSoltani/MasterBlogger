﻿using MB.Application.Contracts.Comments;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class CommentRepository: ICommentRepository
    {
        private readonly MasterBloggerContext _context;
        public CommentRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public void CreateAndSave(Comment comment)
        {
            _context.Comments.Add(comment);
            Save();
        }

        public Comment Get(long id)
        {
            return _context.Comments.FirstOrDefault(x=> x.Id == id);
        }

        public List<CommentViewModel> GetList()
        {
            return _context.Comments.Include(x=>x.Article).Select(x=>new CommentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Message = x.Message,
                Status = x.Status,
                Article = x.Article.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
            }).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}