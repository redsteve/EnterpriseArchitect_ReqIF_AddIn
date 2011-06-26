using System;
using EA;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// Objects of this class are responsible for importing the parts of a ReqIF file between
	/// XML nodes <c>&lt;REQ-IF-CONTENT&gt;</c> and <c>&lt;/REQ-IF-CONTENT&gt;</c>.
	/// </summary>
	public class ReqIfContentImporter : BasicReqIfFileImporter
	{
		private Package requirementsPackage;
		
		public ReqIfContentImporter(Package requirementsPackage)
		{
			if (requirementsPackage == null)
			{
				throw new ArgumentNullException();
			}
			
			this.requirementsPackage = requirementsPackage;
		}
		
		public override void ProcessElementStartNode(string name)
		{
			switch (name)
			{
				case "DATATYPES":
					EnteringDatatypes();
					break;
					
				case "SPEC-TYPES":
					EnteringSpecTypes();
					break;
					
				case "SPEC-OBJECTS":
					EnteringSpecObjects();
					break;
					
				case "SPEC-RELATIONS":
					EnteringSpecRelations();
					break;
					
				case "SPECIFICATIONS":
					EnteringSpecifications();
					break;
					
				case "SPEC-RELATION-GROUPS":
					EnteringSpecRelationGroups();
					break;
					
				default:
					throw new ParserFailureException("Unexpected or unknown element start node: " + name + ".");
			}
		}
		
		public override void ProcessElementEndNode(string name)
		{
			switch (name)
			{
				case "DATATYPES":
					LeavingDatatypes();
					break;
					
				case "SPEC-TYPES":
					LeavingSpecTypes();
					break;
					
				case "SPEC-OBJECTS":
					LeavingSpecObjects();
					break;
					
				case "SPEC-RELATIONS":
					LeavingSpecRelations();
					break;
					
				case "SPECIFICATIONS":
					LeavingSpecifications();
					break;
					
				case "SPEC-RELATION-GROUPS":
					LeavingSpecRelationGroups();
					break;
					
				default:
					throw new ParserFailureException("Unexpected or unknown element end node: " + name + ".");
			}
		}
		
		public override void ProcessAttribute(string name, string value)
		{
			PassAttributeToSubImporter(name, value);
		}
		
		public override void ProcessTextNode(string text)
		{
			PassTextNodeToSubImporter(text);
		}
		
		private void EnteringDatatypes()
		{
			subImporter = (IReqIfParserCallbackReceiver)new DatatypesImporter();
		}
		
		private void LeavingDatatypes()
		{
			subImporter = null;
		}
		
		private void EnteringSpecTypes()
		{
			throw new NotImplementedException();
		}
		
		private void LeavingSpecTypes()
		{
			subImporter = null;
		}
		
		private void EnteringSpecObjects()
		{
			throw new NotImplementedException();
		}
		
		private void LeavingSpecObjects()
		{
			subImporter = null;
		}
		
		private void EnteringSpecRelations()
		{
			throw new NotImplementedException();
		}
		
		private void LeavingSpecRelations()
		{
			subImporter = null;
		}
		
		private void EnteringSpecifications()
		{
			subImporter = (IReqIfParserCallbackReceiver)new SpecificationsImporter(requirementsPackage);
		}
		
		private void LeavingSpecifications()
		{
			subImporter = null;
		}
		
		private void EnteringSpecRelationGroups()
		{
			throw new NotImplementedException();
		}
		
		private void LeavingSpecRelationGroups()
		{
			subImporter = null;
		}
	}
}
