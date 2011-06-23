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
			Package newPackage =
				(Package)rootPackage.Packages.AddNew(packageName, "Package");
			
			if (newPackage == null)
			{
				throw new Exception();
			}
			
			if (! newPackage.Update())
			{
				throw new Exception(newPackage.GetLastError());
			}
			
			return newPackage;
		}
		
		public Requirement createRequirement(Package parentPackage, string requirementName)
		{
			Requirement requirement =
				(Requirement)(parentPackage.Elements.AddNew(requirementName, "Requirement"));
			
			if (requirement == null)
			{
				throw new Exception();
			}
			
			if (! requirement.Update())
			{
				throw new Exception(requirement.GetLastError());
			}
			
			return requirement;
		}
	}
}
