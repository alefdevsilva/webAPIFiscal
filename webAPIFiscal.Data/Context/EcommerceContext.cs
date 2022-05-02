//using Webbsys.Framework.MultiTenancy.Options;


namespace WebApiFiscal.Data.Context;

public class EcommerceContext : SimpleDbContext
{
    public EcommerceContext(TenantOptions tenantOptions)
        : base(tenantOptions.Connections["DapperAsteConnection"])
    {
    }
}
