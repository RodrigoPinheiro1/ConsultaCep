using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaCep
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("seja bem vindo ao sistema consulta cep");
            Console.WriteLine(" digite o cep para pesquisar ");
            String cepDigitado = Console.ReadLine();
            //https://apps.correios.com.br/SigepMasterJPA/AtendeClienteService/AtendeCliente?wsdl

            using (var ws = new wsCorreios.AtendeClienteClient()) //usa e finaliza 
            {
                if (!String.IsNullOrWhiteSpace(cepDigitado)) //validação se estiver espaços em branco
                {

                    try
                    {
                        var endereco = ws.consultaCEP(cepDigitado);
                        Console.WriteLine("estado: " + endereco.uf);
                        Console.WriteLine("cidade: " + endereco.cidade);
                        Console.WriteLine("bairro: " + endereco.bairro);
                        Console.WriteLine("rua:  " + endereco.end);
                    }
                    catch (Exception x)
                    {

                        Console.WriteLine(x.Message);

                    }
                }
                else
                {
                    Console.WriteLine("Digite um cep valido");
                }
            }

        }
    }
}
