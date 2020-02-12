using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepasGeneral.Controllers
{
    public class ConfiguracioController : Controller
    {
        public ActionResult Configuracio()
        {
            return View();
        }
        public ActionResult Guardar()
        {
            // Var
            int iResult;
            bool bSumes, bRestes, bMulti;
            Models.ModelRepasRoutines mdr;

            mdr = new Models.ModelRepasRoutines();
            bSumes = Request["NSumes"] == "on";
            bRestes = Request["NRestes"] == "on";
            bMulti = Request["NMultiplicacions"] == "on";

            iResult = mdr.ModelGuardar(bSumes, bRestes, bMulti);
            if (iResult == 0){   // Grabado OK
                return Redirect("../Home/Index");
            }
            else{
                return Redirect("../Home/Index");
                // return Redirect("../Home/Error");  // TODO: Hay que crear una vista de error
            }

        }
    }
}
