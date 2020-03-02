using System;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using System.Text;

namespace PRPServer
{
    public class NameRegisteredException : Exception
    {

    }

    struct RegisterInfo
    {
        public string RegisterName;
        public IPEndPoint EndPoint;
    }

    static class PRPRegister
    {
        private static List<RegisterInfo> registers = new List<RegisterInfo>();

        public static void Register(string name, IPEndPoint endPoint)
        {
            if ((from question in registers where question.RegisterName == name select question).Any())
            {
                throw new NameRegisteredException();
            }
            RegisterInfo info = new RegisterInfo();
            info.RegisterName = name;
            info.EndPoint = endPoint;
            registers.Add(info);
        }

        public static void Unregister(string name)
        {
            registers.RemoveAll((RegisterInfo info) =>
            {
                return info.RegisterName == name;
            });
        }

        public static IPEndPoint GetService(string name)
        {
            return registers.Find((RegisterInfo inf) =>
            {
                return inf.RegisterName == name;
            }).EndPoint;
        }
    }
}
