using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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
        private readonly MySettings _mySettings;

        public PrintService(IConfiguration configuration, IOptions<MySettings> mySettingAccessor)
        {
            _configuration = configuration;
            _mySettings = mySettingAccessor.Value;
        }
        public string Print()
        {
            return $"{_configuration["configPrint"]} : {_configuration["MySettings:StringSetting"]} : {_mySettings.StringSetting} : {_mySettings.IntSetting}";
        }
    }
}
