using System;
using System.Collections;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// Objects of this class are responsible for importing the parts of a ReqIF file between
	/// XML nodes <c>&lt;REQ-IF-CONTENT&gt;</c> and <c>&lt;/REQ-IF-CONTENT&gt;</c>.
	/// </summary>
	public class ReqIfContentImporter : BasicReqIfFileImporter
	{
		private Package requirementsPackage;
		
		private Hashtable specifications;
		private Hashtable specificationTypes;
		private Hashtable specificationObjects;
		private Hashtable specificationRelations;
		
		public ReqIfContentImporter()
		{
			
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
			// TODO: implement import of DATATYPES.
			subImporter = new DatatypesImporter();
		}
		
		private void EnteringSpecTypes()
		{
			specificationTypes = new Hashtable();
			subImporter = new SpecTypesImporter(ref specificationTypes);
		}
		
		private void EnteringSpecObjects()
		{
			specificationObjects = new Hashtable();
			subImporter = new SpecObjectsImporter(ref specificationObjects);
		}
		
		private void EnteringSpecRelations()
		{
			specificationRelations = new Hashtable();
			subImporter = new SpecRelationsImporter(ref specificationRelations);
		}
		
		private void EnteringSpecifications()
		{
			specifications = new Hashtable();
			subImporter = new SpecificationsImporter(ref specifications);
		}
		
		private void EnteringSpecRelationGroups()
		{
			// TODO: implement import of SPEC-RELATION-GROUPS.
			subImporter = new SpecRelationGroupsImporter();
		}
		
		private void LeavingSubImporter()
		{
			subImporter = null;
		}
	}
}
