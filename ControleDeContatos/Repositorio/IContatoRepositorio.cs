using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel Create(ContatoModel contato);
        List<ContatoModel> FindAll();
        ContatoModel FindById(int id);
        ContatoModel Update(ContatoModel contato);
        bool Delete(int id);
    }
}
