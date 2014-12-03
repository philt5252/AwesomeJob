using LdarDataDisplay.Foundation.Models;

namespace LdarDataDisplay.Foundation.DataAccess
{
    public interface ILdarDeviceRepository
    {
        ILdarDeviceData[] RetrieveData();
    }
}