using ProjetoAuroraApi.Models;
using Xunit;

namespace AvaliacaoDeCandidatosApi.Tests.ModelTests {
    public class Candidatotests {
        private Category _category1;
        private Category _category2;
        private Category _category3;

        [Fact]
        public void ToStringTest_de_retornar_o_valor_esperado() {
            CreateCandidatos();
            var Rule = "Haver pelo menos 1 dado com valor 1 no rolamento.";
            var Calculation = "Soma de todos os dados de valor 1.";
            var esperado = $"Id: 1 - Name: Um - Rule: {Rule} - Calculation: {Calculation} - Points: 2";

            var retornado = _category1.ToString();

            Assert.Equal(esperado, retornado);
        }

        [Fact]
        public void EqualsMethodTest_deve_indicar_que_os_objetos_sao_iguais() {
            CreateCandidatos();

            Assert.True(_category1.Equals(_category2));
        }

        [Fact]
        public void EqualsMethodTest_deve_indicar_que_os_objetos_sao_diferentes() {
            CreateCandidatos();

            Assert.False(_category1.Equals(_category3));
        }

        [Fact]
        public void ObjectEqualsTest_deve_indicar_que_os_objetos_sao_iguais() {
            CreateCandidatos();

            Assert.True(Equals(_category1, _category2));
        }

        [Fact]
        public void ObjectEqualsTest_deve_indicar_que_os_objetos_sao_diferentes() {
            CreateCandidatos();

            Assert.False(Equals(_category1, _category3));
        }

        [Fact]
        public void EqualsOperatorTest_deve_indicar_que_os_objetos_sao_iguais() {
            CreateCandidatos();

            Assert.True(_category1 == _category2);
        }

        [Fact]
        public void EqualsOperatorTest_deve_indicar_que_os_objetos_sao_diferentes() {
            CreateCandidatos();

            Assert.False(_category1 == _category3);
        }

        [Fact]
        public void NotEqualsOperatorTest_deve_indicar_que_os_objetos_nao_sao_diferentes() {
            CreateCandidatos();

            Assert.False(_category1 != _category2);
        }

        [Fact]
        public void NotEqualsOperatorTest_deve_indicar_que_os_objetos_sao_diferentes() {
            CreateCandidatos();

            Assert.True(_category1 != _category3);
        }

        [Fact]
        public void GetHashCodeTest_deve_retornar_o_valor_esperado() {
            CreateCandidatos();
            
            var esperado = GetHashCode(_category1);

            var retornado = _category1.GetHashCode();

            Assert.Equal(esperado, retornado);
        }

        private static int GetHashCode(Category category) {
            unchecked {
                var hashCode = category.Id.GetHashCode();
                hashCode = (hashCode * 397) ^ category.Name?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ category.Rule?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ category.Calculation?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ category.Points.GetHashCode();
                return hashCode;
            }
        }

        private void CreateCandidatos(){
            _category1 = new Category{
                Id = 1,   
                Name= "Um",        
                Points = 2,
                Rule = "Haver pelo menos 1 dado com valor 1 no rolamento.",
                Calculation = "Soma de todos os dados de valor 1."
            };

            _category2 = new Category{
                Id = 1,   
                Name= "Um",        
                Points = 2,
                Rule = "Haver pelo menos 1 dado com valor 1 no rolamento.",
                Calculation = "Soma de todos os dados de valor 1."
            };

            _category3 = new Category{
                Id = 2,   
                Name= "Dois",        
                Points = 4,
                Rule = "Haver pelo menos 1 dado com valor 2 no rolamento.",
                Calculation = "Soma de todos os dados de valor 2."
            };
        }
    }
}