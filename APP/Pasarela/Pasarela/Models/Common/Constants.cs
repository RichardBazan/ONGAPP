using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasarela.Core.Models.Common
{
    public class Constants
    {
        public static string ApplicationURL = @"http://goby-notification.azurewebsites.net";
        public struct Enviroments
        {
            public const string DEV = "DEV";
            public const string QA = "QA";
            public const string PROD = "PROD";
        }
        public struct MultimediaType
        {
            public const int Photo = 1;
            public const int Video = 2;
            public const int File = 3;
        }

        public struct SaleMode
        {
            public const int Services = 3;
            public const int Retail = 1;
            public const int Online = 2;
            public const int Coupon = 4;
        }

        public struct SaleModeName
        {
            public const string Services = "Servicios Recurrentes";
            public const string Retail = "Compras en Tienda";
            public const string Online = "Compras en Línea";
            public const string Coupon = "Compras Cupones";
        }

        public struct SaleSavingsModeName
        {
            public const string Services = "Ahorro Servicios";
            public const string Retail = "Ahorro Compra en Tienda";
            public const string Online = "Ahorro Compra en Línea";
            public const string Coupon = "Compras Cupones";
        }

        public struct DynamicDataType
        {
            public const string Number = "Number";
            public const string Email = "Email";
            public const string Varchar = "Varchar";
            public const string Telephone = "Telephone";
            public const string Password = "Password";
        }

        public struct ContainerTypes
        {
            public const string ADVERTISEMENTS = "advertisements";
            public const string BANNER = "banners";
            public const string COMPANY_LOGO = "company-logo";
            public const string ICONS = "icons";
            public const string OFFERS = "offers";
            public const string PICTURES = "pictures";
            public const string BACKGROUND = "backgrounds";
            public const string COUPON = "coupon-images";
        }

        public struct MethodsService
        {
            /* Photo by complaints*/
            public const string METHOD_PHOTO_COMPLAINTS = "/GetPhotoByMaltrato";

            /* Comment by complaints*/
            public const string METHOD_COMMENT_COMPLAINTS = "/GetCommentByComplaint";

            /*All Complaints*/
            public const string METHOD_ALL_COMPLAINTS = "/GetAllComplaints";

            /*Complaints by user*/
            public const string METHOD_COMPLAINTS_USER = "/GetComplaintByUser";

            /*Dogs adopt ONG*/
            public const string METHOD_DOGS_ADOPT_ONG = "/GetDogsAdoptONG";

            /*Dogs adopt User*/
            public const string METHOD_DOGS_ADOPT_USER = "/GetDogsAdoptUser";

            /*Dogs adoptions*/
            public const string METHOD_DOGS_ADOPTIONS = "/GetDogsAdoptions"; 

            /*All ShelterHouse*/
            public const string METHOD_ALL_SHELTERHOUSE = "/GetAllShelterHouse";

            /*ShelterHouse by user*/
            public const string METHOD_SHELTERHOUSE_USER = "/GetShelterHouseByUser";

            /*Donate by shelter house*/
            public const string METHOD_DONATE_SHELTERHOUSE = "/GetDonateByShelterHouse";

            /*All Products*/
            public const string METHOD_ALL_PRODUCTS = "/GetAllProducts";

            /*Save Shelter House*/
            public const string METHOD_SAVE_SHELTERHOUSE = "/SaveShelterHouse";

            /*All Breed*/
            public const string METHOD_ALL_BREED = "/GetAllBreed";

            /*Save Complaints*/
            public const string METHOD_SAVE_COMPLAINTS = "/SaveComplaints";
        }

        public struct ParameterService
        {
            public const string PARAM_EMPLOYER = "Employer/";
        }

        public struct SubscriptionState
        {
            public const int Pendiente = 1;
            public const int Activo = 2;
            public const int Inactivo = 3;
            public const int Rechazado = 4;
            public const int Cancelado = 5;
        }

        public struct EmptyListMessages
        {
            public const string Offers = "Aquí se mostrarán las ofertas disponibles para ti.";
            public const string Services = "Aquí se mostrarán los proveedores de servicios disponibles para ti.";
            public const string FavoritesOnline = "Aquí se mostrarán tu proveedores favoritos.";
            public const string FavoritesRetail = "Aquí se mostrarán tu proveedores favoritos.";
            public const string CouponsAll = "Aquí se mostrarán todos los cupones disponibles para ti.";
            public const string SupplierOnline = "Aquí se mostrarán los proveedores online disponibles para ti.";
            public const string ConsumesOnline = "Aquí se mostrarán tus compras realizadas en línea.";
            public const string ConsumesRetail = "Aquí se mostrarán tus compras realizadas en tienda.";
            public const string ConsumesServices = "Aquí se mostrarán tus consumos en suscripciones.";
            public const string SupplierRetail = "Aquí se mostrarán los proveedores disponibles para ti.";
            public const string MyCoupons = "Aquí se mostrarán tus cupones.";
            public const string MyUsedCoupons = "Aquí se mostrarán tus cupones usados.";
            public const string MySuscriptionsService = "Aquí se mostrarán los proveedores suscritos.";
            public const string AllCoupons = "Aquí se mostrarán los proveedores con cupones disponibles para ti.";
            public const string ReportEmpty = "No tienes consumos para en este periodo.";
        }

        public struct EmptyListColors
        {
            public const string Offers = "#464646";
            public const string ConsumesOnline = "#464646";
            public const string ConsumesRetail = "#464646";
            public const string ConsumesServices = "#464646";
            public const string FavoritesOnline = "#464646";
            public const string Services = "#464646";
            public const string FavoritesRetail = "#464646";
            public const string CouponsAll = "#464646";
            public const string SupplierOnline = "#464646";
            public const string SupplierRetail = "#464646";
            public const string MyCoupons = "#464646";
            public const string MyUsedCoupons = "#464646";
            public const string MySuscriptionsService = "#464646";
            public const string AllCoupons = "#464646";
            public const string ReportEmpty = "#3A7287";
        }
        public struct ServiceCategoryType
        {
            public const int ServiciosRecurrentes = 1;
            public const int ServiciosMontoFijo = 2;
            public const int ServiciosPagoUnico = 3;
            public const int Cupones = 4;
        }

        public struct OfferType
        {
            public const int Retail = 1;
            public const int Online = 2;
        }

        public struct MessageTitle
        {
            public const string Message = "Mensaje";
            public const string Alert = "Alerta";
            public const string Error = "Error";
        }

        public struct MessageButton
        {
            public const string OK = "Ok";
        }


        public struct ViewModelsNotification
        {
            public const string MainMyAccountViewModel = "MainMyAccountViewModel";
            public const string MainServicesViewModel = "MainServicesViewModel";
            public const string MainRetailViewModel = "MainRetailViewModel";
            public const string MainOnlineViewModel = "MainOnlineViewModel";
            public const string MyCouponsViewModel = "MyCouponsViewModel";
            public const string MyGobiesViewModel = "MyGobiesViewModel";
            public const string MainNotificationsViewModel = "MainNotificationsViewModel";
            public const string ConfigurationDataViewModel = "ConfigurationDataViewModel";
        }

        public enum NotificationsId
        {
            CicloSalarialUnDiaAntes = 19,
            CicloSalarialMismoDia = 20,
            FacturacionServicios = 21,
            FacturacionRetail = 22,
            FacturacionOnline = 23,
            FacturacionCupon = 24,
            OtorgadoPuntosGOBY = 25,
            AcumuladoPuntosGOBY = 26,
            SuscripcionAprobada = 27,
            SuscripcionRechazada = 28,
            SuscripcionCancelada = 29,
            NuevosProveedores = 30,
            IncrementadoSaldoGOBY = 31
        }
        public enum PermissionType
        {
            Goby = 1,
            Provider = 2,
            Employer = 3,
            Company = 4
        }
    }
}
