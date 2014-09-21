using Amazon.SQS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationReporter.External
{
    /// <summary>
    /// Handles the publishing of position data to an Amazon SQS queue
    /// </summary>
    class AmazonSqsClient : IPositionReport
    {
        private readonly String SQS_URL_STRING = "https://sqs.us-east-1.amazonaws.com/163428332489/location_reports";

        public bool sendPosition(string latitude, string longitude)
        {
            AmazonSQSClient sqsClient = new AmazonSQSClient(Amazon.RegionEndpoint.USEast1);
            Amazon.SQS.Model.SendMessageRequest request = new Amazon.SQS.Model.SendMessageRequest();
            request.QueueUrl = SQS_URL_STRING;
            request.MessageBody = "lat: " + latitude + " lon: " + longitude;
            sqsClient.SendMessage(request);
            return true;
        }
    }
}
