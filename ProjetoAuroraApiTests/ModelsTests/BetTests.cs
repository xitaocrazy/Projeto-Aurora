using ProjetoAuroraApi.Models;
using Xunit;

namespace ProjetoAuroraApi.ModelTests {
    public class BetTests {
        private Bet _bet1;
        private Bet _bet2;
        private Bet _bet3;

        [Fact]
        public void ToStringTest_de_retornar_o_valor_esperado() {
            CreateBets();
            var esperado = "CategoryID: 1 - Dices: 1,1,1,1,1,1";

            var retornado = _bet1.ToString();

            Assert.Equal(esperado, retornado);
        }

        [Fact]
        public void EqualsMethodTest_deve_indicar_que_os_objetos_sao_iguais() {
            CreateBets();

            Assert.True(_bet1.Equals(_bet2));
        }

        [Fact]
        public void EqualsMethodTest_deve_indicar_que_os_objetos_sao_diferentes() {
            CreateBets();

            Assert.False(_bet1.Equals(_bet3));
        }

        [Fact]
        public void ObjectEqualsTest_deve_indicar_que_os_objetos_sao_iguais() {
            CreateBets();

            Assert.True(Equals(_bet1, _bet2));
        }

        [Fact]
        public void ObjectEqualsTest_deve_indicar_que_os_objetos_sao_diferentes() {
            CreateBets();

            Assert.False(Equals(_bet1, _bet3));
        }

        [Fact]
        public void EqualsOperatorTest_deve_indicar_que_os_objetos_sao_iguais() {
            CreateBets();

            Assert.True(_bet1 == _bet2);
        }

        [Fact]
        public void EqualsOperatorTest_deve_indicar_que_os_objetos_sao_diferentes() {
            CreateBets();

            Assert.False(_bet1 == _bet3);
        }

        [Fact]
        public void NotEqualsOperatorTest_deve_indicar_que_os_objetos_nao_sao_diferentes() {
            CreateBets();

            Assert.False(_bet1 != _bet2);
        }

        [Fact]
        public void NotEqualsOperatorTest_deve_indicar_que_os_objetos_sao_diferentes() {
            CreateBets();

            Assert.True(_bet1 != _bet3);
        }

        [Fact]
        public void GetHashCodeTest_deve_retornar_o_valor_esperado() {
            CreateBets();
            
            var esperado = GetHashCode(_bet1);

            var retornado = _bet1.GetHashCode();

            Assert.Equal(esperado, retornado);
        }

        private static int GetHashCode(Bet bet) {
            unchecked {
                var hashCode = bet.CategoryID.GetHashCode();
                hashCode = (hashCode * 397) ^ bet.Dices?.GetHashCode() ?? 0;
                return hashCode;
            }
        }

        private void CreateBets(){
            _bet1 = new Bet{
                CategoryID = 1,   
                Dices= "1,1,1,1,1,1"
            };

            _bet2 = new Bet{
                CategoryID = 1,   
                Dices= "1,1,1,1,1,1"
            };

            _bet3 = new Bet{
                CategoryID = 2,   
                Dices = "3,3,2,6,6"
            };
        }
    }
}