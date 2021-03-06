﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico
{
    class ContaCorrente : Conta
    {
        public override void Deposita(double valorASerDepositado)
        {
            if (valorASerDepositado > 0)
                this.Saldo += valorASerDepositado;
        }

        public override void Saca(double valorASerSacado)
        {
            if (valorASerSacado < 0)
            {
                throw new ArgumentException();
            }
            if (valorASerSacado > this.Saldo)
            {
                throw new SaldoInsuficienteException();
            }
            else
            {
                if (this.Titular.EhMaiorDeIdade())
                {
                    this.Saldo -= valorASerSacado;
                }
                else
                {
                    if (valorASerSacado <= 200.0)
                    {
                        this.Saldo -= valorASerSacado;
                    }
                    else
                    {
                        throw new LimiteMenorIdadeException();
                    }
                }
            }
        }




        public override void Transfere(Conta destino, double valor)
        {
            this.Saca(valor);
            destino.Deposita(valor);
        }

        public override string ToString()
        {
            return  "" + this.Titular;
        }
    }
}