using System;

namespace FolderToZip
{
    /// <summary>
    /// NLogヘルパークラス
    /// </summary>
    public static class Log
    {
        /// <summary>
        /// NLogインスタンス（これを使いまわす）
        /// </summary>
        public static NLog.Logger Instance { get; } = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// ログファイルには残さないコンソールにのみ出力するトレースログ
        /// 主にデバッグ用
        /// </summary>
        /// <param name="message"></param>
        public static void Trace(string message)
        {
            Instance.Trace(message);
        }

        /// <summary>
        /// ログファイルに残すデバッグログ
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string message)
        {
            Instance.Debug(message);
        }

        /// <summary>
        /// 通常ログ
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            Instance.Info(message);
        }

        /// <summary>
        /// 警告ログ
        /// 通常起こりえるユーザー操作エラー（読み込みエラーなど）
        /// </summary>
        /// <param name="message"></param>
        public static void Warn(string message)
        {
            Instance.Warn(message);
        }

        /// <summary>
        /// エラーログ
        /// 例外発生時や通常は起こらないエラー
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            Instance.Error(message);
        }

        /// <summary>
        /// エラーログ
        /// 例外発生時や通常は起こらないエラー
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        public static void Error(Exception exception, string message)
        {
            Instance.Error(exception, message);
        }

        /// <summary>
        /// 致命的なエラーログ
        /// 本来あり得ないエラーが発生した時のログ
        /// </summary>
        /// <param name="message"></param>
        public static void Fatal(string message)
        {
            Instance.Fatal(message);
        }

        /// <summary>
        /// 致命的なエラーログ
        /// 本来あり得ないエラーが発生した時のログ
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        public static void Fatal(Exception exception, string message)
        {
            Instance.Fatal(exception, message);
        }
    }
}
