using Microsoft.Owin;
using Owin;
using System.Web;
using System.Web.SessionState;

[assembly: OwinStartupAttribute(typeof(SAP.Startup))]
namespace SAP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
