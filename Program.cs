using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RedisHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            //StringRWTest(61);
            StringRWbyThread(61);
            Console.ReadLine();
        }       

        static void StringRWTest(int count)
        {
            //Common.Redis.StringRedisHelper redisHelper = new Common.Redis.StringRedisHelper();
            Common.StringReidsHelper_test stringHelper = new Common.StringReidsHelper_test();
            for (int i = 0; i < count; i++)
            {
                //Random random = new Random();                
                //redisHelper.Set(random.Next().ToString(), "1", DateTime.Now.AddSeconds(10));
                stringHelper.Set(i.ToString(), "ok", DateTime.Now.AddSeconds(10));
                Console.WriteLine(i + ":" + "ok");
            }

        }

        static void StringRWbyThread(int count)
        {
            for (int i = 0; i < count; i++)
            {

                ThreadPool.QueueUserWorkItem(o =>
                {                   
                    //使用静态的RedisClient
                   // Common.StringReidsHelper_test stringHelper = new Common.StringReidsHelper_test();

                    //测试使用非静态的redisClient
                    Common.StringRedisHelper_NoStatic strHelper_NoStatic = new Common.StringRedisHelper_NoStatic();

                    //Random random = new Random();
                    //string radom_str = random.Next().ToString();

                    //var index = stringHelper.Set(i.ToString(), "1", DateTime.Now.AddSeconds(10));
                    var index = strHelper_NoStatic.Set(i.ToString(), "1", DateTime.Now.AddSeconds(10));
                    Console.WriteLine(i + ":" + index);
                });

            }
        }
    }
}
