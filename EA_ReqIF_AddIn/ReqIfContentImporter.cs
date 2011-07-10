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
		#region Constants
		private const string datatypesNodeName = "DATATYPES";
		private const string specTypesNodeName = "SPEC-TYPES";
		private const string specObjectsNodeName = "SPEC-OBJECTS";
		private const string specRelationsNodeName = "SPEC-RELATIONS";
		private const string specificationsNodeName = "SPECIFICATIONS";
		private const string specRelationsGroupNodeName = "SPEC-RELATION-GROUPS";
		#endregion
		
		private SortedList specifications;
		private SortedList specificationTypes;
		private SortedList specificationObjects;
		private SortedList specificationRelations;
		
		public SortedList Specifications {
			get { return specifications; }
		}

		public SortedList SpecificationTypes {
			get { return specificationTypes; }
		}
		
		public SortedList SpecificationObjects {
			get { return specificationObjects; }
		}

		public SortedList SpecificationRelations {
			get { return specificationRelations; }
		}
		
		/// <summary>
		/// The default constructor.
		/// </summary>
		public ReqIfContentImporter()
		{
			
		}
		
		public override void ProcessElementStartNode(string name)
		{
			switch (name)
			{
				case datatypesNodeName:
					EnteringDatatypes();
					break;
					
				case specTypesNodeName:
					EnteringSpecTypes();
					break;
					
				case specObjectsNodeName:
					EnteringSpecObjects();
					break;
					
				case specRelationsNodeName:
					EnteringSpecRelations();
					break;
					
				case specificationsNodeName:
					EnteringSpecifications();
					break;
					
				case specRelationsGroupNodeName:
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
				case datatypesNodeName:
				case specTypesNodeName:
				case specObjectsNodeName:
				case specRelationsNodeName:
				case specificationsNodeName:
				case specRelationsGroupNodeName:
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
			// UNDONE: implementation of DATATYPES import must be completed!
			subImporter = new DatatypesImporter();
		}
		
		private void EnteringSpecTypes()
		{
			specificationTypes = new SortedList();
			subImporter = new SpecTypesImporter(ref specificationTypes);
		}
		
		private void EnteringSpecObjects()
		{
			specificationObjects = new SortedList();
			subImporter = new SpecObjectsImporter(ref specificationObjects);
		}
		
		private void EnteringSpecRelations()
		{
			specificationRelations = new SortedList();
			subImporter = new SpecRelationsImporter(ref specificationRelations);
		}
		
		private void EnteringSpecifications()
		{
			specifications = new SortedList();
			subImporter = new SpecificationsImporter(ref specifications);
		}
		
		private void EnteringSpecRelationGroups()
		{
			// UNDONE: implementation of SPEC-RELATION-GROUPS import must be completed!
			subImporter = new SpecRelationGroupsImporter();
		}
		
		private void LeavingSubImporter()
		{
			subImporter = null;
		}
	}
}
