using MethodDecorator.Fody.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ExecutionTime;


[module: Timing]
namespace ExecutionTime
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Assembly | AttributeTargets.Module)]
    class TimingAttribute : Attribute, IMethodDecorator
    {
        private DateTime startDt;
        private DateTime endDt;
        private string dateFormation = "yyyy/dd/MM hh:mm:ss";


        public void Init(object instance, MethodBase method, object[] args)
        {
            Console.WriteLine(string.Format("Init: {0} [{1}]", method.DeclaringType.FullName + "." + method.Name, args.Length));
        }

        public void OnEntry()
        {
            startDt = DateTime.Now;
            Console.WriteLine("OnEntry: " + startDt.ToString(dateFormation));
        }

        public void OnException(Exception exception)
        {
            Console.WriteLine("OnException");
        }

        public void OnExit()
        {
            endDt = DateTime.Now;
            Console.WriteLine("OnExit: " + endDt.ToString(dateFormation));
            TimeSpan x = endDt.Subtract(startDt);
            Console.WriteLine("Execute time: " + x.ToString());
        }
    }
}
