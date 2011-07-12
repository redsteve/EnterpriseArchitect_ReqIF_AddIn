using System;
using EA;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// This class is a factory for Enterprise Architect model elements. It
	/// creates EA elements without exposing the instantiation logic to the
	/// client.
	/// </summary>
	public class EnterpriseArchitectModelElementFactory
	{
		public EnterpriseArchitectModelElementFactory()
		{
		}
		
		public Package createPackage(Package rootPackage, string packageName)
		{
			if (packageName == null || packageName == string.Empty)
				packageName = "n/a";
			
			Package newPackage =
				(Package)rootPackage.Packages.AddNew(packageName, "Package");
			
			if (newPackage == null)
				throw new EnterpriseArchitectInteropFailure("Adding a new package to another package failed.");
			
			if (! newPackage.Update())
				throw new EnterpriseArchitectInteropFailure(newPackage.GetLastError());
			
			return newPackage;
		}
		
		public Element CreateRequirement(Package parentPackage, string requirementName)
		{
			if (parentPackage == null)
				throw new ArgumentNullException("parentPackage");
			
			Element element =
				(Element)(parentPackage.Elements.AddNew(requirementName, "Requirement"));
			
			if (element == null)
				throw new EnterpriseArchitectInteropFailure("Adding a new requirement to a package failed.");
			
			if (! element.Update())
				throw new EnterpriseArchitectInteropFailure(element.GetLastError());
			
			return element;
		}
	}
}
