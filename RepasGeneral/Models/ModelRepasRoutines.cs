using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepasGeneral.Models
{
    public class ModelRepasRoutines
    {
        public ModelRepasRoutines()
        {

        }

        public int ModelGuardar(bool bSumes, bool bRestes, bool bMulti)
        {
            // var
            int iResult;
            Models.RespasContext db;
            Models.CONFIGURACIO MyConf;

            iResult = 0;
            // Connexió amb la base de dades
            db = new RepasGeneral.Models.RespasContext();
            // Agafem el primer registre. En aquesta versió agafem sempre el primer.Posteriorment es pot fer multiversio.
            if (db.CONFIGURACIO.Count(item => item.ID == 1) == 0)
            {// No existeix el registre vol dir que no hi ha configuració; Creem un MyConf  //INSERT
                MyConf = new RepasGeneral.Models.CONFIGURACIO();
                db.CONFIGURACIO.Add(MyConf);
            }
            else
            { //Ja existeix no cal crear - lo                                               //UPDATE
                MyConf = db.CONFIGURACIO.First(item => item.ID == 1);
            };
            //********************************************************************** /
            //* PASSAR DE LA Vista A MyConf                                          /
            //********************************************************************** /
            if (MyConf != null)
            {// Creacio correcta
                MyConf.ID = 1;
                MyConf.SUMES = bSumes;
                MyConf.RESTES = bRestes;
                MyConf.MULTIPLICACIONS = bMulti;

                db.SaveChanges();
                iResult = 0;
            }
            else

            {
                iResult = -1;
            }

            return (iResult);
        }

        public void ModelCargar(ref bool bCheckedSumes, ref bool bCheckedRestes, ref bool bCheckedMulti)
        {
            Models.RespasContext db;
            Models.CONFIGURACIO MyConf;

            bCheckedSumes = false;
            bCheckedRestes = false;
            bCheckedMulti = false;

            // Connexió amb la base de dades
            db = new RepasGeneral.Models.RespasContext();
            // Agafem el primer registre. En aquesta versió agafem sempre el primer.Posteriorment es pot fer multiversio.
            if (db.CONFIGURACIO.Count(item => item.ID == 1) > 0)
            {
                MyConf = db.CONFIGURACIO.First(item => item.ID == 1);
                if (MyConf != null)
                {// Existeix la configuració
                    bCheckedSumes = MyConf.SUMES == true;
                    bCheckedRestes = MyConf.RESTES == true;
                    bCheckedMulti = MyConf.MULTIPLICACIONS == true;
                }
            }
        }
    }
}
