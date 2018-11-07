using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRadioDatabase
{
    class InvalidSongException
    {
        private string message = "Invalid song.";

        public virtual string Message
        {
            get
            {
                return this.message;
            }
        }
    }
}
