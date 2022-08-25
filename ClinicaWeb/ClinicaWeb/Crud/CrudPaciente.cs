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
    public class CrudPaciente
    {
            Conexao con = new Conexao();
            public void insert(ModelPaciente cm)
            {
                MySqlCommand cmd = new MySqlCommand("insert into tbPaciente (nomePaciente,enderecoPaciente,telPaciente,celPaciente) values (@nomePaciente,@enderecoPaciente,@telPaciente,@celPaciente);", con.MyConectarBD());
                // @: PARAMETRO
                cmd.Parameters.Add("@nomePaciente", MySqlDbType.VarChar).Value = cm.Nome;
                cmd.Parameters.Add("@enderecoPaciente", MySqlDbType.VarChar).Value = cm.Endereco;
                cmd.Parameters.Add("@telPaciente", MySqlDbType.Int64).Value = cm.Telefone;
                cmd.Parameters.Add("@celPaciente", MySqlDbType.Int64).Value = cm.Celular;

                cmd.ExecuteNonQuery();
                con.MyDesConectarBD();
            }
            public void update(ModelPaciente cm)
            {
                MySqlCommand cmd = new MySqlCommand("update tbPaciente  set nomePaciente=@nomePaciente, enderecoPaciente=@enderecoPaciente, telPaciente=@telPaciente, celPaciente=@celPaciente where codPaciente=@codPaciente;", con.MyConectarBD());
                // @: PARAMETRO
                cmd.Parameters.Add("@codPaciente", MySqlDbType.VarChar).Value = cm.Id;
                cmd.Parameters.Add("@nomePaciente", MySqlDbType.VarChar).Value = cm.Nome;
                cmd.Parameters.Add("@telPaciente", MySqlDbType.Int32).Value = cm.Telefone;
                cmd.Parameters.Add("@celPaciente", MySqlDbType.Int32).Value = cm.Celular;

                cmd.ExecuteNonQuery();
                con.MyDesConectarBD();
            }

            public DataTable read()
            {
                MySqlCommand cmd = new MySqlCommand("select * from tbPaciente", con.MyConectarBD());
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable pac = new DataTable();
                da.Fill(pac);
                con.MyDesConectarBD();
                return pac;
            }
            public DataTable readO(ModelPaciente cm)
            {
            MySqlCommand cmd = new MySqlCommand("select * from tbPaciente where enderecoPaciente like '%"+cm.Endereco + "%'", con.MyConectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable pac = new DataTable();
            da.Fill(pac);
            con.MyDesConectarBD();
            return pac;
            }
    }
}