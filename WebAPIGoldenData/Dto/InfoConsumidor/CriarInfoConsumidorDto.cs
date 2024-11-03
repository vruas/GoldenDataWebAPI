using WebAPIGoldenData.Dto.LinkConsumidor;
using WebAPIGoldenData.Models;

namespace WebAPIGoldenData.Dto.InfoConsumidor
{
    public class CriarInfoConsumidorDto
    {
        public string PreferenciaCompraCliente { get; set; }

        public string PreferenciaAnuncio { get; set; }

        public string MarcasEvitadas { get; set; }
        
        public string Hobbies { get; set; }

        public string AnunciosEvitados { get; set; }

        public string CompraOnline { get; set; }

        public LinkConsumidorDto Consumidor { get; set; }
    }
}
