using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidade
{
    public class Pessoa
    {
        private string _id { get; set; }
        private string _nome { get; set; }
        private double _peso { get; set; }
        private double _altura { get; set; }

        private int _idade { get; set; }
        private bool _clienteAtivo { get; set; }
        private DateTime _dataNascimento { get; set; }

        public int CalcularIdade(DateTime dataNascimento)
        {
            _idade = DateTime.Now.Year - dataNascimento.Year;
            if (dataNascimento.Month > DateTime.Now.Month || dataNascimento.Month == DateTime.Now.Month && dataNascimento.Day > DateTime.Now.Day)
            {
                _idade--;
            }
            return _idade;
        }

        public Pessoa(string id, string nome, double peso, double altura, bool clienteAtivo, DateTime dataNascimento)
        {
            _id = id;
            _nome = nome;
            _peso = peso;
            _altura = altura;
            _dataNascimento = dataNascimento;
            _clienteAtivo = clienteAtivo;
        }
        public new string ToString() => $" ID: {_id}, Nome: {_nome}, Peso: {_peso}, Altura: {_altura}, Idade: {_idade}, Data de Nascimento: {_dataNascimento}, Cliente do Consultorio: {_clienteAtivo} ";


    }
}
