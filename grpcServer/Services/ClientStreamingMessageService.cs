using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clientStreamingMessage;
using Grpc.Core;

namespace grpcServer.Services
{
    public class ClientStreamingMessageService : ClientMessageStreaming.ClientMessageStreamingBase
    {
        public override async Task<ClientStreamingMessageResponse> SendMessage(IAsyncStreamReader<ClientStreamingMessageRequest> requestStream, ServerCallContext context)
        {

            while (await requestStream.MoveNext(context.CancellationToken))
            {
                System.Console.WriteLine($"Message  : {requestStream.Current.Message} || Name  :  {requestStream.Current.Name}");
            }

            return new ClientStreamingMessageResponse
            {
                Message = "Data DOne !! ... "
            };
        }
    }
}