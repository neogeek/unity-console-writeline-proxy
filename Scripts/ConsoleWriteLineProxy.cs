using System;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace UnityConsoleWriteLineProxy
{

    [InitializeOnLoad]
    public class ConsoleWriteLineProxy : TextWriter
    {

        static ConsoleWriteLineProxy()
        {
            Console.SetOut(new ConsoleWriteLineProxy());
        }

        public override void Write(char[] value, int index, int count)
        {
            var message = new string(value, index, count);

            if (message.Trim() == string.Empty)
            {
                return;
            }

            Debug.Log(message);
        }

        public override Encoding Encoding => Encoding.Default;

    }

}
