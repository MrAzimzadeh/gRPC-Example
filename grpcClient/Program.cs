using Grpc.Net.Client;
using grpcServer;

Console.WriteLine("Clienr");


var chanel = GrpcChannel.ForAddress("https://localhost:7245");
var greetClient = new Greeter.GreeterClient(channel: chanel);

HelloReply result = await greetClient.SayHelloAsync(new HelloRequest
{
    Name = "Salam Dostlarrr "
});
Console.WriteLine(result.Message);