using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lab10
{
    public partial class Form1 : Form
    {
        private readonly Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            double lambda = (double)nudLambda.Value;
            double muBase = (double)nudMu.Value;
            int totalRequests = (int)nudN.Value;
            const double maxWait = 20.0;

            double currentTime = 0;
            double nextArrival = 0;
            double nextCompletion = double.MaxValue;

            // Очередь хранит время прихода каждого клиента
            Queue<double> waitQueue = new Queue<double>();

            int processedRequests = 0;
            int successfulRequests = 0;
            int leftQueue = 0;

            // Для подсчёта среднего числа клиентов в очереди (интегральный метод)
            double queueLengthIntegral = 0;
            double lastEventTime = 0;

            while (processedRequests < totalRequests)
            {
                if (nextArrival < nextCompletion)
                {
                    // Накапливаем интеграл длины очереди
                    queueLengthIntegral += waitQueue.Count * (nextArrival - lastEventTime);
                    lastEventTime = nextArrival;

                    currentTime = nextArrival;
                    processedRequests++;

                    if (nextCompletion == double.MaxValue)
                    {
                        // Канал свободен — сразу обслуживаем
                        double muCurrent = (rnd.NextDouble() < 0.1) ? muBase * 2 : muBase;
                        double serviceTime = ExponentialRandom(muCurrent);
                        nextCompletion = currentTime + serviceTime;
                        successfulRequests++;
                    }
                    else
                    {
                        // Канал занят — встаём в очередь
                        waitQueue.Enqueue(currentTime);
                    }

                    nextArrival = currentTime + ExponentialRandom(lambda);
                }
                else
                {
                    // Накапливаем интеграл длины очереди
                    queueLengthIntegral += waitQueue.Count * (nextCompletion - lastEventTime);
                    lastEventTime = nextCompletion;

                    currentTime = nextCompletion;

                    // Убираем из очереди тех, кто уже ушёл за время ожидания > 20 сек
                    while (waitQueue.Count > 0 && (currentTime - waitQueue.Peek()) > maxWait)
                    {
                        waitQueue.Dequeue();
                        leftQueue++;
                    }

                    if (waitQueue.Count > 0)
                    {
                        // Берём следующего из очереди
                        waitQueue.Dequeue();
                        double muCurrent = (rnd.NextDouble() < 0.1) ? muBase * 2 : muBase;
                        double serviceTime = ExponentialRandom(muCurrent);
                        nextCompletion = currentTime + serviceTime;
                        successfulRequests++;
                    }
                    else
                    {
                        nextCompletion = double.MaxValue;
                    }
                }
            }

            // Считаем среднее число клиентов в очереди
            double avgQueueLength = (currentTime > 0) ? queueLengthIntegral / currentTime : 0;

            double pService = (double)successfulRequests / totalRequests;

            listBox1.Items.Clear();
            listBox1.Items.Add($"Вероятность обслуживания: {pService:F4}");
            listBox1.Items.Add($"Ушли из очереди (> 20 с):  {leftQueue}");
            listBox1.Items.Add($"Среднее число в очереди:   {avgQueueLength:F4}");
        }

        private double ExponentialRandom(double rate)
        {
            return -Math.Log(1.0 - rnd.NextDouble()) / rate;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}