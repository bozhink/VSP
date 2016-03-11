namespace RedisClient
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    using Data.Models;
    using ServiceStack.Redis;

    public class Program
    {
        public static void Main(string[] args)
        {
            var timer = new Stopwatch();
            timer.Start();

            var client = new RedisClient();
            UseIRedisClient(client);

            Console.WriteLine(timer.Elapsed);
        }

        public static void UseIRedisClient(IRedisClient client)
        {
            string validatedObjectKey = "Validation";

            var objects = client.Lists[validatedObjectKey];

            int maxId = GetMaximalId(objects);

            var validateObject = new ValidatedObject
            {
                Id = maxId + 1,
                Content = DateTime.Now.ToString(),
                Status = ValidationStatus.Invalid
            };

            objects.Add(validateObject.Serialize());

            objects.Select(o => o.Deserialize<ValidatedObject>())
                .ToList()
                .ForEach(o => Console.WriteLine("{0} || {1} || {2}", o.Id, o.Content, o.Status));
        }

        private static int GetMaximalId(IRedisList objects)
        {
            int maxId;

            if (objects.Any())
            {
                maxId = objects.Max(o => o.Deserialize<ValidatedObject>().Id);
            }
            else
            {
                maxId = 0;
            }

            return maxId;
        }
    }
}
