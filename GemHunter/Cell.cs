using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemHunter
{
    public class Cell
    {
        /// <summary>
        /// (Could be "P1", "P2", "G", "O", or "-" for empty)
        /// </summary>
        public string Occupant { get; set; }

        #region constructor
        public Cell() { }
        #endregion

    }
}
