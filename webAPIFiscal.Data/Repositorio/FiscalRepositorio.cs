using Dapper;
using System.Data;
using WebApiFiscal.Data.Context;
using WebApiFiscal.Dominio.Contracts.Repositorios;
using WebApiFiscal.Dominio.Model;

namespace WebApiFiscal.Data.Repositorio;

public class FiscalRepositorio : IFiscalRepositorio
{
    private readonly EcommerceContext _ecommerceContext;

    public FiscalRepositorio(EcommerceContext ecommerceContext)
    {
        _ecommerceContext = ecommerceContext;
    }

    public async Task<IEnumerable<FiscalCfop>> ListarCfops(string cfop)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pcfop", cfop.Replace(".", ""));

            const string sql = @"
                                    select
                                        TBL_CFOP_ID
                                            ,CLAFISCAL
                                            ,NATUREZA
                                            ,TIPONF
                                            ,PERC_DESC
                                            ,CTBINT
                                            ,SUB_CFOP
                                            ,IncideImpostos
                                            ,GeraCAR
                                            ,AlteraEstoques
                                            ,Tabela_Fixa
                                            ,Prazo_Fixo
                                            ,OBS1
                                            ,OBS2
                                            ,OBS3
                                            ,CST_ICMS
                                            ,CST_IPI
                                            ,CST_PIS
                                            ,CST_COFINS
                                            ,OBScfop
                                            ,CLAFISCAL_1
                                            ,CLAFISCAL_2
                                            ,LANCA_OUTROS
                                            ,LANCA_ISENTO
                                            ,DATA
                                            ,USUARIO
                                            ,Finalidade
                                            ,GeraST
                                            ,TituloNF
                                            ,CLAFISCAL_E1
                                            ,CLAFISCAL_E2
                                            ,Hora
                                            ,SDATAHORA
                                            ,OPERACAO
                                            ,PedidoNaturezaSigla
                                            ,OpInternaExterna
                                            ,GeraCAP
                                            ,AfetaFaturamento
                                            ,PedidoNaturezaID
                                            ,ContabilTipoNFID
                                            ,NaoIncideST
                                            ,webbloja
                                            ,difal
                                            ,somaipi
                                            ,LancaEstoqueVerejo
                                            ,devolucao
                                            ,RecebeSemConferencia
                                            ,CodigoBeneficio
                                            ,pReducao
                                            ,flagTransferencia
                                            ,SUFRAMA
                                            ,BitAtivo
                                            ,CTBINT_NF_PF
                                            ,CTBINT_NF_PJ
                                            ,CTBINT_CF
                                            ,CTBINT_NFCE
                                            ,CTBINT_SAT
                                            ,DevolucaoSN
                                    from FiscalCFOP
                                    where ((replace(CLAFISCAL,'.','') = @pcfop) or (isnull(@pcfop,'') = ''))";

            var connection = _ecommerceContext.GetConnection();
            return await connection.QueryAsync<FiscalCfop>(sql, parameters, commandType: CommandType.Text);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


    public string GetXmlNFE(string chaveacesso)
    {
        //var sql = $@"select XML as Arquivoxml from nfe_capa where SEFAZ_NRO_CHAVEACESSO = '{chaveacesso}'";
        var sql = $@"select xmlContent as Arquivoxml from ArquivoXML where chaveacesso = '{chaveacesso}'";

       
        return _ecommerceContext.GetConnection()
               .QueryFirstOrDefault<string>(sql, null, null, null, CommandType.Text);

    }

}
