using System.Collections.Generic;
using System.Linq;
using DataWareHouseTool.DAL.Models;
using DataWareHouseTool.Entities;

namespace DataWareHouseTool.Helpers
{
    public static class Converter
    {
        public static Server To(SystemDatabase item)
        {
            if (item != null)
            {
                return new Server
                {
                    Id = item.Id,
                    Name = item.Name
                };
            }
            return null;
        }

        public static IEnumerable<Server> To(IEnumerable<SystemDatabase> list) => list?.Select(To);
    }
}