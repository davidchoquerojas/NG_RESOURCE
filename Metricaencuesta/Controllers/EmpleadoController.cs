using Metricaencuesta.Data;
using Metricaencuesta.Models;
using Metricaencuesta.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Metricaencuesta.Controllers
{
    public class EmpleadoController : Controller
    {

        Int32 difftime = Convert.ToInt32(ConfigurationManager.AppSettings.Get("hDiff"));
        [SessionValidator]
        [HttpGet]
        public JsonResult listAll(int? id,string estado = null)
        {
            return new JsonResult { Data = new EmpleadoDB().listAll((int)id,estado), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [SessionValidator]
        [HttpGet]
        public JsonResult listByEvaluador(int id)
        {
            return new JsonResult { Data = new EmpleadoDB().listByEvaluador(id),JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        //validar el login para un usuario
        [HttpPost]
        public JsonResult login(empleado oEmpleado)
        {
            oEmpleado.password = new EncriptarDesencriptar().Encriptar(oEmpleado.password.ToString().Trim());
            var data = new EmpleadoDB().login(oEmpleado);
            if (data.Count > 0)
            {
                Session.Add("usuario", data[0].usuario);
                Session.Add("id_empleado",data[0].id_empleado);
                Session.Add("tipo_usuario", data[0].tipo_usuario);
                Session.Add("nombres", data[0].nombres + " " + data[0].apellidos);
                Session.Add("foto_avatar", data[0].foto != null? data[0].foto: "../Utils/img/logo_profile.png");
                FormsAuthentication.SetAuthCookie(data[0].usuario, false);
                var list = new  List<empleado>(){
                    new empleado {id_empleado = data[0].id_empleado,
                                tipo_usuario = data[0].tipo_usuario,
                    }
                };
                return new JsonResult { Data = list };
            }
            else
                return null;
        }
        [SessionValidator]
        [HttpPost]
        public JsonResult updateFoto(empleado o, int id)
        {
            Session["foto_avatar"] = o.foto;
            o.usu_mod = Session["usuario"].ToString();
            o.fec_mod = System.DateTime.Now.AddHours(difftime);
            return new JsonResult { Data = new EmpleadoDB().updateFoto(o, id) };
        }
        //actualiza un usuario 
        [HttpPost]
        public JsonResult update(empleado oEmpleado, int id)
        {
            oEmpleado.usu_mod = Session["usuario"].ToString();
            oEmpleado.fec_mod = System.DateTime.Now.AddHours(difftime);
            oEmpleado.password = new EncriptarDesencriptar().Encriptar(oEmpleado.password.ToString().Trim());
            return new JsonResult { Data = new EmpleadoDB().update(oEmpleado, id) };
        }
        //agrega un usuario  a la base de datos
        [SessionValidator]
        [HttpPost]
        public JsonResult add(empleado oEmpleado)
        {
            oEmpleado.usu_reg = Session["usuario"].ToString();
            oEmpleado.fec_reg = DateTime.Now.AddHours(difftime);

            String sPassword = (oEmpleado.nombres.Substring(0, oEmpleado.nombres.Length - (oEmpleado.nombres.Length - 1))) +
                                  oEmpleado.apellidos.Substring(0, oEmpleado.apellidos.Length - (oEmpleado.apellidos.Length - 1)) +
                                  oEmpleado.dni.Substring(0, oEmpleado.dni.Length - (oEmpleado.dni.Length - 4)).ToString().Trim();
            oEmpleado.password = new EncriptarDesencriptar().Encriptar(sPassword);
            
            return new JsonResult { Data = new EmpleadoDB().add(oEmpleado) };
        }
        [SessionValidator]
        [HttpPost]
        public JsonResult UploadFile(string fileName, int id_empleado)
        {
            var patch = "";
            foreach (String FileLetter in Request.Files)
            {
                var files = Request.Files[FileLetter];
                var stream = files.InputStream;
                patch = files.FileName;
                using (var filestreaim = System.IO.File.Create(@"" + Server.MapPath("~/Utils/cvs/" + patch)))
                {
                    stream.CopyTo(filestreaim);
                }
            }
            empleado empleado = new EmpleadoDB().listAll((int)id_empleado).First();
            empleado.curri_file = patch;
            return new JsonResult { Data = new EmpleadoDB().update(empleado, id_empleado), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}