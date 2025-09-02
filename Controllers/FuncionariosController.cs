using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api_lista_funcionarios.DataContext;
using web_api_lista_funcionarios.Models;
using web_api_lista_funcionarios.Services.FuncionarioService;

namespace web_api_lista_funcionarios.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionariosController : ControllerBase {

        //Variável para acessar o banco de dados(AppDbContext) somente para leitura
        private readonly AppDbContext _appDbContext;

        //Construtor para injetar a dependência do banco de dados
        public FuncionariosController(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }

        private readonly IFuncionarioInterface _funcionarioInterface;

        public FuncionariosController(IFuncionarioInterface funcionarioInterface) {
            _funcionarioInterface = funcionarioInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionarios() { 
            return Ok(await _funcionarioInterface.GetFuncionarios());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> CreateFuncionario(FuncionarioModel novoFuncionario) {

            return Ok(await _funcionarioInterface.CreateFuncionario(novoFuncionario));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionarioById(int id) { 

            ServiceResponse<FuncionarioModel> serviceResponse = await _funcionarioInterface.GetFuncionarioById(id);

            return Ok(serviceResponse);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> UpdateFuncionario(FuncionarioModel funcionarioAtualizado) {

            ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.UpdateFuncionario(funcionarioAtualizado);

            return Ok(serviceResponse); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> DeleteFuncionario(int id) { 
            ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.DeleteFuncionario(id);

            return Ok(serviceResponse);
        }

        [HttpPut("InativaFuncionario")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> InativaFuncionario (int id) {

            ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.InativaFuncionario(id);

            return Ok(serviceResponse);
        }


    }
}
