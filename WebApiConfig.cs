namespace BantrAPI
{


    public static class WebApiConfig
    {


        public static void Register(HttpConfiguration config)
        {
            // Other configuration omitted
            config.EnableCors(new EnableCorsAttribute("http://localhost:3000", "*", "*"));
        }

    }
}