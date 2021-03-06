﻿using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Harry.EventBus.RabbitMQ
{
    public class RabbitMQEventBusOptions
    {
        private int _retryCount = 5;
        /// <summary>
        /// 重试次数
        /// </summary>
        public int RetryCount
        {
            get { return _retryCount; }
            set
            {
                if (value >= 0)
                {
                    _retryCount = value;
                }
            }
        }

        //public string QueueName { get; set; } = "__EventBus__";

        /// <summary>
        /// 事件
        /// </summary>
        public EventsOptions Events { get; set; } = new EventsOptions();

        /// <summary>
        /// 队列选项
        /// </summary>
        public QueueDeclareOptions QueueDeclare { get; set; } = new QueueDeclareOptions();

        /// <summary>
        /// Exchange选项
        /// </summary>
        public ExchangeOptions Exchange { get; set; } = new ExchangeOptions();

        public class QueueDeclareOptions
        {
            /// <summary>
            /// 队列名称
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 是否持久化
            /// </summary>
            public bool? Durable { get; set; }

            /// <summary>
            /// 是否是排它性队列
            /// </summary>
            public bool? Exclusive { get; set; }

            /// <summary>
            /// 当没有任何消费者使用时，是否自动删除该队列
            /// </summary>
            public bool? AutoDelete { get; set; }

            public Dictionary<string, object> Arguments { get; set; }
        }

        public class EventsOptions
        {
            /// <summary>
            /// 创建ConnectionFactory 时会尝试调用此函数
            /// </summary>
            public Action<ConnectionFactory> OnCreateConnectionFactory { get; set; } /*= _ => _;*/

            /// <summary>
            /// 创建IConnection的时候会尝试调用此函数
            /// </summary>
            public Func<IConnectionFactory, IConnection> OnCreateConnection { get; set; }

            /// <summary>
            /// 通道过滤器，是否支持当前通道名称,如果支持，返回true
            /// </summary>
            public Func<string, bool> ChannelFilter { get; set; } /*= _ => true;*/

            /// <summary>
            /// 设置通道属性
            /// </summary>
            public Action<IBasicProperties> OnSetBasicProperties { get; set; }

        }

        public class ExchangeOptions
        {
            /// <summary>
            /// Exchange名称
            /// </summary>
            public string Name { get; set; }

            //public string Type { get; set; } = "";

            /// <summary>
            /// 是否持久化
            /// </summary>
            public bool? Durable { get; set; }

            /// <summary>
            /// 是否自动删除
            /// </summary>
            public bool? AutoDelete { get; set; }


            public IDictionary<string, object> Arguments { get; set; }

            public string RoutingKey { get; set; }

        }
    }
}
