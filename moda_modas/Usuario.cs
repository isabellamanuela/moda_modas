 using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace moda_modas
{
    public class Usuario
    {
        private int _id;
        private string _nome;
        private string _senha;
        private string _Rua;
        private string _Bairro;
        private string _Numero;
        private string _CEP;

        public Usuario(string nome,string senha)
        {
            Nome = nome;
            Senha = senha;
           
        }

        public Usuario(int id, string nome, string senha)
        {
            Nome = nome;
            Senha = senha;
            Id = id;
        }
        public Usuario(int id, string rua, string bairro, string numero, string cep)
        {
            Rua = rua;
            Bairro = bairro;
            Numero = numero;
            CEP = cep;
            Id = id;
        }
        public Usuario( string rua, string bairro, string numero, string cep)
        {
            Rua = rua;
            Bairro = bairro;
            Numero = numero;
            CEP = cep;
        }

        public string Nome
        {
            set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Campo Nome está vazio!");
            
                _nome = value;}
            get { return _nome;}
        }

        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }


        public string Senha
        {
            set 
            {

                if (string.IsNullOrEmpty(value))
                    throw new Exception("Campo senha está vazio!");
                _senha = value; }
            get { return _senha; }
           
        }
        public string Rua
        {
            set
            {

                if (string.IsNullOrEmpty(value))
                    throw new Exception("Campo Rua está vazio!");
                _Rua = value;
            }
            get { return _Rua; }

        }
        public string Bairro
        {
            set
            {

                if (string.IsNullOrEmpty(value))
                    throw new Exception("Campo Bairro está vazio!");
                _Bairro = value;
            }
            get { return _Bairro; }

        }
        public string Numero
        {
            set
            {

                if (string.IsNullOrEmpty(value))
                    throw new Exception("Campo Número da Casa está vazio!");
                _Numero = value;
            }
            get { return _Numero; }

        }
        public string CEP
        {
            set
            {

                if (string.IsNullOrEmpty(value))
                    throw new Exception("Campo CEP está vazio!");
                _CEP = value;
            }
            get { return _CEP; }

        }


    }
}

