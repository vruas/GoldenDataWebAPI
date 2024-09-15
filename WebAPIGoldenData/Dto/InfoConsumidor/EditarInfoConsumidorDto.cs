using WebAPIGoldenData.Dto.LinkConsumidorInfo;

namespace WebAPIGoldenData.Dto.InfoConsumidor
{
    public class EditarInfoConsumidorDto
    {
        public int IdInfoConsumidor { get; set; }
        public string PreferenciaCompraCliente { get; set; }

        public string PreferenciaAnuncio { get; set; }

        public string MarcasEvitadas { get; set; }

        public string Hobbies { get; set; }

        public string AnunciosEvitados { get; set; }

        public string CompraOnline { get; set; }

        public LinkConsumidorInfoDto Consumidor { get; set; }
    }
}
