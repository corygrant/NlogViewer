using System;
using System.Globalization;
using System.Windows.Media;
using NLog;

namespace NlogViewer
{
    public class LogEventViewModel
    {
        private LogEventInfo logEventInfo;

        public LogEventViewModel(LogEventInfo logEventInfo)
        {
            // TODO: Complete member initialization
            this.logEventInfo = logEventInfo;

            ToolTip = logEventInfo.FormattedMessage;
            Level = logEventInfo.Level.ToString();
            FormattedMessage = logEventInfo.FormattedMessage;
            Exception = logEventInfo.Exception;
            LoggerName = logEventInfo.LoggerName;
            Time = logEventInfo.TimeStamp.ToString(CultureInfo.InvariantCulture);

            SetupColors(logEventInfo);
        }


        public string Time { get; private set; }
        public string LoggerName { get; private set; }
        public string Level { get; private set; }
        public string FormattedMessage { get; private set; }
        public Exception Exception { get; private set; }
        public string ToolTip { get; private set; }
        public SolidColorBrush Background { get; private set; }
        public SolidColorBrush Foreground { get; private set; }
        public SolidColorBrush BackgroundMouseOver { 
            get
            {
                return new SolidColorBrush(Color.FromRgb((byte)(Background.Color.R * 0.5), (byte)(Background.Color.G * 0.5),(byte)(Background.Color.B * 0.5)));
            }
        }
        public SolidColorBrush BackgroundSelected
        {
            get
            {
                return new SolidColorBrush(Color.FromRgb((byte)(Background.Color.R * 0.3), (byte)(Background.Color.G * 0.3), (byte)(Background.Color.B * 0.3)));
            }
        }
        public SolidColorBrush ForegroundMouseOver { get; private set; }

        private void SetupColors(LogEventInfo logEventInfo)
        {
            if (logEventInfo.Level == LogLevel.Warn)
            {
                Background = Brushes.Yellow;
            }
            else if (logEventInfo.Level == LogLevel.Error)
            {
                Background = Brushes.Tomato;
            }
            else
            {
                Background = Brushes.White;
            }
            Foreground = Brushes.Black;
            ForegroundMouseOver = Brushes.White;
        }
    }
}