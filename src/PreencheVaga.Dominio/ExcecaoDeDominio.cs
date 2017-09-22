using System;

namespace PreencheVaga.Dominio
{
    public class ExcecaoDeDominio : Exception
    {
        public ExcecaoDeDominio(string erro) : base(erro) { }

        public static void Quando(bool temErro, string mensagemDeError)
        {
            if (temErro)
                throw new ExcecaoDeDominio(mensagemDeError);
        }
    }
}