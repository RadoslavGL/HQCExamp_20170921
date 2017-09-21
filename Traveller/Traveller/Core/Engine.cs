using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using Traveller.Core.Contracts;
using Traveller.Core.Providers;
using Traveller.Models;
using Traveller.Models.Abstractions;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";
        
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IParser parser;

        private StringBuilder Builder = new StringBuilder();

        private Engine(IReader reader, IWriter writer, IParser parser)
        {
            this.reader = reader;
            this.writer = writer;
            this.parser = parser;

            Guard.WhenArgument(reader, "reader").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(parser, "parser").IsNull().Throw();
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine(); ;

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                    {
                        this.writer.Write(this.Builder.ToString());
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    this.Builder.AppendLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            //var parser = new CommandParser();
            var command = this.parser.ParseCommand(commandAsString);
            var parameters = this.parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            this.Builder.AppendLine(executionResult);
        }
    }
}
