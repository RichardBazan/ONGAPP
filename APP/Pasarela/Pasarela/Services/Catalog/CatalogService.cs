﻿using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Pasarela.Core.Models.Catalog;
using Pasarela.Core.Services.RequestProvider;
using Pasarela.Core.Extensions;
using System.Collections.Generic;
using Pasarela.Core.Helpers;

namespace Pasarela.Core.Services.Catalog
{
    public class CatalogService : ICatalogService
    {
        private readonly IRequestProvider _requestProvider;

        public CatalogService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<ObservableCollection<CatalogItem>> FilterAsync(int catalogBrandId, int catalogTypeId)
        {
            UriBuilder builder = new UriBuilder(GlobalSetting.Instance.CatalogEndpoint);

            builder.Path = string.Format("api/v1/catalog/items/type/{0}/brand/{1}", catalogTypeId, catalogBrandId);

            string uri = builder.ToString();

            CatalogRoot catalog =
                    await _requestProvider.GetAsync<CatalogRoot>(uri);

            if (catalog?.Data != null)
                return catalog?.Data.ToObservableCollection();
            else
                return new ObservableCollection<CatalogItem>();
        }

        public async Task<ObservableCollection<CatalogItem>> GetCatalogAsync()
        {
            UriBuilder builder = new UriBuilder(GlobalSetting.Instance.CatalogEndpoint);

            builder.Path = "api/v1/catalog/items";

            string uri = builder.ToString();

            CatalogRoot catalog =
                await _requestProvider.GetAsync<CatalogRoot>(uri);

            if (catalog?.Data != null)
            {
                ServicesHelper.FixCatalogItemPictureUri(catalog?.Data);

                return catalog?.Data.ToObservableCollection();
            }
            else
                return new ObservableCollection<CatalogItem>();            
        }

        public async Task<ObservableCollection<CatalogBrand>> GetCatalogBrandAsync()
        {
            UriBuilder builder = new UriBuilder(GlobalSetting.Instance.CatalogEndpoint);

            builder.Path = "api/v1/catalog/catalogbrands";

            string uri = builder.ToString();

            IEnumerable<CatalogBrand> brands =
                   await _requestProvider.GetAsync<IEnumerable<CatalogBrand>>(uri);

            if (brands != null)
                return brands?.ToObservableCollection();
            else
                return new ObservableCollection<CatalogBrand>();
        }

        public async Task<ObservableCollection<CatalogType>> GetCatalogTypeAsync()
        {
            UriBuilder builder = new UriBuilder(GlobalSetting.Instance.CatalogEndpoint);

            builder.Path = "api/v1/catalog/catalogtypes";

            string uri = builder.ToString();

            IEnumerable<CatalogType> types =
                    await _requestProvider.GetAsync<IEnumerable<CatalogType>>(uri);

            if (types != null)
                return types.ToObservableCollection();
            else
                return new ObservableCollection<CatalogType>();            
        }
    }
}
