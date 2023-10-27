using System.Drawing;
using Grpc.Net.Client;
using grpcMessageServer;
using grpcServer;

Console.WriteLine("Clienr");


var chanel = GrpcChannel.ForAddress("http://localhost:5256");
var greetClient = new Greeter.GreeterClient(channel: chanel);

HelloReply result = await greetClient.SayHelloAsync(new HelloRequest
{
    Name = "Salam Dostlarrr "
});
Console.WriteLine(result.Message);

Console.WriteLine("Unary =>  ");

var messagqeClient  = new Message.MessageClient(chanel);
MessageResponse messageResult = await messagqeClient.SendMessageAsync(new MessageRequest
{
    Name = " Mahammad  ",
    Message = "dcfvgbhnjmkjhghbnjnhbvgbhnm "
});

Console.WriteLine(messageResult.Message);
