using BusinessLogicLayer.Infrastructure;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.DTO;

namespace UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel(new ServiceModule("BoardTestDb"));
            BoardService service = kernel.Get<BoardService>();
            service.Dispose();
        }
    }
}
