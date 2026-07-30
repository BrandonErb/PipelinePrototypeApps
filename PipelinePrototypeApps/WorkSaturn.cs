namespace PipelineAppsSun;

public static class WorkSaturn
{
    public static async Task InvokeAsyncWork()
    {
        string data = "Hello World";
        var rpcClient = new RpcClient();
        await rpcClient.StartAsync();

        Console.WriteLine(" [req] Requesting Saturn service work", data);
        var response = await rpcClient.CallAsync(data);
        Console.WriteLine($" [res] Got {response}");
    }
}