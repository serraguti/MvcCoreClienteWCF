using ReferenceCoches;

namespace MvcCoreClienteWCF.Services
{
    public class ServiceCoches
    {
        private CochesContractClient client;

        public ServiceCoches(CochesContractClient client)
        {
            this.client = client;
        }

        public async Task<Coche[]> GetCochesAsync()
        {
            Coche[] cars = 
                await this.client.GetCochesAsync();
            return cars;
        }

        public async Task<Coche> FindCocheAsync(int idcoche)
        {
            Coche car =
                await this.client.FindCocheAsync(idcoche);
            return car;
        }
    }
}
