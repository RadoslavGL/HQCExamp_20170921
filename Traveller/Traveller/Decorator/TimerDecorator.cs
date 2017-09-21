using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Core.Contracts;

namespace Traveller.Decorator
{
    public class TimerDecorator : IEngine
    {
        private readonly IEngine engine;
        private readonly IWriter writer;

        public TimerDecorator(IEngine engine, IWriter writer)
        {
            this.engine = engine;
            this.writer = writer;
        }

        public void Start()
        {
            Stopwatch watch = new Stopwatch();

            this.writer.WriteLine("The Engine is starting...");
            watch.Start();
            this.engine.Start();
            watch.Stop();
            this.writer.WriteLine($"The Engine worked for {watch.ElapsedMilliseconds} milliseconds");

        }
    }
}
