namespace DataWareHouseTool.Services.Interfaces
{
    public interface IApplicationContextService
    {
        string InputConnectionString { get; set; }
        string OutputConnectionString { get; set; }
    }
}