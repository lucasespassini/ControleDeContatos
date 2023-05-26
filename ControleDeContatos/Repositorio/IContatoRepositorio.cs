using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel Create(ContatoModel contato);
        List<ContatoModel> FindAll();
    }
}
