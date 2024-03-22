using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_5_OS
{
    internal class SecondThreadClass
    {
        public event EventHandler<string> UpdateUI;

        private bool stopThread;
        private Thread thread;

        public void CreateThread()
        {
            thread = new Thread(SecondThreadMethod);
        }

        public void StartThread()
        {
            if (thread != null)
                thread.Start();
        }

        public void SetPriority(ThreadPriority priority)
        {
            if (thread != null)
                thread.Priority = priority;
        }

        private void SecondThreadMethod()
        {
            while (!stopThread)
            {
                Thread.Sleep(1000);
                OnUpdateUI("Дополнительный поток выполняет действие");
            }
        }

        protected virtual void OnUpdateUI(string message)
        {
            UpdateUI?.Invoke(this, message);
        }
    }
}
