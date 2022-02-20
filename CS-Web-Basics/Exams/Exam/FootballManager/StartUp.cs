namespace FootballManager
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using FootballManager.Data;
    using FootballManager.Data.Common;
    using FootballManager.Services;
    using FootballManager.Services.Contracts;
    using System.Threading.Tasks;

    public class Startup
    {
        public static async Task Main()
        {
            var server = new HttpServer(routes => routes
               .MapControllers()
               .MapStaticFiles());

            server.ServiceCollection
                .Add<IUserService, UserService>()
                .Add<FootballManagerDbContext>()
                .Add<IRepository, Repository>()
                .Add<IPlayerService, PlayerService>();


            await server.Start();
        }
    }
}
