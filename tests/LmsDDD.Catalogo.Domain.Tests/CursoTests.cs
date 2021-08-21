using LmsDDD.Core.DomainObjects;
using System;
using Xunit;

namespace LmsDDD.Catalogo.Domain.Tests
{
    public class CursoTests
    {
        [Fact]
        public void Curso_Validar_ValidacoesDevemRetornarExceptions()
        {

            #region validar criacao do curso


            var ex =  Assert.Throws<DomainException>(() =>
                new Curso(string.Empty, "Descricao", false, 100, DateTime.Now, "Imagem", Guid.NewGuid(), new CargaHoraria(10, 00), 70)
            );

            Assert.Equal("O campo Nome do Curso não pode estar vazio!", ex.Message);


            ex = Assert.Throws<DomainException>(() =>
               new Curso("Nome", string.Empty, false, 100, DateTime.Now, "Imagem", Guid.NewGuid(), new CargaHoraria(10, 00), 70)
            );

            Assert.Equal("O campo Descricao do Curso não pode estar vazio!", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
               new Curso("Nome", "Descricao", false, 0, DateTime.Now, "Imagem", Guid.NewGuid(), new CargaHoraria(10, 00), 70)
            );

            Assert.Equal("O valor do Curso não pode ser menor ou igual a zero", ex.Message);


            ex = Assert.Throws<DomainException>(() =>
               new Curso("Nome", "Descricao", false, 100, DateTime.Now, "Imagem", Guid.Empty, new CargaHoraria(10, 00), 70)
            );

            Assert.Equal("O campo CategoriaId do Curso não pode estar vazio!", ex.Message);


            ex = Assert.Throws<DomainException>(() =>
               new Curso("Nome", "Descricao", false, 100, DateTime.Now, string.Empty, Guid.NewGuid(), new CargaHoraria(10, 00), 70)
            );

            Assert.Equal("O campo Imagem do Curso não pode estar vazio!", ex.Message);


            ex = Assert.Throws<DomainException>(() =>
               new Curso("Nome", "Descricao", false, 100, DateTime.Now, "Imagem", Guid.NewGuid(), new CargaHoraria(10, 00), -70)
            );

            Assert.Equal("A MediaAprovacao do Curso não pode ser menor que zero", ex.Message);


            ex = Assert.Throws<DomainException>(() =>
               new Curso("Nome", "Descricao", false, 100, DateTime.Now, "Imagem", Guid.NewGuid(), new CargaHoraria(10, 60), 70)
            );

            Assert.Equal("Minuto deve ser entre 0 e 59.", ex.Message);

            #endregion

            #region validar metodos de alteração

            Curso c = new Curso("Nome", "Descricao", false, 100, DateTime.Now, "Imagem", Guid.NewGuid(), new CargaHoraria(1, 30), 70);

            ex = Assert.Throws<DomainException>(() => c.AlterarDescricao(string.Empty));

            Assert.Equal("O campo Descricao do Curso não pode estar vazio!", ex.Message);


            ex = Assert.Throws<DomainException>(() => c.AlterarMediaAprovacao(-10));

            Assert.Equal("A MediaAprovacao do Curso não pode ser menor que zero", ex.Message);


            ex = Assert.Throws<DomainException>(() => c.AlterarValor(-10));

            Assert.Equal("O valor do Curso não pode ser menor ou igual a zero", ex.Message);



            #endregion


        }

    }
}
