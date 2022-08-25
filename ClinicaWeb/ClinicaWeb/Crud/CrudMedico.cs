using ClinicaWeb.Banco;
using ClinicaWeb.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ClinicaWeb.Crud
{
    public class CrudMedico
    {
        Conexao con = new Conexao();
        public void insert(ModelMedico cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbMedico (nomeMedico,codEspecialidade) values (@nomeMedico,@codEspecialidade);", con.MyConectarBD());
            // @: PARAMETRO
            cmd.Parameters.Add("@nomeMedico", MySqlDbType.VarChar).Value = cm.Nome;
            cmd.Parameters.Add("@codEspecialidade", MySqlDbType.VarChar).Value = cm.IdEspecialidade;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
        public void update(ModelMedico cm)
        {
            MySqlCommand cmd = new MySqlCommand("update tbMedico  set nomeMedico=@nomeMedico, codEspecialidade=@codEspecialidade where codMedico=@codMedico;", con.MyConectarBD());
            // @: PARAMETRO
            cmd.Parameters.Add("@codMedico", MySqlDbType.VarChar).Value = cm.Id;
            cmd.Parameters.Add("@nomeMedico", MySqlDbType.VarChar).Value = cm.Nome;
            cmd.Parameters.Add("@codEspecialidade", MySqlDbType.VarChar).Value = cm.IdEspecialidade;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public DataTable read()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT tbMedico.codMedico, " +
                "tbMedico.nomeMedico, " +
                "tbEspecialidade.Especialidade " +
                "FROM tbMedico " +
                "INNER JOIN tbEspecialidade ON tbEspecialidade.codEspecialidade = tbMedico.codEspecialidade;", con.MyConectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable med = new DataTable();
            da.Fill(med);
            con.MyDesConectarBD();
            return med;
        }
        public DataTable readO(ModelMedico cm)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT tbMedico.codMedico, " +
                "tbMedico.nomeMedico, " +
                "tbEspecialidade.Especialidade " +
                "FROM tbMedico " +
                "INNER JOIN tbEspecialidade ON tbEspecialidade.codEspecialidade = tbMedico.codEspecialidade and nomeMedico = @nomeMedico;", con.MyConectarBD());
            cmd.Parameters.Add("@nomeMedico", MySqlDbType.VarChar).Value = cm.Nome ;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable med = new DataTable();
            da.Fill(med);
            con.MyDesConectarBD();
            return med;
        }
     
    }
}