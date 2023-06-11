using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Infra.Domain
{
    public static class KeyStore
    {
        public static class StoredProcedure
        {
            public static class Test
            {
                public static readonly string SP_Name1 = "SPtest1";
                public static readonly string SP_Name2 = "SPtest2";
            }

            public static class Dashboard
            {
                public static readonly string SP_Name1 = "DashboardSP";
            }
        }
    }
}
