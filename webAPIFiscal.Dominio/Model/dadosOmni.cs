namespace WebApiFiscal.Dominio.Model
{
    public partial class dadosOmni
    {
        public string? NomeRazaoSocial { get; set; }//DadosOmni.pNOME = LOC_NOME
        public string? IE { get; set; }//DadosOmni.pIE = LOC_IE
        public string? IM { get; set; }// DadosOmni.pIM = LOC_IM
        public string? Logradouro { get; set; }//DadosOmni.pLOGR = LOC_LOGR
        public string? CRTRegimeTributario { get; set; }//DadosOmni.pCRT = LOC_CRT
        public string? Bairro { get; set; }//DadosOmni.pBAIRRO = LOC_BAIRRO

        public string? Cidade { get; set; }//DadosOmni.pMunicipio = LOC_Municipio

        public int Numero { get; set; }//DadosOmni.pNRO = LOC_NRO
        public string? UF { get; set; }//  DadosOmni.pEMITENTE_UF = LOC_EMITENTE_UF
        public string? Complemento { get; set; }

        public string? Municipio { get; set; }//DadosOmni.pCodIbgeMun = LOC_CodIbgeMun

        public string? CEP { get; set; }//DadosOmni.pCEP = LOC_CEP

        public string? CFOP { get; set; }// DadosOmni.pCFOP = LOC_CFOP

        public string? CSTIPI { get; set; }//DadosOmni.pCSTipi = LOC_CodCSTIPI

        public string? CSTICMS { get; set; }// DadosOmni.pCSTicms = LOC_CodCSTICMS

        public string? CSTPIS { get; set; }//DadosOmni.pCSTpis = LOC_CodCSTpis

        public string? CSTCofins { get; set; }//    DadosOmni.pCSTCofins = LOC_CodCSTCofins

        public string? ModBCst { get; set; }//DadosOmni.pmodBCST = LOC_modBCST

        public decimal? IPI { get; set; }//DadosOmni.pALIQipi = LOC_ALIQIPI

        public decimal? ICMS { get; set; }//  DadosOmni.pALIQicms = LOC_ALIQICMS

        public decimal? PIS { get; set; }// DadosOmni.pALIQpis = LOC_ALIQPIS

        public decimal? COFINS { get; set; }//  DadosOmni.pALIQcofins = LOC_ALIQCOFINS

        public string? DescricaoProduto { get; set; }//DadosOmni.pDescricao = LOC_Descricao

        public string? CodigoBarras { get; set; }// DadosOmni.pCBARRAS = LOC_CBARRAS

        public byte OrigemProduto { get; set; }// DadosOmni.pORIGEMproduto = LOC_ORIGEMPRODUTO

        public string? Unidade { get; set; }//  DadosOmni.pUNIDADE = LOC_UNIDADE

        public string? NCM { get; set; }// DadosOmni.pncm = LOC_NCM

        public string? CEST { get; set; }//   DadosOmni.pCEST = LOC_CEST

        public string? RCTL { get; set; }// DadosOmni.psku = LOC_RCTL

        public double? AliquotaFCP { get; set; }

        public string? difalIsento { get; set; }


    }
}
