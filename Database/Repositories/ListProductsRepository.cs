using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class ListProductsRepository
    {
        private PracticeDbContext _context;

        public ListProductsRepository(PracticeDbContext context)
        {
            _context = context;
        }

        public async Task<List<ListProducts>> GetAllList()
        {
            return await _context.Set<ListProducts>().ToListAsync();
        }

        public ListProducts CreateList(ListProducts list)
        {
            _context.Set<ListProducts>().Add(list);
            return list;
        }

        public ListProducts GetListById(Guid id)
        {
            return _context.Set<ListProducts>().Find(id);
        }

        public ListProducts UpdateList(ListProducts list)
        {
            _context.Entry(list).State = EntityState.Modified;
            return list;
        }

        public ListProducts DeleteList(ListProducts list)
        {
            _context.Set<ListProducts>().Remove(list);
            return list;
        }
    }
}
