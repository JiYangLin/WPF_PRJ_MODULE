using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace MyAppender
{
    public class MyLogger : log4net.Appender.AppenderSkeleton
    {
        public static log4net.ILog logger = log4net.LogManager.GetLogger("MyLogger");
        public static RichTextBox txtBox = null;
        override protected void Append(log4net.Core.LoggingEvent loggingEvent)
        {
            if (null == txtBox) return;

            string msgType = loggingEvent.Level.ToString();
            string msg = loggingEvent.TimeStamp.ToString() + "    " + loggingEvent.MessageObject.ToString();

            Brush brush = Brushes.DarkGreen;
            if (msgType == "WARN") brush = Brushes.DarkOrange;
            else if (msgType == "ERROR" || msgType == "FATAL") brush = Brushes.DarkRed;
            txtBox.Dispatcher.Invoke(() =>
            {
                txtBox.Document.Blocks.Add(new Paragraph(new Run(msg) { Foreground = brush }));
                txtBox.ScrollToEnd();
            });
        }
    }
}
