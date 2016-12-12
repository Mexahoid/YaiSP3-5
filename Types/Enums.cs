using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencySimulator.Types
{
    public enum BillboardState
    {
        /// <summary>
        /// Биллборд строится.
        /// </summary>
        Building,
        /// <summary>
        /// Биллборд свободен.
        /// </summary>
        Free,
        /// <summary>
        /// Хозяин - частное лицо.
        /// </summary>
        Personal,
        /// <summary>
        /// Хозяин - компания.
        /// </summary>
        Company,
        /// <summary>
        /// Хозяин - гос. компания.
        /// </summary>
        Government,
        /// <summary>
        /// Невалидный экземпляр.
        /// </summary>
        Invalid
    }

    public enum ClientLevel
    {
        /// <summary>
        /// Хозяин - частное лицо.
        /// </summary>
        Person = 2,
        /// <summary>
        /// Хозяин - компания.
        /// </summary>
        Company,
        /// <summary>
        /// Хозяин - гос. компания.
        /// </summary>
        Government
    }
    public static class Enums
    {

    }
}
