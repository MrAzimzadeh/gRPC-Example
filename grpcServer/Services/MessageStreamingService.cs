using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using messageServerStreaming;

namespace grpcServer.Services
{
    public class MessageStreamingService : MessageServerStreaming.MessageServerStreamingBase
    {

        public override async Task SendMessage(MessageRequest request, IServerStreamWriter<MessageResponse> responseStream, ServerCallContext context)
        {
            System.Console.WriteLine($" Message  :  {request.Message} || Name  : {request.Name}");
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(200);
                await responseStream.WriteAsync(new MessageResponse{
                    Message = $"Message Received {i}"
                });
                
            }

        }
    }
}