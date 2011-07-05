using System;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// This class represents an ReqIF element <c>&lt;SPEC-OBJECT&gt;</c>...<c>&lt;/SPEC-OBJECT&gt;</c>.
	/// See OMG ReqIF specification chapter 10.8.43 for more information.
	/// </summary>
	public class SpecObject : Identifiable
	{
		private string alternativeId;
		private string specObjectTypeIdentifier;
		
		public string AlternativeId {
			get { return alternativeId; }
			set { alternativeId = value; }
		}
		
		public string SpecObjectTypeIdentifier {
			get { return specObjectTypeIdentifier; }
			set { specObjectTypeIdentifier = value; }
		}
		
		public SpecObject()
		{
		}
	}
}
