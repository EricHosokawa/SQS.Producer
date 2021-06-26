using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using System;
using System.Threading.Tasks;

namespace SQS.Producer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("My AWS SQS Producer!");

            try
            {
                var client = new AmazonSQSClient(RegionEndpoint.USEast2);

                for(int i = 0; i < 4; i++)
                {
                    var message = "teste" + 1;

                    var request = new SendMessageRequest
                    {
                        QueueUrl = "https://sqs.us-east-2.amazonaws.com/713434528261/teste_v1",
                        MessageBody = message
                    };

                    await client.SendMessageAsync(request);

                    Console.WriteLine($"Send SQS MessageBody sucessfully. Message: {message}");

                    await Task.Delay(new TimeSpan(0, 0, 10));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);

                throw ex;
            }
        }
    }       
}
