using System.Globalization;

namespace Questao1
{
    class ContaBancaria {

        public int numero;
        public string titular;
        public double saldoConta;

        public ContaBancaria(int numero, string titular, double depositoInicial)
        {
            this.numero = numero;
            this.titular = titular;
            this.saldoConta = depositoInicial;

            this.AbrirConta(this);             
        }

        public double Deposito(double quantia)
        {
            this.saldoConta = this.saldoConta + quantia;
            return this.saldoConta;
        }

        public double Saque(double quantia)
        {

            this.saldoConta = this.saldoConta - quantia;
            return this.saldoConta;
        }

        private ContaBancaria AbrirConta(ContaBancaria conta)
        {            
            return conta;
        }

    }
}
