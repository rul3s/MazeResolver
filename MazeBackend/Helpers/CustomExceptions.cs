using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeBackend.Helpers
{
    public class CustomExceptions
    {
        public class MoveNotAllowedException : Exception
        {
            public MoveNotAllowedException()
            {
            }
        }
    }
}
