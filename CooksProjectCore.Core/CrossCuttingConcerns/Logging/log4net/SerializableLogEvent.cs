﻿using log4net.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Core.CrossCuttingConcerns.Logging.log4net
{
    [Serializable]
    public class SerializableLogEvent
    {
        private LoggingEvent _loggingEvent;
        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }
        public object Message => _loggingEvent.MessageObject;
    }
}
