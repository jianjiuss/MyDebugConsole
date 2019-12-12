using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DebugConsole
{
    /// <summary>
    /// 调试器
    /// </summary>
    public class DebugerWindow
    {
        //静态私有属性
        private static MyConsole m_inst = null;

        /// <summary>
        /// 初始化调试器
        /// </summary>
        public static void Initialization()
        {
            if (m_inst != null)
            {
                Release();
                m_inst = null;
            }
            m_inst = new MyConsole();
            m_inst.Show();
        }

        /// <summary>
        /// 释放接口
        /// </summary>
        public static void Release()
        {
            if (m_inst != null)
            {
                m_inst.Dispose();
                m_inst = null;
            }
        }

        /// <summary>
        /// log 信息
        /// </summary>
        /// <param name="msg">输出信息</param>
        /// <param name="printStack">输出堆栈</param>
        public static void Log(string msg, bool printStack = false)
        {
            if (m_inst != null)
            {
                m_inst.Log(msg, MsgType.Normal, printStack);
            }
            else
            {
                Console.WriteLine("null refrence for debuger");
            }
        }

        /// <summary>
        /// log warnning信息
        /// </summary>
        /// <param name="msg">输出信息</param>
        /// <param name="printStack">输出堆栈</param>
        public static void LogWarning(string msg, bool printStack = false)
        {
            if (m_inst != null)
            {
                m_inst.Log(msg, MsgType.Warning, printStack);
            }
            else
            {
                Console.WriteLine("null refrence for debuger");
            }
        }

        /// <summary>
        /// log error信息
        /// </summary>
        /// <param name="msg">输出信息</param>
        /// <param name="printStack">输出堆栈</param>
        public static void LogError(string msg, bool printStack = false)
        {
            if (m_inst != null)
            {
                m_inst.Log(msg, MsgType.Error, printStack);
            }
            else
            {
                Console.WriteLine("null refrence for debuger");
            }
        }
    }
}
