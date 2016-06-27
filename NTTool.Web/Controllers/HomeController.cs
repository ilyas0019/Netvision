using NTTool.Core;
using NTTool.Core.Classes;
using NTTool.Core.Models;
using NTTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTTool.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Scan()
        {
            var loggedInUser = User.Identity.Name.Split('\\')[1];
            var domain = DomainProvider.GetInstance().EnumerateDomains(loggedInUser);
            var machines = NetworkProvider.GetInstance().DomainNetworkComputers(domain.FirstOrDefault());
            return View(machines);
        }

        public ActionResult Details(MachineEntity obj)
        {
            ViewBag.MachineName = obj.MachineName;
            var listOfSoftwares = MachineProvider.GetInstance().GetListOfInstalledSoftwares(obj.MachineName);

            obj = MachineProvider.GetInstance().GetMachineAdditionalInformation(obj.MachineName, obj.DomainName, obj);

            return View(new ViewModel { MachineInfo=obj,SoftwareList=listOfSoftwares });
        }

    }
}
