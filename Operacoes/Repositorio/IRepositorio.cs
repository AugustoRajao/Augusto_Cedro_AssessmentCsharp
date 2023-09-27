using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidade;
namespace Repositorio
{
    public interface IRepositorio
    {
        void Salvar(Pessoa pessoa);
        string[] Listar();
        void Excluir(string cliente);
        void Atualizar(string cliente);
    }
}
