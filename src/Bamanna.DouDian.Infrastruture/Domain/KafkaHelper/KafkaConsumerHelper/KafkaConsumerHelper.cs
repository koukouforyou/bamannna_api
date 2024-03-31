using Abp.Domain.Services;
using Confluent.Kafka;
using MyCompanyName.AbpZeroTemplate.Infrastructure.Domain.Kafka.KafkaConsumerHelper.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompanyName.AbpZeroTemplate.Infrastructure.Domain.Kafka.KafkaConsumerHelper
{
    public abstract class KafkaConsumerHelper<T>:DomainService,IKafkaConsumerHelper<T>
    {
        public KafkaConsumerHelper()
        {

        }

        public async void RunConsumer(string bootstrapServers, string groupId, IEnumerable<string> topicId)
        {
            var conf = new ConsumerConfig
            {
                GroupId = groupId,
                BootstrapServers = bootstrapServers,
                AutoOffsetReset = AutoOffsetReset.Latest
            };
            using (var c = new ConsumerBuilder<Ignore, string>(conf).Build())
            {
                c.Subscribe(topicId);//订阅模式
                bool consuming = true;

                while (consuming)
                {
                    try
                    {
                        var cr = c.Consume();
                        string topic = cr.Topic;
                        try
                        {
                            var snowDeviceMeesageDto = JsonConvert.DeserializeObject<T>(cr.Message.Value);
                            if (snowDeviceMeesageDto != null)
                            {
                                DoMessageAsync(snowDeviceMeesageDto);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"ERROR {DateTime.Now} messageJObject[data].ToObject<AiotDeviceDto[]>() Error occured: {e.Message} 消息：{cr.Message.Value}");
                        }
                    }
                    catch (ConsumeException e)
                    {
                        Console.WriteLine($"Error occured: {e.Error.Reason}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error1 occured: {ex.Message}");
                    }
                }
            }
        }

        public abstract void DoMessageAsync(T t);
    }
}
