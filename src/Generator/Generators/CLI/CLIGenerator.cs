﻿using System.Collections.Generic;
using CppSharp.AST;

namespace CppSharp.Generators.CLI
{
    /// <summary>
    /// C++/CLI generator responsible for driving the generation of
    /// source and header files.
    /// </summary>
    public class CLIGenerator : Generator
    {
        private readonly CLITypePrinter typePrinter;

        public CLIGenerator(Driver driver) : base(driver)
        {
            typePrinter = new CLITypePrinter(driver);
            Type.TypePrinterDelegate += type => type.Visit(typePrinter);
        }

        public override List<Template> Generate(TranslationUnit unit)
        {
            var outputs = new List<Template>();

            var header = new CLIHeadersTemplate(Driver, unit);
            outputs.Add(header);

            var source = new CLISourcesTemplate(Driver, unit);
            outputs.Add(source);

            return outputs;
        }

        public override bool SetupPasses()
        {
            return true;
        }
    }
}