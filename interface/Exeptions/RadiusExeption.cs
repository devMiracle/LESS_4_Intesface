using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  @interface.Exeptions
{
    class RadiusExeption : ApplicationException
    {
        public override string Message => MyMessage;
        public string MyMessage { get; set; }
        public RadiusExeption()
        {

        }
        public RadiusExeption(string message)
        {
            MyMessage = message;
        }
    }
}
