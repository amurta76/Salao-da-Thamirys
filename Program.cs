using System;
using System.Globalization;

namespace Salao
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa cliente1 = new Pessoa() { Nome = "Alexandre", Telefone="9999999999", Email="pessoa1@email.com" };
            Pessoa cliente2 = new Pessoa() { Nome = "Gilvaneide", Telefone = "88888888", Email = "cliente2@email.com" };
            Funcionario funcionario = new Funcionario() { Nome = "Thamirys", Telefone = "5555555555", Email = "funcionario@email.com",
                                                            Matricula="0001", Comissao= 10
            };

            Servico cortarCabelo = new Servico() { Nome = "Cortar cabelo", Valor = 100.0 };
            Servico fazerUnhas = new Servico() { Nome = "Fazer unhas", Valor = 35.0 };


            Agenda agenda = new Agenda();
            //abre a agenda do funcionario
            agenda.CriarHorarios(funcionario);

            //cria os horarios para os clintes
            Console.WriteLine("Incluindo clientes");
            agenda.AgendarHorario(cliente1, RetornaData("23/01/2021 09:00:00"), cortarCabelo);
            agenda.AgendarHorario(cliente2, RetornaData("23/01/2021 11:00:00"), fazerUnhas);
            agenda.Listar();

            //cliente1 desistiu
            Console.WriteLine("Removendo cliente1");
            agenda.RemoverHorario(cliente1, RetornaData("23/01/2021 09:00:00"));
            agenda.Listar();

            //cliente1 remarcou
            Console.WriteLine("Remarcando cliente1");
            agenda.AgendarHorario(cliente1, RetornaData("23/01/2021 11:00:00"), cortarCabelo);
            agenda.Listar();

            //cliente1 remarcou
            Console.WriteLine("Remarcando cliente1 apos retorno sem horario");
            agenda.AgendarHorario(cliente1, RetornaData("23/01/2021 16:00:00"), cortarCabelo);
            agenda.Listar();

            //cliente1 alterou horario
            Console.WriteLine("Alterando horario cliente2");
            agenda.AlterarHorario(cliente2, RetornaData("23/01/2021 11:00:00"), RetornaData("23/01/2021 16:00:00"));
            agenda.Listar();

            //cliente1 alterou horario
            Console.WriteLine("Alterando horario cliente2");
            agenda.AlterarHorario(cliente2, RetornaData("23/01/2021 11:00:00"), RetornaData("23/01/2021 15:00:00"));
            agenda.Listar();

            agenda.ListarComissao();

            Console.ReadLine();

        }

        private static DateTime RetornaData(String data) {
            return DateTime.ParseExact(data, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        }
    }
}
