﻿using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var parent = new Task(() =>
            {
                var cts = new CancellationTokenSource();
                var tf = new TaskFactory<int>(cts.Token, TaskCreationOptions.AttachedToParent,
                    TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);

                var childTasks = new[]
                {
                    tf.StartNew(() => Sum(cts.Token, 100)),
                    tf.StartNew(() => Sum(cts.Token, 200)),
                    tf.StartNew(() => Sum(cts.Token, int.MaxValue))
                };

                for (int task = 0; task < childTasks.Length; task++)
                {
                    childTasks[task].ContinueWith(t => cts.Cancel(), TaskContinuationOptions.OnlyOnFaulted);
                }

                tf.ContinueWhenAll(childTasks, completedTasks => completedTasks
                    .Where(t => !t.IsFaulted && !t.IsCanceled)
                    .Max(t => t.Result), CancellationToken.None)
                    .ContinueWith(t => Console.WriteLine("The maximum is: " + t.Result),
                        TaskContinuationOptions.ExecuteSynchronously);
            });

            parent.ContinueWith(p =>
            {
                var sb = new StringBuilder("The following exception(s) occurred:" + Environment.NewLine);
                foreach (var e in p.Exception.Flatten().InnerExceptions)
                {
                    sb.AppendLine(" " + e.GetType().ToString());
                }

                Console.WriteLine(sb.ToString());
            }, TaskContinuationOptions.OnlyOnFaulted);

            parent.Start();
            Console.ReadLine();
        }

        static int Sum(CancellationToken token, int n)
        {
            var sum = 0;

            for (; n > 0; n--)
            {
                token.ThrowIfCancellationRequested();
                checked
                {
                    sum += n;
                }
            }

            return sum;
        }
    }
}
