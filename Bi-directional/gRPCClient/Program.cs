using Grpc.Net.Client;
using gRPCMessageServer;

Console.WriteLine("Client");

var chanel = GrpcChannel.ForAddress("http://localhost:5048");
var messagqeClient = new Message.MessageClient(chanel);

CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

var request = messagqeClient.SendMessage();
var task1 = Task.Run(async () =>
{
    for (int i = 0; i < 10; i++)
    {
        await Task.Delay(1000);
        request.RequestStream.WriteAsync(new MessageRequest { Message = "Hi " + i, Name = "Gonchaaaa" });
    }
});
while (await request.ResponseStream.MoveNext(cancellationTokenSource.Token))
{
    System.Console.WriteLine(request.ResponseStream.Current.Message);
}

await task1;
request.RequestStream.CompleteAsync();
