using Microsoft.EntityFrameworkCore;
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
                serviceResponse.Dados = _context.Funcionarios.ToList();  

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

        public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario) {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try {
                if(novoFuncionario == null) {
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                _context.Add(novoFuncionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();
            }
            catch (Exception ex) {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id) {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);

                if (funcionario == null) {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Funcionário não encontrado.";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = funcionario;
            }
            catch (Exception ex) {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel funcionarioAtualizado) {

            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try { 
                FuncionarioModel funcionario = _context.Funcionarios.AsNoTracking().FirstOrDefault(x => x.Id == funcionarioAtualizado.Id);

                if(funcionario == null) {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Funcionário não encontrado.";
                    serviceResponse.Sucesso = false;
                }

                funcionario.DataAlteracao = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();

            }
            catch (Exception ex) {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id) {

            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);

                if (funcionario == null) { 
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Funcionário não encontrado.";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Funcionarios.Remove(funcionario); 
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();
            }
            catch (Exception ex) {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id) {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try {

                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
                if (funcionario == null) {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Funcionário não encontrado.";
                    serviceResponse.Sucesso = false;
                }

                funcionario.Ativo = 0;
                funcionario.DataAlteracao = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();

            }
            catch (Exception ex) {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        
    }
}
