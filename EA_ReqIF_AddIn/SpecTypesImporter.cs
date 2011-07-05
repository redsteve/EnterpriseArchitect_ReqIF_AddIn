using System;
using System.Collections;
using System.Diagnostics;
using EA;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// Objects of this class are responsible for importing the parts of a ReqIF file between
	/// XML nodes <c>&lt;SPEC-TYPES&gt;</c> and <c>&lt;/SPEC-TYPES&gt;</c>.
	/// </summary>
	public class SpecTypesImporter : IdentifiablesImporter
	{
		#region Constants
		private const string specificationTypeNodeName = "SPECIFICATION-TYPE";
		private const string specObjectTypeNodeName = "SPEC-OBJECT-TYPE";
		private const string specRelationTypeNodeName = "SPEC-RELATION-TYPE";
		private const string relationGroupTypeNodeName = "RELATION-GROUP-TYPE";
		#endregion
		
		/// <summary>
		/// The initialization constructor.
		/// <param name="specificationTypes">A reference to a hashtable to take up constructed specification types.</param>
		/// </summary>
		public SpecTypesImporter(ref Hashtable specificationTypes) : base(ref specificationTypes)
		{

		}
		
		public override void ProcessTextNode(string text)
		{
			throw new ParserFailureException(unexpectedTextNodeError);
		}
		
		public override void ProcessElementStartNode(string name)
		{
			switch (name)
			{
				case specificationTypeNodeName:
					identifiableElementUnderConstruction = new SpecificationType();
					break;
					
				case specObjectTypeNodeName:
					identifiableElementUnderConstruction = new SpecObjectType();
					break;
					
				case specRelationTypeNodeName:
					identifiableElementUnderConstruction = new SpecRelationType();
					break;
					
				case relationGroupTypeNodeName:
					identifiableElementUnderConstruction = new RelationGroupType();
					break;
					
				default:
					throw new ParserFailureException(unexpectedElementNodeErrorText + name + "'.");
			}
		}
		
		public override void ProcessElementEndNode(string name)
		{
			switch (name)
			{
				case specificationTypeNodeName:
				case specObjectTypeNodeName:
				case specRelationTypeNodeName:
				case relationGroupTypeNodeName:
					FinalizeIdentifiableElementUnderConstruction();
					break;

				default:
					throw new ParserFailureException(unexpectedElementNodeErrorText + name + "'.");
			}
		}
	}
}
