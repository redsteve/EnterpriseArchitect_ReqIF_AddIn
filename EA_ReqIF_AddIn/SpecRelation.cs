using System;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// This class represents an ReqIF element <c>&lt;SPEC-RELATION&gt;</c>...<c>&lt;/SPEC-RELATION&gt;</c>.
	/// See OMG ReqIF specification chapter 10.8.41 for more information.
	/// </summary>
	public class SpecRelation : Identifiable
	{
		private string specRelationTypeIdentifier;
		private string sourceSpecObjectIdentifier;
		private string targetSpecObjectIdentifier;
		private string alternativeId;
		
		#region Properties
		public string SpecRelationTypeIdentifier {
			get { return specRelationTypeIdentifier; }
			set { specRelationTypeIdentifier = value; }
		}
		
		public string SourceSpecObjectIdentifier {
			get { return sourceSpecObjectIdentifier; }
			set { sourceSpecObjectIdentifier = value; }
		}

		public string TargetSpecObjectIdentifier {
			get { return targetSpecObjectIdentifier; }
			set { targetSpecObjectIdentifier = value; }
		}
		#endregion
		
		public SpecRelation()
		{
		}
	}
}
