using CadastroCurriculos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroCurriculos.DAO
{
    class CurriculoDAO
    {
        public List<CurriculoViewModel> Select()
        {
            string sql = "select * from curriculos";

            DataTable curriculos = HelperDAO.ExecutaSelect(sql, null);

            if (curriculos.Rows.Count == 0)
                return null;
            else
                return BuildModel(curriculos);

        }

        public void Delete(int Id)
        {
            string sql = $"delete from curriculos where curriculo_id = {Id}";
            HelperDAO.ExecutaSQL(sql, null);
        }

        public void Insert(CurriculoViewModel curriculo)
        {
            string sql = "insert into curriculos(curriculo_id, nome, cpf, telefone, endereco, email, pretencao_salarial, " +
                         "cargo_pretendido, formacao_academica_1, formacao_academica_2, formacao_academica_3, formacao_academica_4, " +
                         "formacao_academica_5, experiencia_profissional_1, experiencia_profissional_2, experiencia_profissional_3, " +
                         "nivel_ingles, nivel_espanhol)" +
                         "values (@curriculo_id, @nome, @cpf, @telefone, @endereco, @email, @pretencao_salarial, @cargo_pretendido, " +
                         "@formacao_academica_1, @formacao_academica_2, @formacao_academica_3, @formacao_academica_4, @formacao_academica_5, " +
                         "@experiencia_profissional_1, @experiencia_profissional_2, @experiencia_profissional_3, @nivel_ingles, @nivel_espanhol)";
            HelperDAO.ExecutaSQL(sql, CreateParameters(curriculo));
        }

        public void Update(CurriculoViewModel curriculo)
        {
            string sql = "update curriculos set nome = @nome, cpf = @cpf, telefone = @telefone, endereco = @endereco, email = @email, " +
                         "pretencao_salarial = @pretencao_salarial, cargo_pretendido = @cargo_pretendido, formacao_academica_1 = @formacao_academica_1, " +
                         "formacao_academica_2 = @formacao_academica_2, formacao_academica_3 = @formacao_academica_3, formacao_academica_4 = @formacao_academica_4, " +
                         "formacao_academica_5 = @formacao_academica_5, experiencia_profissional_1 = @experiencia_profissional_1, " +
                         "experiencia_profissional_2 = @experiencia_profissional_2, experiencia_profissional_3 = @experiencia_profissional_3, " +
                         "nivel_ingles = @nivel_ingles, nivel_espanhol = @nivel_espanhol" +
                         "where curriculo_id = @curriculo_id";
            HelperDAO.ExecutaSQL(sql, CreateParameters(curriculo));
        }

        public int ProximoId()
        {
            string sql = "select isnull(max(curriculo_id) +1, 1) as 'MAIOR' from curriculos";
            DataTable table = HelperDAO.ExecutaSelect(sql, null);
            return Convert.ToInt32(table.Rows[0]["MAIOR"]);
        }

        private List<CurriculoViewModel> BuildModel(DataTable table)
        {
            List<CurriculoViewModel> curriculos = new List<CurriculoViewModel>();

            foreach (DataRow row in table.Rows)
            { 
                curriculos.Add(buildRow(row));
            }

            return curriculos;
        }

        private SqlParameter[] CreateParameters (CurriculoViewModel curriculo)
        {
            SqlParameter[] parametros = new SqlParameter[18];

            parametros[0] = new SqlParameter("curriculo_id", curriculo.Curriculo_id);
            parametros[1] = new SqlParameter("nome", curriculo.Nome);
            parametros[2] = new SqlParameter("cpf", curriculo.Cpf);
            parametros[3] = new SqlParameter("telefone", curriculo.Telefone);
            parametros[4] = new SqlParameter("endereco", curriculo.Endereco);
            parametros[5] = new SqlParameter("email", curriculo.Email);
            parametros[6] = new SqlParameter("pretencao_salarial", curriculo.Pretencao_salarial);
            parametros[7] = new SqlParameter("cargo_pretendido", curriculo.Cargo_pretendido);
            parametros[8] = new SqlParameter("formacao_academica_1", curriculo.Formacao_academica_1);

            if(curriculo.Formacao_academica_2 == null)
                parametros[9] = new SqlParameter("formacao_academica_2", DBNull.Value);
            else
                parametros[9] = new SqlParameter("formacao_academica_2", curriculo.Formacao_academica_2);

            if (curriculo.Formacao_academica_3 == null)
                parametros[10] = new SqlParameter("formacao_academica_3", DBNull.Value);
            else
                parametros[10] = new SqlParameter("formacao_academica_3", curriculo.Formacao_academica_3);

            if (curriculo.Formacao_academica_4 == null)
                parametros[11] = new SqlParameter("formacao_academica_4", DBNull.Value);
            else
                parametros[11] = new SqlParameter("formacao_academica_4", curriculo.Formacao_academica_4);

            if (curriculo.Formacao_academica_5 == null)
                parametros[12] = new SqlParameter("formacao_academica_5", DBNull.Value);
            else
                parametros[12] = new SqlParameter("formacao_academica_5", curriculo.Formacao_academica_5);

            parametros[13] = new SqlParameter("experiencia_profissional_1", curriculo.Experiencia_profissional_1);

            if(curriculo.Experiencia_profissional_2 == null)
                parametros[14] = new SqlParameter("experiencia_profissional_2", DBNull.Value);
            else
                parametros[14] = new SqlParameter("experiencia_profissional_2", curriculo.Experiencia_profissional_2);

            if (curriculo.Experiencia_profissional_3 == null)
                parametros[15] = new SqlParameter("experiencia_profissional_3", DBNull.Value);
            else
                parametros[15] = new SqlParameter("experiencia_profissional_3", curriculo.Experiencia_profissional_3);

            parametros[16] = new SqlParameter("nivel_ingles", curriculo.Nivel_ingles);
            parametros[17] = new SqlParameter("nivel_espanhol", curriculo.Nivel_espanhol);

            return parametros;
        }
        public CurriculoViewModel ConsultaId(int id)
        {
            string sql = "select * from curriculos where curriculo_id =" + id;
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);

            if (tabela.Rows.Count == 0)
                return null;
            else
                return buildRow(tabela.Rows[0]);
        }
        public CurriculoViewModel buildRow(DataRow row)
        {
            CurriculoViewModel tempCurriculo = new CurriculoViewModel();

            tempCurriculo.Curriculo_id = Convert.ToInt32(row["curriculo_id"]);
            tempCurriculo.Cpf = Convert.ToString(row["cpf"]);
            tempCurriculo.Nome = Convert.ToString(row["nome"]);
            tempCurriculo.Telefone = Convert.ToString(row["telefone"]);
            tempCurriculo.Endereco = Convert.ToString(row["endereco"]);
            tempCurriculo.Email = Convert.ToString(row["email"]);
            tempCurriculo.Pretencao_salarial = Convert.ToDouble(row["pretencao_salarial"]);
            tempCurriculo.Cargo_pretendido = Convert.ToString(row["cargo_pretendido"]);
            tempCurriculo.Formacao_academica_1 = Convert.ToString(row["formacao_academica_1"]);

            if (row["formacao_academica_2"] != DBNull.Value)
                tempCurriculo.Formacao_academica_2 = Convert.ToString(row["formacao_academica_2"]);

            if (row["formacao_academica_3"] != DBNull.Value)
                tempCurriculo.Formacao_academica_3 = Convert.ToString(row["formacao_academica_3"]);

            if (row["formacao_academica_4"] != DBNull.Value)
                tempCurriculo.Formacao_academica_4 = Convert.ToString(row["formacao_academica_4"]);

            if (row["formacao_academica_5"] != DBNull.Value)
                tempCurriculo.Formacao_academica_5 = Convert.ToString(row["formacao_academica_5"]);

            tempCurriculo.Experiencia_profissional_1 = Convert.ToString(row["experiencia_profissional_1"]);

            if (row["experiencia_profissional_2"] != DBNull.Value)
                tempCurriculo.Experiencia_profissional_2 = Convert.ToString(row["experiencia_profissional_2"]);

            if (row["experiencia_profissional_3"] != DBNull.Value)
                tempCurriculo.Experiencia_profissional_3 = Convert.ToString(row["experiencia_profissional_3"]);

            tempCurriculo.Nivel_ingles = Convert.ToString(row["nivel_ingles"]);
            tempCurriculo.Nivel_espanhol = Convert.ToString(row["nivel_espanhol"]);
            return tempCurriculo;
        }
    }


    /*
		CREATE TABLE curriculos
		(
		curriculo_id int PRIMARY KEY NOT NULL,
		nome varchar(80) NOT NULL,
		cpf varchar(15) NOT NULL,
		telefone varchar(15),
		endereco varchar(500),
		email varchar(80),
		pretencao_salarial decimal(18,2),
		cargo_pretendido varchar(50),
		formacao_academica_1 varchar(500) NOT NULL,
		formacao_academica_2 varchar(500),
		formacao_academica_3 varchar(500),
		formacao_academica_4 varchar(500),
		formacao_academica_5 varchar(500),
		experiencia_profissional_1 varchar(500) NOT NULL,
		experiencia_profissional_2 varchar(500),
		experiencia_profissional_3 varchar(500),
		nivel_ingles varchar(15),
		nivel_espanhol varchar(15)
		);
    */
}
