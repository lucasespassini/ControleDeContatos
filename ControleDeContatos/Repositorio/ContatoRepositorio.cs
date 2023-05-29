using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System.Diagnostics;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext) { _bancoContext = bancoContext; }

        public ContatoModel Create(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();

            return contato;
        }

        public List<ContatoModel> FindAll()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel FindById(int id)
        {
            var contato = _bancoContext.Contatos.FirstOrDefault(contato => contato.Id == id);
            Debug.WriteLine(id);
            return contato == null ? throw new Exception("Não existe contato com esse ID") : contato;
        }

        public ContatoModel Update(ContatoModel contato)
        {
            var contatoDB = FindById(contato.Id);

            if (contatoDB == null) throw new Exception("Não existe contato com esse ID");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;
        }

        public bool Delete(int id)
        {
            var contatoDB = FindById(id);

            if (contatoDB == null) throw new Exception("Não existe contato com esse ID");

            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
