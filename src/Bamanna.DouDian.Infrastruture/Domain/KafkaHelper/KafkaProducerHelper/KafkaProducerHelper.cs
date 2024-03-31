using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Infrastructure.Domain.Kafka.KafkaProducerHelper
{
    public abstract class KafkaProducerHelper<T>
    {

        public KafkaProducerHelper(string brokerList, IEnumerable<string> topicIds)
        {
            InitProducer(brokerList);
            this.topicIds = topicIds;
        }

        public IEnumerable<string> topicIds;

        public IProducer<Null, string> _Producer;

        private void InitProducer(string brokerList)
        {
            var conf = new ProducerConfig
            {
                BootstrapServers = brokerList
            };
            _Producer = new ProducerBuilder<Null, string>(conf).Build();
        }

        public async Task DoMessage(T t)
        {
            foreach (var item in topicIds)
            {
                await _Producer.ProduceAsync(item, new Message<Null, string> { Value = JsonConvert.SerializeObject(t) });
            }
        }
    }
}
