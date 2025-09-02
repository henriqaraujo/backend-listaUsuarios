using System.Text.Json.Serialization;

namespace web_api_lista_funcionarios.Enuns {

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartamentoEnum {
        RH,
        Financeiro,
        Compras,
        Atendimento,
        Zeladoria
    }
}
