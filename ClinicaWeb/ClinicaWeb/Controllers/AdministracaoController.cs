using ClinicaWeb.Crud;
using ClinicaWeb.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaWeb.Controllers
{
    public class AdministracaoController : Controller
    {
        ModelPaciente modelPaciente = new ModelPaciente();
        ModelEspecialidade modelEspecialidade = new ModelEspecialidade();
        ModelMedico modelMedico = new ModelMedico();
        ModelAtend modelAtend = new ModelAtend();
        CrudPaciente crudPaciente = new CrudPaciente();
        CrudEspecialidade crudEspecialidade = new CrudEspecialidade();
        CrudMedico crudMedico = new CrudMedico();
        CrudAtend crudAtend = new CrudAtend();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CadPaciente(){
            return View();
        }
        [HttpPost]
        public ActionResult CadPaciente(FormCollection form){
            modelPaciente.Nome = form["txtNmPacinete"];
            modelPaciente.Endereco = form["txtEndereco"];
            modelPaciente.Telefone = form["txtTelPaciente"];
            modelPaciente.Celular = form["txtCelular"];
            crudPaciente.insert(modelPaciente);
            ViewBag.Messagem = "Cadastro efetuado com sucesso";
            return View();
        }
        public ActionResult CadEspecialidade()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult CadEspecialidade(FormCollection form)
        {
            modelEspecialidade.Nome = form["txtNmEspec"];
            crudEspecialidade.insert(modelEspecialidade);
            ViewBag.Messagem = "Cadastro efetuado com sucesso";
            return View();
        }
        public ActionResult CadMedico()
        {
            CarregarEspecialidades();
            return View();
        }
        [HttpPost]
        public ActionResult CadMedico(FormCollection form)
        {
            modelMedico.Nome = form["txtNmMedico"];
            modelMedico.IdEspecialidade = Request["especialidade"];
            crudMedico.insert(modelMedico);
            CarregarEspecialidades();
            ViewBag.Messagem = "Cadastro efetuado com sucesso";
            return View();

        }
        public ActionResult CadAtendimento()
        {
            CarregarMedico();
            CarregarPaciente();
            return View();
        }
        [HttpPost]
        public ActionResult CadAtendimento(FormCollection form)
        {
            modelAtend.Data = form["txtData"];
            modelAtend.Diagnostico = form["txtDiagnostico"];
            modelAtend.IdPaciente = Request["paciente"];
            modelAtend.IdMedico = Request["medico"];
            crudAtend.insert(modelAtend);
            CarregarMedico();
            CarregarPaciente();
            ViewBag.Messagem = "Cadastro efetuado com sucesso";
            return View();
        }

        public void CarregarMedico()
        {
            List<SelectListItem> medico = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=dbClinica;User=root;pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbMedico", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    medico.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
            }
            ViewBag.medico = new SelectList(medico, "Value", "Text");
        }

        public ActionResult ConsultarPaciente()
        {
            GridView dgv = new GridView();
            dgv.DataSource = crudPaciente.read();
            dgv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dgv.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();
            return View();
        }
        [HttpPost]
        public ActionResult ConsultarPaciente(FormCollection form)
        {
            modelPaciente.Endereco = form["txtNmCod"];
            GridView dgv = new GridView();
            dgv.DataSource = crudPaciente.readO(modelPaciente);
            dgv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dgv.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();
            return View();
        }

        public ActionResult ConsultarMedico()
        {
            GridView dgv = new GridView();
            dgv.DataSource = crudMedico.read();
            dgv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dgv.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();
            return View();
        }
        [HttpPost]
        public ActionResult ConsultarMedico(FormCollection form)
        {
            modelMedico.Nome = form["txtNmCod"];
            GridView dgv = new GridView();
            dgv.DataSource = crudMedico.readO(modelMedico);
            dgv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dgv.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();
            return View();
        }

        public ActionResult ConsultarEspec()
        {
            GridView dgv = new GridView();
            dgv.DataSource = crudEspecialidade.read();
            dgv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dgv.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();
            return View();
        }
        [HttpPost]
        public ActionResult ConsultarEspec(FormCollection form)
        {
            modelEspecialidade.Id = form["txtNmCod"];
            GridView dgv = new GridView();
            dgv.DataSource = crudEspecialidade.readO(modelEspecialidade);
            dgv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dgv.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();
            return View();
        }

        public ActionResult ConsultarAtend()
        {
            GridView dgv = new GridView();
            dgv.DataSource = crudAtend.read();
            dgv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dgv.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();
            return View();
        }
        [HttpPost]
        public ActionResult ConsultarAtend(FormCollection form)
        {
                modelAtend.IdMedico = form["txtNmCod"];
                GridView dgv = new GridView();
                dgv.DataSource = crudAtend.readO(modelAtend);
                dgv.DataBind();
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                dgv.RenderControl(htw);
                ViewBag.GridViewString = sw.ToString();
                return View();
        }

        public void CarregarPaciente()
        {
            List<SelectListItem> paciente = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=dbClinica;User=root;pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbPaciente", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    paciente.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
            }
            ViewBag.paciente = new SelectList(paciente, "Value", "Text");
        }

        public void CarregarEspecialidades()
        {
            List<SelectListItem> especialidade = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=dbClinica;User=root;pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbEspecialidade", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    especialidade.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
            }
            ViewBag.especialidade = new SelectList(especialidade, "Value", "Text");
        }
    }
}