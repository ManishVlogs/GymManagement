using GymManagement.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Translator
{
    public static class TestTranslator
    {
        public static List<TestResponse>? TestInterface(this DataTable info)
        {
            if (info == null || info.Rows.Count ==0 )
            {
                return default;
            }
            var TestResponse = info.AsEnumerable().Select(row => new TestResponse
            {
                ID = row.Field<int>("id"),
                Age =row.Field<int>("Age"),
                Name = row.Field<string>("Name"),
            }).ToList();
            return TestResponse;
        }
    }
}
