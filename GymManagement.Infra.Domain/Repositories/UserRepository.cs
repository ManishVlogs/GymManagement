using GymManagement.Domain.Interface.Repository;
using GymManagement.Infra.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Infra.Domain.Repositories
{
    
    public class UserRepository : IUserRepository
    {
        DBHelper dBHelper = null;
        public UserRepository()
        {
            dBHelper = new DBHelper();
        }
        public async Task<DataTable> TestInterface(string var1, string var2)
        {
            var response = new DataTable();
            using (var dbParamenterCollection = new DBParameterCollection())
            {
                dbParamenterCollection.Add(new DBParameter("@Var1", var1, DbType.String, ParameterDirection.Input));
                dbParamenterCollection.Add(new DBParameter("@Var2", var2, DbType.String, ParameterDirection.Input));
                response = await Task.Run(() => dBHelper.ExecuteDataTable(KeyStore.StoredProcedure.Test.SP_Name1, dbParamenterCollection, CommandType.StoredProcedure));
            }
            return response;
        }
    }
}
