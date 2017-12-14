using System;

namespace Pasarela.Core
{
    public class GlobalSetting
    {
        public const string AzureTag = "Azure";
        public const string MockTag = "Mock";
        public const string DefaultEndpoint = "http://192.168.43.254/WebApiONG/api";


        private string _baseEndpoint;
        private static readonly GlobalSetting _instance = new GlobalSetting();

        public GlobalSetting()
        {
            AuthToken = "INSERT AUTHENTICATION TOKEN";
            BaseEndpoint = DefaultEndpoint;
        }

        public static GlobalSetting Instance
        {
            get { return _instance; }
        }

        public string BaseEndpoint
        {
            get { return _baseEndpoint; }
            set
            {
                _baseEndpoint = value;
                UpdateEndpoint(_baseEndpoint);
            }
        }

        public string AuthToken { get; set; }

        public string RegisterWebsite { get; set; }

        public string CatalogEndpoint { get; set; }

        public string OrdersEndpoint { get; set; }

        public string BasketEndpoint { get; set; }

        public string IdentityEndpoint { get; set; }

        public string UserInfoEndpoint { get; set; }

        public string LogoutEndpoint { get; set; }

        public string IdentityCallback { get; set; }

        public string LogoutCallback { get; set; }


        //EndPoint ONG

        public string DenunciaEndpoint { get; set; }
        public string FotoMaltratoEndPoint { get; set; }
        public string ComentarioEndPoint { get; set; }
        public string MascotaEndPoint { get; set; }
        public string CasaRefugioEndPoint { get; set; }
        public string DonacionEndPoint { get; set; }
        public string ProductoEndPoint { get; set; }
        public string RazaEndPoint { get; set; }
        public string DarEnAdopcionEndPoint { get; set; }
        public string DonacionProductoEndPoint { get; set; }
        public string AdopcionEndPoint { get; set; }


        private void UpdateEndpoint(string baseEndpoint)
        {
            RegisterWebsite = string.Format("{0}:5105/Account/Register", baseEndpoint);
            CatalogEndpoint = string.Format("{0}:5101", baseEndpoint);
            OrdersEndpoint = string.Format("{0}:5102", baseEndpoint);
            BasketEndpoint = string.Format("{0}:5103", baseEndpoint);
            IdentityEndpoint = string.Format("{0}:5105/connect/authorize", baseEndpoint);
            UserInfoEndpoint = string.Format("{0}:5105/connect/userinfo", baseEndpoint);
            LogoutEndpoint = string.Format("{0}:5105/connect/endsession", baseEndpoint);
            IdentityCallback = string.Format("{0}:5105/xamarincallback", baseEndpoint);
            LogoutCallback = string.Format("{0}:5105/Account/Redirecting", baseEndpoint);


            DenunciaEndpoint = string.Format("{0}/Denuncias", baseEndpoint);
            FotoMaltratoEndPoint = string.Format("{0}/Foto_Maltrato", baseEndpoint);
            ComentarioEndPoint = string.Format("{0}/Comentarios", baseEndpoint);
            MascotaEndPoint = string.Format("{0}/Mascotas", baseEndpoint);
            CasaRefugioEndPoint = string.Format("{0}/CasaRefugios", baseEndpoint);
            DonacionEndPoint = string.Format("{0}/Donaciones", baseEndpoint);
            ProductoEndPoint = string.Format("{0}/Productos", baseEndpoint);
            RazaEndPoint = string.Format("{0}/Razas", baseEndpoint);
            DarEnAdopcionEndPoint = string.Format("{0}/DarAdopcions", baseEndpoint);
            DonacionProductoEndPoint = string.Format("{0}/DonacionProductoes", baseEndpoint);
            AdopcionEndPoint = string.Format("{0}/Adopcions", baseEndpoint);
        }

        public string MakeURI(string EndPoint, string Path, string Query = "")
        {
            UriBuilder builder = new UriBuilder(EndPoint);
            builder.Path += Path;
            if (Query.Trim().Length > 0)
            {
                builder.Query = Query;
            }
            return builder.Uri.ToString();
        }

    }
}