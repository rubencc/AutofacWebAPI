using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutofacWebAPI
{
    public interface ITest
    {
        void Nada();
    }

    public class Test : ITest
    {
        public void Nada()
        {
            throw new NotImplementedException();
        }
    }
}