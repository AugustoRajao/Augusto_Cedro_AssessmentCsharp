using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidade
{
    public class CincoEntidades
    {
        string entidade1 = "ID: 100, Nome: Augusto, Peso: 12, Altura: 3, Idade: 18, Data de Nascimento: 2/1/2005 12:00:00 AM, Cliente do Consultorio: False";
        string entidade2 = "ID: 300, Nome: Joao, Peso: 34, Altura: 1.6, Idade: 18, Data de Nascimento: 6/6/2005 12:00:00 AM, Cliente do Consultorio: True";
        string entidade3 = "ID: 22, Nome: Gabriela, Peso: 56, Altura: 1.7, Idade: 18, Data de Nascimento: 6/22/2005 12:00:00 AM, Cliente do Consultorio: True";
        string entidade4 = "ID: 2005, Nome: Miguel, Peso: 50, Altura: 2, Idade: 19, Data de Nascimento: 4/4/2004 12:00:00 AM, Cliente do Consultorio: False";
        string entidade5 = "ID: 40, Nome: Ivan, Peso: 67, Altura: 1.9, Idade: 18, Data de Nascimento: 2/1/2005 12:00:00 AM, Cliente do Consultorio: False";

        public string[] ArrayEntidade()
        {
            string[] arrayEntidade = new string[5];
            arrayEntidade[0] = entidade1;
            arrayEntidade[1] = entidade2;
            arrayEntidade[2] = entidade3;
            arrayEntidade[3] = entidade4;
            arrayEntidade[4] = entidade5;

            return arrayEntidade;
        }
    }
}
