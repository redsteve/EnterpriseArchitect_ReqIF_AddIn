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
			Type
		}
		
		private ProcessingElement processingElement;
		private Package requirementsPackage;
		
		public SpecificationsImporter(Package requirementsPackage)
		{
			processingElement = ProcessingElement.Undefined;
			
			if (requirementsPackage == null)
			{
				throw new ArgumentNullException();
			}
			
			this.requirementsPackage = requirementsPackage;
		}
		
		public override void ProcessTextNode(string text)
		{
			throw new NotImplementedException();
		}
		
		public override void ProcessElementStartNode(string name)
		{
			throw new NotImplementedException();
		}
		
		public override void ProcessElementEndNode(string name)
		{
			throw new NotImplementedException();
		}
		
		public override void ProcessAttribute(string name, string value)
		{
			throw new NotImplementedException();
		}
	}
}
