using System;
using System.Collections.Generic;
using System.Text;
using DotNetCoreConsoleApp.Service;
using Microsoft.Extensions.Logging;

namespace DotNetCoreConsoleApp
{
    public class App
    {
        private readonly IPrintService _printService;
        private readonly ILogger _logger;

        public App(IPrintService printService, ILogger<App> logger)
        {
            _printService = printService;
            _logger = logger;
        }

        public string PrintApp()
        {
            _logger.LogInformation("hello from logging");
            return _printService.Print();
        }
    }
}
