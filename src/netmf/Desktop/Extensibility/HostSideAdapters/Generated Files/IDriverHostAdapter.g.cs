//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PervasiveDigital.Scratch.DeploymentHelper.Extensibility.HostSideAdapters
{
    
    public class IDriverHostAdapter
    {
        internal static PervasiveDigital.Scratch.DeploymentHelper.Extensibility.IDriver ContractToViewAdapter(PervasiveDigital.Scratch.DeploymentHelper.Extensibility.Contracts.IDriverContract contract)
        {
            if ((contract == null))
            {
                return null;
            }
            if (((System.Runtime.Remoting.RemotingServices.IsObjectOutOfAppDomain(contract) != true) 
                        && contract.GetType().Equals(typeof(IDriverViewToContractHostAdapter))))
            {
                return ((IDriverViewToContractHostAdapter)(contract)).GetSourceView();
            }
            else
            {
                return new IDriverContractToViewHostAdapter(contract);
            }
        }
        internal static PervasiveDigital.Scratch.DeploymentHelper.Extensibility.Contracts.IDriverContract ViewToContractAdapter(PervasiveDigital.Scratch.DeploymentHelper.Extensibility.IDriver view)
        {
            if ((view == null))
            {
                return null;
            }
            if (view.GetType().Equals(typeof(IDriverContractToViewHostAdapter)))
            {
                return ((IDriverContractToViewHostAdapter)(view)).GetSourceContract();
            }
            else
            {
                return new IDriverViewToContractHostAdapter(view);
            }
        }
    }
}
