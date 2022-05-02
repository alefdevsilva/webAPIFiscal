﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApiFiscal.Dominio.Model
{
    [Table("TBL_IVA_LOJA_X")]
    [Index(nameof(Tec), Name = "TEC")]
    [Index(nameof(Tec), nameof(Sigla), nameof(Data1), Name = "TEC_UFD_DATA1")]
    [Index(nameof(Tec), nameof(Sigla), nameof(SiglaDestino), nameof(Data1), Name = "TEC_UFO_UFD_DATA1")]
    [Index(nameof(Tec), nameof(Sigla), nameof(SiglaDestino), nameof(Data1), Name = "teste")]
    public partial class TblIvaLojaX
    {
        [Column("TEC")]
        [StringLength(10)]
        public string Tec { get; set; }
        [Column("NOMETEC")]
        [StringLength(200)]
        public string Nometec { get; set; }
        [Column("ICMS", TypeName = "money")]
        public decimal? Icms { get; set; }
        [Column("IPI", TypeName = "money")]
        public decimal? Ipi { get; set; }
        [Column("IIMPO", TypeName = "money")]
        public decimal? Iimpo { get; set; }
        [Column("ID_ALIQUOTA")]
        [StringLength(4)]
        public string IdAliquota { get; set; }
        [Column("SIGLA")]
        [StringLength(2)]
        public string Sigla { get; set; }
        [Column("IVA_AJUSTADO", TypeName = "money")]
        public decimal? IvaAjustado { get; set; }
        [Column("ATUALIZADO_WEB")]
        [StringLength(1)]
        public string AtualizadoWeb { get; set; }
        [Column("CST")]
        [StringLength(3)]
        public string Cst { get; set; }
        [Column("IVA_ST", TypeName = "money")]
        public decimal? IvaSt { get; set; }
        [Column("ALIQICMS", TypeName = "money")]
        public decimal? Aliqicms { get; set; }
        [Column("ALIQICMS_INTER", TypeName = "money")]
        public decimal? AliqicmsInter { get; set; }
        [Column("CST_L")]
        [StringLength(4)]
        public string CstL { get; set; }
        [Column("CTM")]
        [StringLength(4)]
        public string Ctm { get; set; }
        [Column("SIGLA_DESTINO")]
        [StringLength(2)]
        public string SiglaDestino { get; set; }
        [Column("CFOP_DESTINO")]
        [StringLength(5)]
        public string CfopDestino { get; set; }
        [Column("TEM_PROTOCOLO")]
        [StringLength(1)]
        public string TemProtocolo { get; set; }
        [Column("DATA1", TypeName = "smalldatetime")]
        public DateTime? Data1 { get; set; }
        [Column("DATA2", TypeName = "smalldatetime")]
        public DateTime? Data2 { get; set; }
        [Column("CST_ICMS_ORIGEM")]
        [StringLength(2)]
        public string CstIcmsOrigem { get; set; }
        [Column("CST_ICMS_DESTINO")]
        [StringLength(2)]
        public string CstIcmsDestino { get; set; }
        [Column("OBSLEGAL")]
        [StringLength(200)]
        public string Obslegal { get; set; }
        [Column("USUARIO")]
        [StringLength(10)]
        public string Usuario { get; set; }
        [Column("SDATAHORA")]
        [StringLength(16)]
        public string Sdatahora { get; set; }
        [Column("DATA", TypeName = "smalldatetime")]
        public DateTime? Data { get; set; }
        [StringLength(8)]
        public string Hora { get; set; }
        [Column("ALIQICMS_import", TypeName = "money")]
        public decimal? AliqicmsImport { get; set; }
        [Column("IVA_IMPROT", TypeName = "money")]
        public decimal? IvaImprot { get; set; }
        [Column("CST_COFINS_SAIDA")]
        [StringLength(2)]
        public string CstCofinsSaida { get; set; }
        [Column("CST_COFINS_entrada")]
        [StringLength(2)]
        public string CstCofinsEntrada { get; set; }
        [Column("CST_PIS_saida")]
        [StringLength(2)]
        public string CstPisSaida { get; set; }
        [Column("CST_PIS_entrada")]
        [StringLength(2)]
        public string CstPisEntrada { get; set; }
        [Column("CEST")]
        [StringLength(7)]
        public string Cest { get; set; }
        [Key]
        [Column("ID")]
        public int Id { get; set; }
    }
}