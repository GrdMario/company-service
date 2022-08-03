namespace Company.Service
{
    using Company.Service.Blocks.Bootstrap;

    public static class Program
    {
        public static async Task Main(string[] args) => await ApplicationLauncher.RunAsync<Startup>(args);
    }
}
