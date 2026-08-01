
namespace PipelineAppSun
{
    public static class WorkSaturn
    {
        public static async Task<string> InvokeAsyncWork(string data)
        {
            var rpcClient = new RpcClient();
            await rpcClient.StartAsync();

            Console.WriteLine(" [req] Requesting Saturn service work: {0}", data);
            var response = await rpcClient.CallAsync(data);
            Console.WriteLine($" [res] Got {response}");
            return response;
        }
    }
}