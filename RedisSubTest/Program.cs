using StackExchange.Redis;
using System;

namespace RedisSubTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var redis = RedisStore.RedisCache;

                var sub = redis.Multiplexer.GetSubscriber().Subscribe(new RedisChannel("test124", RedisChannel.PatternMode.Auto));

                sub.OnMessage(message => {
                    Console.WriteLine(message.Message.ToString());
                });

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
