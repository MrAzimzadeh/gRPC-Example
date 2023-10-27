using System.Drawing;
using Grpc.Net.Client;
using grpcMessageServer;
using grpcServer;
using messageServerStreaming;

Console.WriteLine("Clienr");


var chanel = GrpcChannel.ForAddress("http://localhost:5256");
var greetClient = new Greeter.GreeterClient(channel: chanel);

HelloReply result = await greetClient.SayHelloAsync(new HelloRequest
{
    Name = "Salam Dostlarrr "
});
Console.WriteLine(result.Message);

Console.WriteLine("Unary =>  ");

var messagqeClient = new Message.MessageClient(chanel);
var messageResult = await messagqeClient.SendMessageAsync(new grpcMessageServer.MessageRequest
{
    Name = " Mahammad  ",
    Message = "dcfvgbhnjmkjhghbnjnhbvgbhnm "
});

Console.WriteLine(messageResult.Message);

Console.WriteLine("Server Streameing  =>  ");
var streamMessageClient = new MessageServerStreaming.MessageServerStreamingClient(chanel);
var streameingServerMressageResult = streamMessageClient.SendMessage(new messageServerStreaming.MessageRequest
{
    Message = "sasd",
    Name = "sadsa"
});
CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
while (await streameingServerMressageResult.ResponseStream.MoveNext(cancellationTokenSource.Token))
{
    System.Console.WriteLine(streameingServerMressageResult.ResponseStream.Current.Message);
}