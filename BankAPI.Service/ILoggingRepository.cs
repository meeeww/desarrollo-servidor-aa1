namespace BankAPI.Service;

public interface ILoggingRepository
{
    void SaveLog(Exception ex);
}