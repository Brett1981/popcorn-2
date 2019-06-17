﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Popcorn.Utils.Interfaces;

namespace Popcorn.Utils
{
    /// <summary>
    /// A harness that executes actions using the command line
    /// </summary>
    public class CommandLineHarness : IExecutionHarness
    {
        public IEnumerable<string> Execute(string action, out int exitCode)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    FileName = "cmd.exe",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    Arguments = "/c " + action
                }
            };

            process.Start();

            var lines = new List<string>();
            while (!process.StandardOutput.EndOfStream)
                lines.Add(process.StandardOutput.ReadLine());

            exitCode = process.ExitCode;

            return lines;
        }
    }
}