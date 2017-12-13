using Autofac;
using Pasarela.Services;
using System;
using System.Globalization;
using System.Reflection;
using Pasarela.Core.Services.Catalog;
using Pasarela.Core.Services.OpenUrl;
using Pasarela.Core.Services.RequestProvider;
using Pasarela.Core.Services.Basket;
using Pasarela.Core.Services.Identity;
using Pasarela.Core.Services.Order;
using Pasarela.Core.Services.User;
using Xamarin.Forms;
using Pasarela.Core.Services.Home;
using Pasarela.Core.Services.Dog;
using Pasarela.Core.Services.ShelterHouse;
using Pasarela.Core.Services.Complaints;
using Pasarela.Core.Services.Comment;
using Pasarela.Core.Services.Donate;
using Pasarela.Core.Services.Product;
using Pasarela.Core.Services.Breed;
using Pasarela.Core.Services.GiveInAdoption;

namespace Pasarela.Core.ViewModels.Base
{
    public static class ViewModelLocator
    {
        private static IContainer _container;

        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(ViewModelLocator.AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
        }

        public static bool UseMockService { get; set; }

        public static void RegisterDependencies(bool useMockServices)
        {
            var builder = new ContainerBuilder();

            // View models
            builder.RegisterType<BasketViewModel>();
            builder.RegisterType<CatalogViewModel>();
            builder.RegisterType<CheckoutViewModel>();
            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<OrderDetailViewModel>();
            builder.RegisterType<ProfileViewModel>();
            builder.RegisterType<SettingsViewModel>();

            //ViewModelsONG
            builder.RegisterType<HomeViewModel>();
            builder.RegisterType<AdoptionDetailViewModel>();
            builder.RegisterType<MainAdoptionViewModel>();
            builder.RegisterType<AllAdoptionsViewModel>();
            builder.RegisterType<MainAbuseViewModel>();
            builder.RegisterType<MyComplaintsViewModel>();
            builder.RegisterType<RegisterComplaintViewModel>();
            builder.RegisterType<AllComplaintsViewModel>();
            builder.RegisterType<MainShelterHouseViewModel>();
            builder.RegisterType<MyShelterHouseViewModel>();
            builder.RegisterType<RegisterShelterHouseViewModel>();
            builder.RegisterType<AllShelterHouseViewModel>();
            builder.RegisterType<GiveInAdoptionViewModel>();
            builder.RegisterType<ShelterHouseDetailViewModel>();
            builder.RegisterType<ComplaintDetailViewModel>();
            builder.RegisterType<ComentComplaintsViewModel>();
            builder.RegisterType<DonateViewModel>();
            builder.RegisterType<AdoptOngViewModel>();
            builder.RegisterType<AdoptUserViewModel>();
            

            // Services
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<DialogService>().As<IDialogService>();
            builder.RegisterType<OpenUrlService>().As<IOpenUrlService>();
            builder.RegisterType<IdentityService>().As<IIdentityService>();
            builder.RegisterType<RequestProvider>().As<IRequestProvider>();



            if (useMockServices)
            {
                builder.RegisterInstance(new CatalogMockService()).As<ICatalogService>();
                builder.RegisterInstance(new BasketMockService()).As<IBasketService>();
                builder.RegisterInstance(new OrderMockService()).As<IOrderService>();
                builder.RegisterInstance(new UserMockService()).As<IUserService>();

                //MockServicesONG
                builder.RegisterType<HomeMockService>().As<IHomeService>();
                //builder.RegisterType<DogMockService>().As<IDogService>();
                //builder.RegisterType<ShelterHouseMockService>().As<IShelterHouseService>();
                //builder.RegisterType<ComplaintsMockService>().As<IComplaintsService>();
                //builder.RegisterType<CommentMockService>().As<ICommentService>();


                //RealService ONG

                builder.RegisterType<ComplaintsService>().As<IComplaintsService>().SingleInstance();
                builder.RegisterType<CommentService>().As<ICommentService>().SingleInstance();
                builder.RegisterType<DogService>().As<IDogService>();
                builder.RegisterType<ShelterHouseService>().As<IShelterHouseService>();
                builder.RegisterType<DonateService>().As<IDonateService>();
                builder.RegisterType<ProductService>().As<IProductService>();
                builder.RegisterType<BreedService>().As <IBreedService>();
                builder.RegisterType<GiveInAdoptionService>().As<IGiveInAdoptionService>();

                UseMockService = true;
			}
			else
			{
				builder.RegisterType<CatalogService>().As<ICatalogService>().SingleInstance();
				builder.RegisterType<BasketService>().As<IBasketService>().SingleInstance();
				builder.RegisterType<OrderService>().As<IOrderService>().SingleInstance();
				builder.RegisterType<UserService>().As<IUserService>().SingleInstance();

				UseMockService = false;
			}

			if (_container != null)
			{
				_container.Dispose();
			}
			_container = builder.Build();
		}

		public static T Resolve<T>()
		{
			return _container.Resolve<T>();
		}

		private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var view = bindable as Element;
			if (view == null)
			{
				return;
			}

			var viewType = view.GetType();
			var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
			var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
			var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

			var viewModelType = Type.GetType(viewModelName);
			if (viewModelType == null)
			{
				return;
			}
			var viewModel = _container.Resolve(viewModelType);
			view.BindingContext = viewModel;
		}
	}
}