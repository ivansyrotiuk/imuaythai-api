namespace IMuaythai.DataAccess.Services
{
    public interface IDataTransferService
    {
        void DownloadDataFromMainDatabase();
        void UploadDataToMainDatabase(int contestId);
    }
}
