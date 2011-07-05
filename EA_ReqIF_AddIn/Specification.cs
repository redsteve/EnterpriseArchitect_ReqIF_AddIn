using System;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// This class represents an ReqIF element <c>&lt;SPECIFICATION&gt;</c>...<c>&lt;/SPECIFICATION&gt;</c>.
	/// See OMG ReqIF specification chapter 10.8.37 for more information.
	/// </summary>
	public class Specification : Identifiable
	{
		private string alternativeId;
		private string specificationTypeIdentifier;
		
		public string AlternativeId {
			get { return alternativeId; }
			set { alternativeId = value; }
		}
		
		public string SpecificationTypeIdentifier {
			get { return specificationTypeIdentifier; }
			set { specificationTypeIdentifier = value; }
		}
		
		public Specification()
		{
		}
	}
}
