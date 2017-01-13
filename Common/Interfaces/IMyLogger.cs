using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IMyLogger
    {
        #region NLog.Logger
        void Trace(Exception exception, [Localizable(false)] string message);
        void Trace(Exception exception, [Localizable(false)] string message, params object[] args);
        void Trace(Exception exception, IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args);
        void Trace(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args);
        void Trace([Localizable(false)] string message);
        void Trace([Localizable(false)] string message, params object[] args);
        void Debug(Exception exception, [Localizable(false)] string message);
        void Debug(Exception exception, [Localizable(false)] string message, params object[] args);
        void Debug(Exception exception, IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args);
        void Debug(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args);
        void Debug([Localizable(false)] string message);
        void Debug([Localizable(false)] string message, params object[] args);
        void Info(Exception exception, [Localizable(false)] string message);
        void Info(Exception exception, [Localizable(false)] string message, params object[] args);
        void Info(Exception exception, IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args);
        void Info(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args);
        void Info([Localizable(false)] string message);
        void Info([Localizable(false)] string message, params object[] args);
        void Warn(Exception exception, [Localizable(false)] string message);
        void Warn(Exception exception, [Localizable(false)] string message, params object[] args);
        void Warn(Exception exception, IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args);
        void Warn(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args);
        void Warn([Localizable(false)] string message);
        void Warn([Localizable(false)] string message, params object[] args);
        void Error(Exception exception, [Localizable(false)] string message);
        void Error(Exception exception, [Localizable(false)] string message, params object[] args);
        void Error(Exception exception, IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args);
        void Error(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args);
        void Error([Localizable(false)] string message);
        void Error([Localizable(false)] string message, params object[] args);
        void Fatal(Exception exception, [Localizable(false)] string message);
        void Fatal(Exception exception, [Localizable(false)] string message, params object[] args);
        void Fatal(Exception exception, IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args);
        void Fatal(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args);
        void Fatal([Localizable(false)] string message);
        void Fatal([Localizable(false)] string message, params object[] args);
        #endregion
    }
}
