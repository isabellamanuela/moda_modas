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
            set { _senha = value; }
            get { return _senha; }
           
        }


    }
}

