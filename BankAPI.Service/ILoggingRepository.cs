namespace BankAPI.Services;

public interface ILoggingRepository
{
    void SaveLog(Exception ex);
}