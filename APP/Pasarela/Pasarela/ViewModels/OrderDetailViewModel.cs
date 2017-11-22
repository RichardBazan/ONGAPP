using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.Helpers;
using Pasarela.Core.Models.Orders;
using Pasarela.Core.Services.Order;
using Pasarela.Core.ViewModels.Base;

namespace Pasarela.Core.ViewModels
{
    public class OrderDetailViewModel : ViewModelBase
    {
        private IOrderService _ordersService;
        private Order _order;

        public OrderDetailViewModel(IOrderService ordersService)
        {
            _ordersService = ordersService;
        }

        public Order Order
        {
            get { return _order; }
            set
            {
                _order = value;
                RaisePropertyChanged(() => Order);
            }
        }

        public override async Task InitializeAsync(object navigationData)
        {
            if (navigationData is Order)
            {
                IsBusy = true;

                var order = navigationData as Order;

                // Get order detail info
                var authToken = Settings.AuthAccessToken;
                Order = await _ordersService.GetOrderAsync(Convert.ToInt32(order.OrderNumber), authToken);

                IsBusy = false;
            }
        }
    }
}