namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite.Capacidade >= hospedes.Count)
            {
                //Console.WriteLine(Suite.Capacidade);
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception($"A capacidade da suite não comporta {hospedes.Count()} hospedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return (Hospedes.Count > 0) ? Hospedes.Count : 0;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = (Suite.ValorDiaria * DiasReservados);
            int desconto = 10; //Em %
            
            if (DiasReservados >= 10)
            {
                valor -= ((valor / 100) * desconto);
            }

            return valor;
        }
    }
}