using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shplode.Classes.Logs
{
    public class Log
    {
        private int _time;
        private string _message;
        private LogLevel _level;

        public int Time { get => _time; }
        public string Message { get => _message; }
        public LogLevel Level { get => _level; }

        public Log(int time, string message, LogLevel level)
        {
            _time = time;
            _message = message;
            _level = level;
        }
    }
}
