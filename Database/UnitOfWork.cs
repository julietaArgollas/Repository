using System;
using Database.Repositories;

namespace Database
{
    public class UnitOfWork
    {
        private PracticeDbContext _context;

        private ProductRepository _productRepository;

        private ListProductsRepository _listProductsRepository;

        public ProductRepository ProductRepository
        {
            get
            {
                return _productRepository;
            }
        }

        public ListProductsRepository ListProductRepository
        {
            get
            {
                return _listProductsRepository;
            }
        }

        public UnitOfWork(PracticeDbContext context)
        {
            _context = context;
            _productRepository = new ProductRepository(_context);
            _listProductsRepository = new ListProductsRepository(_context);
        }
        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public void RollBackTransaction()
        {
            _context.Database.RollbackTransaction();
        }

        public void Save()
        {
            try
            {
                BeginTransaction();
                _context.SaveChanges();
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                throw;
            }
        }
    }
}
