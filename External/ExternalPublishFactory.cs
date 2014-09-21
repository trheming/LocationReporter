using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationReporter.External
{
    class ExternalPublishFactory
    {
        //Built for when we have > 1 external data consumer
        public enum ExternalDataConsumers {AMAZON_SQS}

        /// <summary>
        /// Allows the user to select which external data consumer to publish to... For future expansion
        /// </summary>
        /// <param name="selection">External data consumer</param>
        /// <returns>A new instance of whatever the user selects</returns>
        public static IPositionReport getExternalDataConsumer(ExternalDataConsumers selection)
        {
            switch (selection)
            {
                case ExternalDataConsumers.AMAZON_SQS:
                    return new AmazonSqsClient();
                default:
                    return null;
            }
        }
    }
}
