namespace WebAPI.Services
{
    public class HelloWorldServices : IHelloWorldService
    {
        public string GetHelloWorld()
        {
            return "Hello World!";
        }
    }

    public interface IHelloWorldService
    {
        string GetHelloWorld();
    }
}
