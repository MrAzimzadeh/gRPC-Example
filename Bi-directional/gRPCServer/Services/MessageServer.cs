using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using gRPCMessageServer;

namespace gRPCServer.Services
{
    public class MessageService : Message.MessageBase
    {
        public override async Task SendMessage(IAsyncStreamReader<MessageRequest> requestStream, IServerStreamWriter<MessageResponse> responseStream, ServerCallContext context)
        {
            var task1 = Task.Run(async () =>
             {
                 while (await requestStream.MoveNext(context.CancellationToken))
                 {
                     System.Console.WriteLine($"Message :  {requestStream.Current.Message} || Name     {requestStream.Current.Name}");
                 }
             });
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000);
                responseStream.WriteAsync(new MessageResponse { Message = "Mesaj " + i });
            }

            await task1;


        }
    }
}