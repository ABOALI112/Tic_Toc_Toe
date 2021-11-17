using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Toc_Toe
{

    /// <summary>
    /// The type of Value a cell is currently at
    /// </summary>
    public enum MarkType
    {
        /// <summary>
        /// The cell hasn't been clicked yet
        /// </summary>
        Free,

        /// <summary>
        /// The cell contians a O
        /// </summary>
        Nought,

        /// <summary>
        /// The cell contains a X
        /// </summary>
        Cross,

    }
}
