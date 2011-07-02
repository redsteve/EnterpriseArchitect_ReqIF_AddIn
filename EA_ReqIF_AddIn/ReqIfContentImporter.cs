using System;
using System.Collections;
using System.Windows.Forms;
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
		
		private Hashtable specificationTypes;
		
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
					PassElementStartNodeToSubImporter(name);
					break;
			}
		}
		
		public override void ProcessElementEndNode(string name)
		{
			switch (name)
			{
				case "DATATYPES":
				case "SPEC-TYPES":
				case "SPEC-OBJECTS":
				case "SPEC-RELATIONS":
				case "SPECIFICATIONS":
				case "SPEC-RELATION-GROUPS":
					LeavingSubImporter();
					break;
					
				default:
					PassElementEndNodeToSubImporter(name);
					break;
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
		
		private void EnteringSpecTypes()
		{
			specificationTypes = new Hashtable();
			subImporter = (IReqIfParserCallbackReceiver)new SpecTypesImporter(ref specificationTypes);
			MessageBox.Show(specificationTypes.ToString());
		}
		
		private void EnteringSpecObjects()
		{
			subImporter = (IReqIfParserCallbackReceiver)new SpecObjectsImporter();
		}
		
		private void EnteringSpecRelations()
		{
			subImporter = (IReqIfParserCallbackReceiver)new SpecRelationsImporter();
		}
		
		private void EnteringSpecifications()
		{
			subImporter = (IReqIfParserCallbackReceiver)new SpecificationsImporter(requirementsPackage);
		}
		
		private void EnteringSpecRelationGroups()
		{
			subImporter = (IReqIfParserCallbackReceiver)new SpecRelationGroupsImporter();
		}
		
		private void LeavingSubImporter()
		{
			subImporter = null;
		}
	}
}
