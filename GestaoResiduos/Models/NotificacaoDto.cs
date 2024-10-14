namespace GestaoResiduos.Models
{
    public class NotificacaoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataEnvio { get; set; }
        public bool Enviada { get; set; }
    }
}
