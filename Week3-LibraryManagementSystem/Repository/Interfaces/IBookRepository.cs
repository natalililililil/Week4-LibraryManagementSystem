﻿using Week3_LibraryManagementSystem.Models.Entities;

namespace Week3_LibraryManagementSystem.Repository.Interfaces
{
    public interface IBookRepository : IRepository<Book, int>
    {
        Task<IEnumerable<Book>> GetBooksAfterYearAsync(int year);
    }
}
