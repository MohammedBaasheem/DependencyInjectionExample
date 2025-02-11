using DependencyInjection.Services.Interfaces;

namespace DependencyInjection.Services.Implementiones
{
    public class Operation : IScoped, ITransient, ISingleton
    {
        public string OperationID { get; }
        public Operation()
        {
            OperationID = Guid.NewGuid().ToString()[^6..];
        }

       
    }
}
