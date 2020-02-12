using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace RepasGeneral.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
                return View();
        }

        public ActionResult Configuracio()
        {   // var
            Models.ModelRepasRoutines mdr;
            bool bCheckedRestes;
            bool bCheckedSumes;
            bool bCheckedMulti;

            bCheckedRestes = false;
            bCheckedSumes = false;
            bCheckedMulti = false;

            mdr = new Models.ModelRepasRoutines();
            mdr.ModelCargar(ref bCheckedSumes, ref bCheckedRestes, ref bCheckedMulti);
            if (bCheckedSumes){
                ViewBag.SumesChecked = "checked";
            }
            else {
                ViewBag.SumesChecked = "";
            };

            if (bCheckedRestes){
                ViewBag.RestesChecked = "checked";
            }
            else{
                ViewBag.RestesChecked = "";
            };

            if (bCheckedMulti){
                ViewBag.MultiChecked = "checked";
            }
            else{
                ViewBag.MultiChecked = "";
            };
            ViewBag.Message = "Configuració";

            return View();
        }

        public ActionResult IniciarProves()
        {
            ViewBag.Message = "Iniciar Proves.";

            return View();
        }
    }
}