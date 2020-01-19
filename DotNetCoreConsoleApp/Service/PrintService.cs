using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreConsoleApp.Service
{
    public interface IPrintService
    {
        string Print();
    }

    public class PrintService : IPrintService
    {
        private readonly IConfiguration _configuration;

        public PrintService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Print()
        {
            return _configuration["configPrint"];
        }
    }
}
