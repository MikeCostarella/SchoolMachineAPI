using SchoolMachine.DataAccess.Entities.Interfaces;
using System;

namespace SchoolMachine.DataAccess.Entities.Extensions.Base
{
    public static class IEntityExtensions
    {
        public static bool IsObjectNull(this IEntity entity)
        {
            return entity == null;
        }

        public static bool IsEmptyObject(this IEntity entity)
        {
            return entity.Id.Equals(Guid.Empty);
        }
    }
}
