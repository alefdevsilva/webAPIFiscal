using Microsoft.AspNetCore.Mvc;
using WebApiFiscal.Dominio.Contracts.Repositorios;
using WebApiFiscal.Dominio.Model;
using WebApiFiscal.Service.Contracts;
using Microsoft.Net.Http.Headers;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;

namespace WebApiFiscal.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FiscalController : ControllerBase
{
    private readonly IFiscalService _fiscalService;
    

    public FiscalController(IFiscalService fiscalService)
    {
        _fiscalService = Guard.Against.Null(fiscalService, nameof(fiscalService));
    }

    [HttpGet("cfops")]
    public async Task<IEnumerable<FiscalCfop>> BuscarCfop(string cfop) => await _fiscalService.ListarCFOPS(cfop);

    
    [HttpGet("dados")]
    public dadosOmni BuscarDadosFiscais(string CGC, string UF, string Operacao, string RCT)
    {
        /*
        string CGC = "44354140000133";
        string UF = "SP";
        string Operacao = "VDA";
        string RCT = "00ALNB*RSAHV900S";
        */


        return _fiscalService.BuscarDadosFiscais(CGC, UF, Operacao, RCT);
    }



    [HttpGet("GetDanfeXML")]
    public async Task<ActionResult<object>> GetDanfeXML(string chaveacesso)
    {
            //try
           // {
                var result = await _fiscalService.GetDanfeXML(chaveacesso);
                return new FileContentResult(result, new MediaTypeHeaderValue("application/octet-stream"));
          //  }
          //  catch (Exception x)
           // {
          //      return false;
           // }
    }
       
}
