using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompanyName.AbpZeroTemplate.Infrastructure.Domain.Kafka.KafkaConsumerHelper.Interface
{
    public interface IKafkaConsumerHelper<T> : IDomainService
    {
        void RunConsumer(string bootstrapServers, string groupId, IEnumerable<string> topicId);

        void DoMessageAsync(T t);
    }
}
