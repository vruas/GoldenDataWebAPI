﻿namespace WebAPIGoldenData.Dto.Consumidor
{
    public class EditarConsumidorDto
    {
        public int IdConsumidor { get; set; }
        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Sexo { get; set; }

        public string Estado { get; set; }
    }
}
