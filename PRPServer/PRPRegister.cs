using System;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using System.Text;

namespace PRPServer
{
    class NameRegisteredException : Exception
    {

    }

    struct RegisterInfo
    {
        public string RegisterName;
        public IPEndPoint EndPoint;
    }

    class PRPRegister
    {
        private List<RegisterInfo> registers;

        void Register(string name, IPEndPoint endPoint)
        {
            if ((from question in registers where question.RegisterName == name select question).Count() != 0)
            {
                throw new NameRegisteredException();
            }
            RegisterInfo info = new RegisterInfo();
            info.RegisterName = name;
            info.EndPoint = endPoint;
            registers.Add(info);
        }

        void Unregister(string name)
        {
            registers.RemoveAll((RegisterInfo info) =>
            {
                return info.RegisterName == name;
            });
        }

        IPEndPoint GetService(string name)
        {
            return registers.Find((RegisterInfo inf) =>
            {
                return inf.RegisterName == name;
            }).EndPoint;
        }
    }
}
