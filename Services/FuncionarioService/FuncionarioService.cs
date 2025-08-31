using web_api_lista_funcionarios.DataContext;
using web_api_lista_funcionarios.Models;

namespace web_api_lista_funcionarios.Services.FuncionarioService {
    public class FuncionarioService : IFuncionarioInterface {

        private readonly AppDbContext _context;

        public FuncionarioService(AppDbContext context) {
            _context = context;
        }   

        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios() {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try { 
                serviceResponse.Dados = _context.FuncionariosWebApi.ToList();  

                if(serviceResponse.Dados.Count == 0) { 
                    serviceResponse.Mensagem = "Nenhum funcionário encontrado.";
                }

            }
            catch (Exception ex) {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;    
            }  
            
            return serviceResponse;
        }

        public Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario) {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id) {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel funcionarioAtualizado) {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id) {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id) {
            throw new NotImplementedException();
        }

        
    }
}
