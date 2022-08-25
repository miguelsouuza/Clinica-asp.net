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
    public class CrudAtend
    {
        Conexao con = new Conexao();
        public void insert(ModelAtend cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbAtendimento (dataAtendimento,codPaciente,codMedico,Diagnostico) values (@dataAtendimento,@codPaciente,@codMedico,@Diagnostico);", con.MyConectarBD());
            // @: PARAMETRO
            cmd.Parameters.Add("@dataAtendimento", MySqlDbType.VarChar).Value = cm.Data;
            cmd.Parameters.Add("@codPaciente", MySqlDbType.VarChar).Value = cm.IdPaciente;
            cmd.Parameters.Add("@codMedico", MySqlDbType.Int64).Value = cm.IdMedico;
            cmd.Parameters.Add("@Diagnostico", MySqlDbType.Text).Value = cm.Diagnostico;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
        public DataTable read()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT tbAtendimento.codAtendimento, " +
                "tbAtendimento.dataAtendimento, " +
                "tbAtendimento.Diagnostico, " +
                "tbMedico.nomeMedico, " +
                "tbPaciente.nomePaciente " +
                "FROM tbAtendimento " +
                "INNER JOIN tbMedico ON tbMedico.codMedico = tbAtendimento.codMedico " +
                "INNER JOIN tbPaciente on tbPaciente.codPaciente = tbAtendimento.codPaciente; ", con.MyConectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable atend = new DataTable();
            da.Fill(atend);
            con.MyDesConectarBD();
            return atend;
        }
        public DataTable readO(ModelAtend cm)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT tbAtendimento.codAtendimento, " +
                "tbAtendimento.dataAtendimento, " +
                "tbAtendimento.Diagnostico, " +
                "tbMedico.nomeMedico, " +
                "tbPaciente.nomePaciente " +
                "FROM tbAtendimento " +
                "INNER JOIN tbMedico ON tbMedico.codMedico = tbAtendimento.codMedico " +
                "INNER JOIN tbPaciente on tbPaciente.codPaciente = tbAtendimento.codPaciente and tbAtendimento.codMedico=@codMedico; ", con.MyConectarBD());
            cmd.Parameters.Add("@codMedico", MySqlDbType.VarChar).Value = cm.IdMedico;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable atend = new DataTable();
            da.Fill(atend);
            con.MyDesConectarBD();
            return atend;
        }
    }
}