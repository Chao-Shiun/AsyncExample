using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //List<string> list = new List<string>();
            //for (int i = 1; i <= 10; i++)
            //{
            //    list.Add(GetMillisecond(i));
            //}

            //foreach (var item in list)
            //{
            //    Console.WriteLine($"{item}");
            //}


            #region Whenall
            //List<Task<string>> taskList = new List<Task<string>>();
            //for (int i = 1; i <= 10; i++)
            //{
            //    Console.WriteLine($"in for loop task No:{i}  Thread.CurrentThread.ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");

            //    taskList.Add(GetMillisecondAsync(i));
            //}

            //Console.WriteLine($"\nafter leave loop Thread.CurrentThread.ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}\n");

            //await Task.WhenAll(taskList);
            //foreach (var item in taskList)
            //{
            //    Console.WriteLine($"{await item}");
            //}
            #endregion


            #region Whenany
            //List<Task<string>> taskList = new List<Task<string>>();
            //for (int i = 1; i <= 10; i++)
            //{
            //    taskList.Add(GetMillisecondAsync(i));
            //}


            //while (taskList.Any())
            //{
            //    Task<string> firstFinishedTask = await Task.WhenAny(taskList);

            //    taskList.Remove(firstFinishedTask);

            //    Console.WriteLine($"{await firstFinishedTask}");
            //}
            #endregion


            #region Many await sync flow
            Console.WriteLine("準備執行AwaitMethodAAsync");
            var result1 = await AwaitMethodAAsync(1);
            Console.WriteLine("準備執行AwaitMethodBAsync");
            var result2 = await AwaitMethodBAsync(2);
            Console.WriteLine("準備執行AwaitMethodCAsync");
            var result3 = await AwaitMethodCAsync(3);

            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.WriteLine(result3);
            

            #endregion


            #region Many await async flow
            //Console.WriteLine("準備執行AwaitMethodAAsync");
            //var result1 = AwaitMethodAAsync(1);
            //Console.WriteLine("準備執行AwaitMethodBAsync");
            //var result2 = AwaitMethodBAsync(2);
            //Console.WriteLine("準備執行AwaitMethodCAsync");
            //var result3 = AwaitMethodCAsync(3);

            //var waitAll = Task.WhenAll(result1, result2, result3);

            //Console.WriteLine(await result1);
            //Console.WriteLine(await result2);
            //Console.WriteLine(await result3);

            #endregion
            Console.ReadKey();
        }

        public static Task<string> GetMillisecondAsync(int no)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"inner task No:{no}  Thread.CurrentThread.ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(new Random(Guid.NewGuid().GetHashCode()).Next(10000, 20000));
                return DateTime.Now.ToString($"{no}. mm:ss fff");
            });
        }

        public static string GetMillisecond(int no)
        {
            return DateTime.Now.ToString($"{no} mm:ss fff");
        }

        public static async Task<string> AwaitMethodAAsync(int no)
        {
            Console.WriteLine($"AwaitMethodAAsync 執行 await前 ThreadId：{Thread.CurrentThread.ManagedThreadId}");
            string result = await GetMillisecondAsync(no);
            Console.WriteLine($"AwaitMethodAAsync 執行 await後 ThreadId：{Thread.CurrentThread.ManagedThreadId}");
            return result;
        }

        public static async Task<string> AwaitMethodBAsync(int no)
        {
            Console.WriteLine($"AwaitMethodBAsync 執行 await前 ThreadId：{Thread.CurrentThread.ManagedThreadId}");
            string result = await GetMillisecondAsync(no);
            Console.WriteLine($"AwaitMethodBAsync 執行 await後 ThreadId：{Thread.CurrentThread.ManagedThreadId}");
            return result;
        }

        public static async Task<string> AwaitMethodCAsync(int no)
        {
            Console.WriteLine($"AwaitMethodCAsync 執行 await前 ThreadId：{Thread.CurrentThread.ManagedThreadId}");
            string result = await GetMillisecondAsync(no);
            Console.WriteLine($"AwaitMethodCAsync 執行 await後 ThreadId：{Thread.CurrentThread.ManagedThreadId}");
            return result;
        }
    }
}
