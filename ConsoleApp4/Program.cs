using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            #region General sync program
            List<string> list = new List<string>();
            for (int i = 1; i <= 10; i++)
            {
                list.Add(GetMillisecond(i));
            }

            foreach (var item in list)
            {
                Console.WriteLine($"{item}");
            }
            #endregion

            #region Many await sync flow
            //Console.WriteLine($"準備執行{nameof(AwaitMethod_A_Async)}");
            //var result1 = await AwaitMethod_A_Async(1);
            //Console.WriteLine($"準備執行{nameof(AwaitMethod_B_Async)}");
            //var result2 = await AwaitMethod_B_Async(2);
            //Console.WriteLine($"準備執行{nameof(AwaitMethod_C_Async)}");
            //var result3 = await AwaitMethod_C_Async(3);

            //Console.WriteLine(result1);
            //Console.WriteLine(result2);
            //Console.WriteLine(result3);
            #endregion

            #region Many await async flow
            //Console.WriteLine($"準備執行{nameof(AwaitMethod_A_Async)}");
            //var result1 = AwaitMethod_A_Async(1);
            //Console.WriteLine($"準備執行{nameof(AwaitMethod_B_Async)}");
            //var result2 = AwaitMethod_B_Async(2);
            //Console.WriteLine($"準備執行{nameof(AwaitMethod_C_Async)}");
            //var result3 = AwaitMethod_C_Async(3);

            //Console.WriteLine(await result1);
            //Console.WriteLine(await result2);
            //Console.WriteLine(await result3);
            #endregion

            #region Whenall
            //List<Task<string>> taskList = new List<Task<string>>();
            //for (int i = 1; i <= 10; i++)
            //{
            //    Console.WriteLine($"in for loop task No:{i}  Thread.CurrentThread.ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");

            //    taskList.Add(GetMillisecondAsync(i));
            //}

            //Console.WriteLine($"\nafter leave loop Thread.CurrentThread.ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}\n");

            //_ = await Task.WhenAll(taskList);
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

            Console.ReadKey();
        }

        public static Task<string> GetMillisecondAsync(int no)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"inner task No:{no}  Thread.CurrentThread.ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(new Random(Guid.NewGuid().GetHashCode()).Next(5000, 10000));
                return DateTime.Now.ToString($"{no}. mm:ss fffffff");
            });
        }

        public static string GetMillisecond(int no)
        {
            //Thread.Sleep(100);
            return DateTime.Now.ToString($"{no} mm:ss fffffff");
        }

        public static async Task<string> AwaitMethod_A_Async(int no)
        {
            Console.WriteLine($"{nameof(AwaitMethod_A_Async)} 執行 await前 ThreadId：{Thread.CurrentThread.ManagedThreadId}");
            string result = await GetMillisecondAsync(no).ConfigureAwait(false);
            Console.WriteLine($"{nameof(AwaitMethod_A_Async)} 執行 await後 ThreadId：{Thread.CurrentThread.ManagedThreadId}");
            return result;
        }

        public static async Task<string> AwaitMethod_B_Async(int no)
        {
            Console.WriteLine($"{nameof(AwaitMethod_B_Async)} 執行 await前 ThreadId：{Thread.CurrentThread.ManagedThreadId}");
            string result = await GetMillisecondAsync(no).ConfigureAwait(false);
            Console.WriteLine($"{nameof(AwaitMethod_B_Async)} 執行 await後 ThreadId：{Thread.CurrentThread.ManagedThreadId}");
            return result;
        }

        public static async Task<string> AwaitMethod_C_Async(int no)
        {
            Console.WriteLine($"{nameof(AwaitMethod_C_Async)} 執行 await前 ThreadId：{Thread.CurrentThread.ManagedThreadId}");
            string result = await GetMillisecondAsync(no).ConfigureAwait(false);
            Console.WriteLine($"{nameof(AwaitMethod_C_Async)} 執行 await後 ThreadId：{Thread.CurrentThread.ManagedThreadId}");
            return result;
        }
    }
}
