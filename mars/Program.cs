using System;

namespace mars
{
    class Program
    {
        static void Main(string[] args)
        {
            var redis = RedisStore.RedisCache;

            var sub = redis.Multiplexer.GetSubscriber();
            
            sub.Subscribe("connection-mars-to-earth", (channel, message) => {
                 Console.WriteLine("Got notification: " + (string)message);
            });

            Console.ReadKey();
        }
    }
}
