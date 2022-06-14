using Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Managers
{
    public class ProductManager
    {
        private UnitOfWork _uow;
        public ProductManager(UnitOfWork uow)
        {
            _uow = uow;
        }

        public List<Logic.Models.Product> GetProducts()
        {
            List<Database.Models.Product> productsFromDB = _uow.ProductRepository.GetAll().Result;
            List<Logic.Models.Product> mappedProducts = new List<Logic.Models.Product>();

            foreach (Database.Models.Product product in productsFromDB)
            {
                mappedProducts.Add(new Logic.Models.Product()
                {
                    Id = product.Id,
                    NameProduct = product.NameProduct,
                    PriceProduct = product.PriceProduct
                }); ;
            }

            return mappedProducts;
        }

        public Logic.Models.Product CreateProduct(Logic.Models.Product product)
        {
            Database.Models.Product productToCreate = new Database.Models.Product()
            {
                Id = new Guid(),
                NameProduct = product.NameProduct,
                PriceProduct = 200
            };
            _uow.ProductRepository.CreateProduct(productToCreate);
            _uow.Save();

            return new Logic.Models.Product()
            {
                Id = productToCreate.Id,
                NameProduct = productToCreate.NameProduct,
                PriceProduct = 200
            };
        }

        public Logic.Models.Product UpdateProduct(Logic.Models.Product product)
        {
            Database.Models.Product productToUpdate = _uow.ProductRepository.GetProductById(product.Id);

            productToUpdate.NameProduct = product.NameProduct;
            productToUpdate.PriceProduct = product.PriceProduct;

            _uow.ProductRepository.UpdateProduct(productToUpdate);
            _uow.Save();

            return new Logic.Models.Product()
            {
                Id = productToUpdate.Id,
                NameProduct = productToUpdate.NameProduct,
                PriceProduct = productToUpdate.PriceProduct
            };
        }

        public Logic.Models.Product DeleteProduct(Guid productId)
        {
            Database.Models.Product productFound = _uow.ProductRepository.GetProductById(productId);
            _uow.ProductRepository.DeleteProduct(productFound);
            _uow.Save();

            return new Logic.Models.Product()
            {
                Id = productFound.Id,
                NameProduct = productFound.NameProduct,
                PriceProduct = productFound.PriceProduct
            };
        }
    }
}
