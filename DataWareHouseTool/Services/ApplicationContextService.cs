using System.Configuration;
using DataWareHouseTool.Services.Interfaces;

namespace DataWareHouseTool.Services
{
    public class ApplicationContextService : IApplicationContextService
    {
        public string InputConnectionString { get; set; } = ConfigurationManager.ConnectionStrings?["InputDatabase"]?.ConnectionString;
        public string OutputConnectionString { get; set; } = ConfigurationManager.ConnectionStrings?["OutputDatabase"]?.ConnectionString;
    }
}