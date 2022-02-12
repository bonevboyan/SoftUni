namespace SharedTrip
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using SharedTrip.Services;
    using SharedTrip.Services.Contracts;
    using System.Threading.Tasks;

    public class Startup
    {
        public static async Task Main()
        {
            var server = new HttpServer(routes => routes
               .MapControllers()
               .MapStaticFiles());

            server.ServiceCollection
                .Add<IDbHandler, DbHandler>()
                .Add<IValidator, Validator>()
                .Add<IPasswordHasher, PasswordHasher>();

            await server.Start();
        }
    }
}
