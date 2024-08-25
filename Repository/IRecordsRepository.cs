using CRUDInADO.NET.Models;

namespace CRUDInADO.NET.Repository
{
    public interface IPromotionRepository
    {
        public void AddRecords(Records records);
        List<Records> GetRecordsAsync();
        public Records GetRecordById(int id);
        public Records UpdateRecords(Records records);

        public void DeleteRecordsAsync(int records);
    }
}
