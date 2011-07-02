using System;
using EA;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// Objects of this class are responsible for importing the parts of a ReqIF file between
	/// XML nodes <c>&lt;SPECIFICATIONS&gt;</c> and <c>&lt;/SPECIFICATIONS&gt;</c>.
	/// </summary>
	public class SpecificationsImporter : BasicReqIfFileImporter
	{		
		private enum ProcessingElement
		{
			Undefined,
			Specification,
			Identifier,
			LongName,
			Description,
			Type
		}
		
		private ProcessingElement processingElement;
		private Package specificationPackage;
		
		public SpecificationsImporter(Package requirementsPackage)
		{
			processingElement = ProcessingElement.Undefined;
			
			if (requirementsPackage == null)
			{
				throw new ArgumentNullException();
			}
			
			this.specificationPackage = requirementsPackage;
		}
		
		private void createPackage(Package rootPackage)
		{
			EnterpriseArchitectModelElementFactory factory =
				new EnterpriseArchitectModelElementFactory();
			specificationPackage = factory.createPackage(rootPackage, "Specification");
			specificationPackage.Element.Author = "<imported>";
			specificationPackage.StereotypeEx = "Specification";
			if (! specificationPackage.Update())
			{
				throw new ParserFailureException(specificationPackage.GetLastError());
			}
		}
		
		public override void ProcessTextNode(string text)
		{
			throw new NotImplementedException();
		}
		
		public override void ProcessElementStartNode(string name)
		{
			switch (name)
			{
				case "SPECIFICATION":
					EnteringSpecification();
					break;
					
				default:
					throw new ParserFailureException(unexpectedElementNodeError + name + ".");
			}
		}
		
		public override void ProcessElementEndNode(string name)
		{
			throw new NotImplementedException();
		}
		
		public override void ProcessAttribute(string name, string value)
		{
			throw new NotImplementedException();
		}
		
		private void EnteringSpecification()
		{
			createPackage(specificationPackage);
		}
	}
}
