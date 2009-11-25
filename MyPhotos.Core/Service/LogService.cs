//using System;

//namespace MyPhotos.Core.Service
//{
//    public class LogService
//    {
//            void Debug(object message);
//            void Debug(object message, Exception exception);
//            void Error(object message);
//            void Error(object message, Exception exception);
//            void Fatal(object message);
//            void Fatal(object message, Exception exception);
//            void Info(object message);
//            void Info(object message, Exception exception);
//            void Warn(object message);

//            /// <summary>
//            /// Log a message object with the <see cref="LogLevel.Warn"/> level including
//            /// the stack trace of the <see cref="Exception"/> passed
//            /// as a parameter.
//            /// </summary>
//            /// <param name="message">The message object to log.</param>
//            /// <param name="exception">The exception to log, including its stack trace.</param>
//            void Warn(object message, Exception exception);

//            //		/// <summary>
//            //		/// Logs a formatted message string with the <see cref="LogLevel.Warn"/> level.
//            //		/// </summary>
//            //		/// <param name="format">A String containing zero or more format items</param>
//            //		/// <param name="args">An Object array containing zero or more objects to format</param>
//            //		void WarnFormat(string format, params object[] args); 
//            //
//            //		/// <summary>
//            //		/// Logs a formatted message string with the <see cref="LogLevel.Warn"/> level.
//            //		/// </summary>
//            //		/// <param name="provider">An <see cref="IFormatProvider"/> that supplies culture-specific formatting information</param>
//            //		/// <param name="format">A String containing zero or more format items</param>
//            //		/// <param name="args">An Object array containing zero or more objects to format</param>
//            //		void WarnFormat(IFormatProvider provider, string format, params object[] args);

//            /// <summary>
//            /// Checks if this logger is enabled for the <see cref="LogLevel.Debug"/> level.
//            /// </summary>
//            bool IsDebugEnabled
//            {
//                get;
//            }

//            /// <summary>
//            /// Checks if this logger is enabled for the <see cref="LogLevel.Error"/> level.
//            /// </summary>
//            bool IsErrorEnabled
//            {
//                get;
//            }

//            /// <summary>
//            /// Checks if this logger is enabled for the <see cref="LogLevel.Fatal"/> level.
//            /// </summary>
//            bool IsFatalEnabled
//            {
//                get;
//            }

//            /// <summary>
//            /// Checks if this logger is enabled for the <see cref="LogLevel.Info"/> level.
//            /// </summary>
//            bool IsInfoEnabled
//            {
//                get;
//            }

//            /// <summary>
//            /// Checks if this logger is enabled for the <see cref="LogLevel.Warn"/> level.
//            /// </summary>
//            bool IsWarnEnabled
//            {
//                get;
//            }
//        }
//    }
//}