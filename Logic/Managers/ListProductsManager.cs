using BackingServices.Services;
using Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Managers
{
    public class ListProductsManager
    {
        private UnitOfWork _uow;
        private CampaignService _campaignService;
        public ListProductsManager(UnitOfWork uow, CampaignService campaignService)
        {
            _uow = uow;
            _campaignService = campaignService;
        }

        public Logic.Models.Campaign GetActiveCampaign()
        {
            BackingServices.Models.Campaign campaignFromService = _campaignService.GetCampaignServiceAsync().Result;

            return new Logic.Models.Campaign()
            {
                Id = campaignFromService.Id,
                NameCampaign = campaignFromService.NameCampaign,
                TypeCampaign = campaignFromService.TypeCampaign,
                CustomerSponsor = campaignFromService.CustomerSponsor,
                Enable = campaignFromService.Enable
            };
        }

        public List<Logic.Models.ListProducts> GetListProducts()
        {
            List<Database.Models.ListProducts> listProductsFromDB = _uow.ListProductRepository.GetAllList().Result;
            List<Logic.Models.ListProducts> mappedListProducts = new List<Logic.Models.ListProducts>();

            foreach (Database.Models.ListProducts listProduct in listProductsFromDB)
            {
                mappedListProducts.Add(new Logic.Models.ListProducts()
                {
                    Id = listProduct.Id,
                    NameList = listProduct.NameList,
                    Description = listProduct.Description,
                    TypeCampaing = listProduct.TypeCampaing, 
                });
            }
            return mappedListProducts;
        }

        public Logic.Models.ListProducts CreateList(Logic.Models.ListProducts listProduct)
        {
            Database.Models.ListProducts listProductToCreate = new Database.Models.ListProducts()
            {
                Id = new Guid(),
                NameList = listProduct.NameList,
                Description = listProduct.Description,
                TypeCampaing = listProduct.TypeCampaing
            };
            _uow.ListProductRepository.CreateList(listProductToCreate);
            _uow.Save();

            return new Logic.Models.ListProducts()
            {
                Id = listProductToCreate.Id,
                NameList = listProductToCreate.NameList,
                Description = listProductToCreate.Description,
                TypeCampaing = listProductToCreate.TypeCampaing
            };
        }

        public Logic.Models.ListProducts UpdateListProduct(Logic.Models.ListProducts listProduct)
        {
            Database.Models.ListProducts listProductToUpdate = _uow.ListProductRepository.GetListById(listProduct.Id);

            listProductToUpdate.NameList = listProduct.NameList;
            listProductToUpdate.Description = listProduct.Description;
            listProductToUpdate.TypeCampaing = listProduct.TypeCampaing;

            _uow.ListProductRepository.UpdateList(listProductToUpdate);
            _uow.Save();

            return new Logic.Models.ListProducts()
            {
                Id = listProductToUpdate.Id,
                NameList = listProductToUpdate.NameList,
                Description = listProductToUpdate.Description,
                TypeCampaing = listProductToUpdate.TypeCampaing
            };
        }

        public Logic.Models.ListProducts DeleteList(Guid productId)
        {
            Database.Models.ListProducts listProductFound = _uow.ListProductRepository.GetListById(productId);
            _uow.ListProductRepository.DeleteList(listProductFound);
            _uow.Save();

            return new Logic.Models.ListProducts()
            {
                Id = listProductFound.Id,
                NameList = listProductFound.NameList,
                Description = listProductFound.Description,
                TypeCampaing = listProductFound.TypeCampaing
            };
        }
    }
}
