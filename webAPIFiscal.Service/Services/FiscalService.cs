using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiFiscal.Data.Repositorio;
using WebApiFiscal.Dominio.Contracts.Repositorios;
using WebApiFiscal.Dominio.Model;
using WebApiFiscal.Service.Contracts;


using System.Net.Mime;


namespace WebApiFiscal.Service.Services
{
    public class FiscalService : IFiscalService
    {

        private readonly IFiscalRepositorio _fiscalRepositorio;
        private readonly IConfiguration _configuration;
        private readonly IEmpresaRepositorio _empresaRepositorio;
        private readonly ITblICMSRepositorio _icmsRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IIVALojaRepositorio _ivaLojaRepositorio;
        private readonly IFiscalCFOPRepositorio _fiscalCFOPRepositorio;
        private readonly IFiscalNCM _fiscalNCM;
        private readonly IVwUFFCPPadraoRepositorio _vWUFFCPPadraoRepositorio;





        public FiscalService(IFiscalRepositorio fiscalRepositorio, IEmpresaRepositorio empresaRepositorio
            , ITblICMSRepositorio tblIcmsRepositorio, IProdutoRepositorio produtoRepositorio,
            IIVALojaRepositorio ivaLojaRepositorio, IFiscalCFOPRepositorio fiscalCFOPRepositorio
            , IFiscalNCM fiscalNCM, IConfiguration configuration, IVwUFFCPPadraoRepositorio vwUFFCPPadrao)
        {
            _fiscalRepositorio = fiscalRepositorio
                                 ?? throw new ArgumentNullException(nameof(fiscalRepositorio));

            _empresaRepositorio = empresaRepositorio
                                 ?? throw new ArgumentNullException(nameof(empresaRepositorio));
            _icmsRepositorio = tblIcmsRepositorio
                                ?? throw new ArgumentNullException(nameof(tblIcmsRepositorio));

            _produtoRepositorio = produtoRepositorio
                                ?? throw new ArgumentNullException(nameof(produtoRepositorio));

            _ivaLojaRepositorio = ivaLojaRepositorio
                                ?? throw new ArgumentNullException(nameof(ivaLojaRepositorio));

            _fiscalCFOPRepositorio = fiscalCFOPRepositorio
                                 ?? throw new ArgumentNullException(nameof(fiscalCFOPRepositorio));

            _fiscalNCM = fiscalNCM
                                ?? throw new ArgumentNullException(nameof(fiscalNCM));

            _vWUFFCPPadraoRepositorio = vwUFFCPPadrao
                                ?? throw new ArgumentNullException(nameof(vwUFFCPPadrao));

            _configuration = configuration
                                    ?? throw new ArgumentNullException(nameof(configuration));
        }

        //Variáveis locais
        string OperacaoInterna = "";
        string descricao = "";
        string NCM = "";
        string BCST = "";
        string ProdutoIncidenteST = "";
        string CFOP = "";
        string CodCSTpis = "";
        string CodCSTCofins = "";
        string CodCSTICMS = "";
        string CodCSTIPI = "";
        decimal? ALIQICMS = 0;
        decimal? ALIQPIS = 0;
        decimal? ALIQCOFINS = 0;
        decimal? ALIQIPI = 0;
        string CalculaICMS = "N";
        string CalculaIPI = "N";
        string CalculaPIS = "N";
        string CalculaCOFINS = "N";
        
        decimal? AliquotaICMSInterna = 0;
        decimal? AliquotaICMSExterna = 0;
        decimal? AliquotaICMSImportado = 0;
        DateTime? dataConsulta; 
        double? AliquotaFCP = 0;
        string DifalIsento = "";
        DateTime? DataLimiteDifal;
        decimal? ICMS = 0;

        

        public Task<IEnumerable<FiscalCfop>> ListarCFOPS(string cfop)
        {
            var lista = _fiscalRepositorio.ListarCfops(cfop);

            return lista;
        }

