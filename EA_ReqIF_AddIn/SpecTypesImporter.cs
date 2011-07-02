using System;
using System.Collections;
using EA;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// Objects of this class are responsible for importing the parts of a ReqIF file between
	/// XML nodes <c>&lt;SPEC-TYPES&gt;</c> and <c>&lt;/SPEC-TYPES&gt;</c>.
	/// </summary>
	public class SpecTypesImporter : BasicReqIfFileImporter
	{
		#region Constants
		private const string specificationTypeNodeName = "SPECIFICATION-TYPE";
		private const string specObjectTypeNodeName = "SPEC-OBJECT-TYPE";
		private const string specRelationTypeNodeName = "SPEC-RELATION-TYPE";
		private const string relationGroupTypeNodeName = "RELATION-GROUP-TYPE";
		private const string identifierAttributeName = "IDENTIFIER";
		private const string descriptionAttributeName = "DESC";
		private const string longNameAttributeName = "LONG-NAME";
		private const string lastChangeAttributeName = "LAST-CHANGE";
		#endregion
		
		private Hashtable specificationTypes;
		private Identifiable identifiableElementUnderConstruction;
		
		public SpecTypesImporter(ref Hashtable specificationTypes)
		{
			if (specificationTypes == null)
				throw new ArgumentNullException("specificationTypes; Class: SpecTypesImporter");
			this.specificationTypes = specificationTypes;
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
					identifiableElementUnderConstruction = (Identifiable)new SpecificationType();
					break;
					
				case specObjectTypeNodeName:
					identifiableElementUnderConstruction = (Identifiable)new SpecObjectType();
					break;
					
				case specRelationTypeNodeName:
					identifiableElementUnderConstruction = (Identifiable)new SpecRelationType();
					break;
					
				case relationGroupTypeNodeName:
					identifiableElementUnderConstruction = (Identifiable)new RelationGroupType();
					break;
					
				default:
					throw new ParserFailureException(unexpectedElementNodeError + name + "'.");
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
					throw new ParserFailureException(unexpectedElementNodeError + name + "'.");
			}
		}
		
		public override void ProcessAttribute(string name, string attribValue)
		{
			switch (name)
			{
				case identifierAttributeName:
					identifiableElementUnderConstruction.Identifier = attribValue;
					break;
					
				case descriptionAttributeName:
					identifiableElementUnderConstruction.Description = attribValue;
					break;
					
				case longNameAttributeName:
					identifiableElementUnderConstruction.LongName = attribValue;
					break;
					
				case lastChangeAttributeName:
					identifiableElementUnderConstruction.LastChange = ConvertStringifiedDateTime(attribValue);
					break;
					
				default:
					throw new ParserFailureException(unexpectedAttributeError + name + "'.");
			}
		}
		
		private void FinalizeIdentifiableElementUnderConstruction()
		{
			if (identifiableElementUnderConstruction != null &&
			   identifiableElementUnderConstruction.Identifier != string.Empty)
			{
				specificationTypes.Add(identifiableElementUnderConstruction.Identifier,
				                       identifiableElementUnderConstruction);
			}
		}
	}
}
