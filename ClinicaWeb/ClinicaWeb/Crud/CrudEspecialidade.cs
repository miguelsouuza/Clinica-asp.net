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
    public class CrudEspecialidade
    {
        Conexao con = new Conexao();
        public void insert(ModelEspecialidade cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbEspecialidade (Especialidade) values (@Especialidade);", con.MyConectarBD());
            // @: PARAMETRO
            cmd.Parameters.Add("@Especialidade", MySqlDbType.VarChar).Value = cm.Nome;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
        public void update(ModelEspecialidade cm)
        {
            MySqlCommand cmd = new MySqlCommand("update tbEspecialidade  set Especialidade=@Especialidade where codEspecialidade=@codEspecialidade;", con.MyConectarBD());
            // @: PARAMETRO
            cmd.Parameters.Add("@codEspecialidade", MySqlDbType.VarChar).Value = cm.Id;
            cmd.Parameters.Add("@Especialidade", MySqlDbType.VarChar).Value = cm.Nome;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public DataTable read()
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbEspecialidade;", con.MyConectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable espec = new DataTable();
            da.Fill(espec);
            con.MyDesConectarBD();
            return espec;
        }
        public DataTable readO(ModelEspecialidade cm)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbEspecialidade  where codEspecialidade = @codEspecialidade;", con.MyConectarBD());
            cmd.Parameters.Add("@codEspecialidade", MySqlDbType.VarChar).Value = cm.Id;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable espec = new DataTable();
            da.Fill(espec);
            con.MyDesConectarBD();
            return espec;
        }
    }
   
}