        public dadosOmni BuscarDadosFiscais(string CGC, string UF, string Operacao, string RCT)
        {
            if(Operacao != "VDA" && Operacao != "DEV")
            {
                throw new Exception("O campo operação deve ser preenchido como: VDA ou DEV");
            }


            var empresa = _empresaRepositorio.BuscaEmpresaCGC(CGC);
            TblEmpresa _empresa = new TblEmpresa();
            if (empresa != null)
            {


                //_empresa = empresa.Value;
                _empresa.Nome = empresa.Nome;
                _empresa.Rua = empresa.Rua;
                _empresa.Numero = empresa.Numero;
                _empresa.Bairro = empresa.Bairro;
                _empresa.CodIbgeMun = empresa.CodIbgeMun;
                _empresa.Cidade = empresa.Cidade;
                _empresa.Estado = empresa.Estado;
                _empresa.Cep = empresa.Cep;
                _empresa.Ie = empresa.Ie;
                _empresa.Imunicipal = empresa.Imunicipal;
                _empresa.RegimeTributario = empresa.RegimeTributario;
                _empresa.PPis = empresa.PPis;
                _empresa.PCofins = empresa.PCofins;


                if (_empresa.Estado == UF)
                {
                    OperacaoInterna = "S";
                }
                else
                {
                    OperacaoInterna = "N";
                }

            }

            var _icms = _icmsRepositorio.BuscarICMSUF(_empresa.Estado, UF);

            TblIcmsUf icmsUf = new TblIcmsUf();
            icmsUf.AliqicmsInterna = _icms.AliqicmsInterna;
            icmsUf.AliqicmsExterna = _icms.AliqicmsExterna;
            icmsUf.AliqicmsImport  = _icms.AliqicmsImport;

            //decimal? variavelICMS = icmsUf.AliqicmsInterna;
            AliquotaICMSInterna     = icmsUf.AliqicmsInterna;
            AliquotaICMSExterna     = icmsUf.AliqicmsExterna;
            AliquotaICMSImportado   = icmsUf.AliqicmsImport;



            ViewProdutoGeralNomesAntigosComCodBarras _rct = new ViewProdutoGeralNomesAntigosComCodBarras();

            var rct = _produtoRepositorio.BuscarRCT(RCT);
            if (rct != null)
            {
                _rct.Cbarras = rct.Cbarras;
                descricao = rct.RefNom + "-" + rct.DescrPort;
                _rct.Rctl = rct.Rctl;
                _rct.OrigemLoja = rct.OrigemLoja;
                NCM = rct.Tec;
                _rct.Cest = rct.Cest;
                _rct.Unidade = rct.Unidade;
            }

             //Conferindo a operação
            if (Operacao == "VDA")
            {
                if (OperacaoInterna == "S")
                {
                    if (ProdutoIncidenteST == "S")
                    {
                        CFOP = "5.405";
                        ICMS = 0;
                    }
                    else
                    {
                        CFOP = "5.102";
                        ICMS = AliquotaICMSInterna;
                    }
                }
                else
                {
                    CFOP = "6.108";
                    if (_rct.OrigemLoja == 0)
                    {
                        ICMS = AliquotaICMSExterna;
                    }
                    else
                    {
                        ICMS = AliquotaICMSImportado;
                    }

                }
            }

            if (Operacao == "DEV")
            {
                if (OperacaoInterna == "S")
                {
                    if (ProdutoIncidenteST == "S")
                    {
                        CFOP = "1.411";
                        ICMS = 0;
                    }
                    else
                    {
                        CFOP = "1.202";
                        ICMS = AliquotaICMSInterna;
                    }
                }
                else
                {
                    CFOP = "2.202";
                    ICMS = AliquotaICMSExterna;
                }

            }



            var ivaLoja = _ivaLojaRepositorio.BuscarIVALoja(_rct.Cest, NCM, _empresa.Estado, UF);
            TblIvaLojaX _ivaLoja = new TblIvaLojaX();

           // decimal? ICMS = variavelICMS; arrumar essa parte temos 2 ICMS 

            if (ivaLoja != null)
            {
                ProdutoIncidenteST = "S";
                ICMS = 0;
                BCST = "4";
            }
            else
            {
                BCST = "3";
            }

            var _fiscalCFOP = _fiscalCFOPRepositorio.BuscarCFOP(CFOP);
            Fiscalcfopview fiscalCFOPView = new Fiscalcfopview();

            if (_fiscalCFOP != null)
            {
                CodCSTpis = _fiscalCFOP.CstPis;
                CodCSTCofins = _fiscalCFOP.CstCofins;
                CodCSTICMS = _fiscalCFOP.CstIcms;
                CodCSTIPI = _fiscalCFOP.CstIpi;
                CalculaICMS = _fiscalCFOP.CalculaIcms;
                CalculaIPI = _fiscalCFOP.CalculaIpi;
                CalculaPIS = _fiscalCFOP.CalculaPis;
                CalculaCOFINS = _fiscalCFOP.CalculaCofins;
            }

            var _fNCM = _fiscalNCM.BuscarFiscalNCMMonofasico(NCM);

            FiscalncmMonofasico fiscalNCM = new FiscalncmMonofasico();

            if (_fNCM != null)
            {
                //fiscalNCM.CstCofinsSaida = _fiscalNCM.Value.CstPisSaida;
                CodCSTpis = _fNCM.CstPisSaida;
                CodCSTCofins = _fNCM.CstCofinsSaida;
                CalculaPIS = "N";
                CalculaCOFINS = "N";
            }

            if (CalculaICMS == "S")
            {
                ALIQICMS = ICMS;
            }

            if (CalculaPIS == "S")
            {
                if (_empresa.PPis == null)
                {
                    ALIQPIS = 0;
                }
                else
                    ALIQPIS = _empresa.PPis;
            }

            if (CalculaCOFINS == "S")
            {
                if (_empresa.PCofins == null)
                {
                    ALIQCOFINS = 0;
                }
                else
                    ALIQCOFINS = _empresa.PCofins;
            }

            DifalIsento = "S";

            if(OperacaoInterna == "N")
            {
                DifalIsento = "N";
                //implementar o repositório e a interface
                //Criar uma view para as tabelas TBL_UF e FCP_PADRAO no SQL Server
                //view criado no 32(VwUF_FCPPadrao), pedir para o Rafael Criar no 7 
               var vwUFFCP =  _vWUFFCPPadraoRepositorio.BuscarUFFCPPadrao(UF);
                if (vwUFFCP != null)
                {
                    AliquotaFCP = vwUFFCP.Aliquota;
                    DataLimiteDifal = vwUFFCP.DataLimiteIsento;

                    if(DataLimiteDifal != null)
                    {
                        if(DataLimiteDifal > dataConsulta)
                        {
                            DifalIsento = "S";
                        }
                    }
                }
            }


            dadosOmni _dadosOmni = new dadosOmni();

            _dadosOmni.RCTL = _rct.Rctl;
            _dadosOmni.NCM = NCM;
            _dadosOmni.CodigoBarras = _rct.Cbarras;
            _dadosOmni.DescricaoProduto = descricao;
            _dadosOmni.CEST = _rct.Cest;
            _dadosOmni.Unidade = _rct.Unidade;
            _dadosOmni.OrigemProduto = (byte)_rct.OrigemLoja;
            _dadosOmni.CFOP = CFOP;
            _dadosOmni.CSTICMS = CodCSTICMS;
            _dadosOmni.CSTPIS = CodCSTpis;
            _dadosOmni.CSTCofins = CodCSTCofins;
            _dadosOmni.CSTIPI = CodCSTIPI;
            _dadosOmni.ICMS = (decimal)ALIQICMS;
            _dadosOmni.PIS = (decimal)ALIQPIS;
            _dadosOmni.COFINS = (decimal)ALIQCOFINS;
            _dadosOmni.IPI = ALIQIPI;
            _dadosOmni.ModBCst = BCST;
            _dadosOmni.NomeRazaoSocial = _empresa.Nome;
            _dadosOmni.Logradouro = _empresa.Rua;
            _dadosOmni.Numero = (int)_empresa.Numero;
            _dadosOmni.Bairro = _empresa.Bairro;
            _dadosOmni.Municipio = _empresa.CodIbgeMun;
            _dadosOmni.UF = _empresa.Estado;
            _dadosOmni.CEP = _empresa.Cep;
            _dadosOmni.IE = _empresa.Ie;
            _dadosOmni.IM = _empresa.Imunicipal;
            _dadosOmni.CRTRegimeTributario = _empresa.RegimeTributario;
            _dadosOmni.Cidade = _empresa.Cidade;
            _dadosOmni.Complemento = _empresa.Complemento;
            _dadosOmni.AliquotaFCP = AliquotaFCP;
            _dadosOmni.difalIsento = DifalIsento;


            return _dadosOmni;

        }


        public async Task<byte[]> GetDanfeXML(string chaveacesso)
        {
            if (string.IsNullOrWhiteSpace(chaveacesso)) throw new ArgumentException("Chave de Acesso não pode ser nulo ou vazio.");

            var xml = _fiscalRepositorio.GetXmlNFE(chaveacesso);

            //xml = "<nfeProc xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"4.00\">" + xml + "</nfeProc>";

            if (string.IsNullOrWhiteSpace(xml)) throw new InvalidOperationException("xml não foi localizado.");

            var url = _configuration.GetValue<string>("ServicosExternos:ReportApi");

            return await url
                 .AppendPathSegment("pdf-danfe")
                 .PostJsonAsync(xml)
                 .ReceiveBytes();
        }

    }
}
