using System;
using System.Collections.Generic;
using System.Text;

namespace Salao
{
    public class Agenda
    {
        List<Horario> Horarios { get; set; }
        Funcionario Funcionario { get; set; }

        public void CriarHorarios(Funcionario funcionario)
        {
            Funcionario = funcionario;
            Horarios = new List<Horario>(0);
        }

        public void AgendarHorario(Pessoa cliente, DateTime dataHora, Servico servico)
        {

            var agendalivre = Horarios.Find(h => h.DataHora == dataHora);

            if (agendalivre != null)
            {
                Console.WriteLine("Este horário já esta ocupado");
                return;
            }

            Horario horario = new Horario();
            horario.Cliente = cliente;
            horario.DataHora = dataHora;
            horario.Servico = servico;
            Horarios.Add(horario);
            Console.WriteLine("Horário agendado");
        }

        public void Listar()
        {
            Console.WriteLine($"Agenda de {Funcionario.Nome}");
            foreach (var horario in Horarios)
            {
                Console.WriteLine($"Data: { horario.DataHora:dd/MM/yy} Hora: { horario.DataHora:HH:mm} Cliente: {horario.Cliente.Nome} - {horario.Servico.Nome} ");
            }
        }

        public void RemoverHorario(Pessoa cliente, DateTime dataHora)
        {
            Horario horario = RetornarHorario(cliente, dataHora);
            if (horario == null)
            {
                Console.WriteLine("Este horário não foi encontrado");
                return;
            }
            Horarios.Remove(horario);
            Console.WriteLine("Horário removido");
        }

        private Horario RetornarHorario(Pessoa cliente, DateTime dataHora)
        {
            return Horarios.Find(h => new { p1 = h.Cliente, p2 = h.DataHora }.Equals(new { p1 = cliente, p2 = dataHora }));
        }

        public void AlterarHorario(Pessoa cliente, DateTime dataHoraAgendada, DateTime dataHoraNova)
        {
            Horario horario = RetornarHorario(cliente, dataHoraAgendada);
            if (horario == null)
            {
                Console.WriteLine("Este horário não foi encontrado");
                return;
            }
            //valida horario novo
            var agendalivre = Horarios.Find(h => h.DataHora == dataHoraNova);
            if (agendalivre != null)
            {
                Console.WriteLine("Este horário já esta ocupado");
                return;
            }

            horario.DataHora = dataHoraNova;

            Console.WriteLine("Horário alterado");
        }


        public void ListarComissao()
        {
            Console.WriteLine($"Comissao de {Funcionario.Nome}");
            double valorTotalComissao = 0;
            foreach (var horario in Horarios)
            {
                double comissao = horario.Servico.Valor * Funcionario.Comissao / 100.0;
                valorTotalComissao += comissao;
                Console.WriteLine($"Data: { horario.DataHora:dd/MM/yy} Hora: { horario.DataHora: HH:mm} Cliente: {horario.Cliente.Nome} - {horario.Servico.Nome} - Valor: {horario.Servico.Valor} - Comissao: {comissao}");
            }
            Console.WriteLine($"A Comissao de {Funcionario.Nome} é de R$ {valorTotalComissao:#0.00}");



        }

    }
}
