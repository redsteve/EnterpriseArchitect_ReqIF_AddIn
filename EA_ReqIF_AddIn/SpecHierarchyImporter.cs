using System;
using System.Collections;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// Objects of this class are responsible for importing the parts of a ReqIF file between
	/// XML nodes <c>&lt;CHILDREN&gt;</c> and <c>&lt;/CHILDRENY&gt;</c>.
	/// </summary>
	public class SpecHierarchyImporter : IdentifiablesImporter
	{
		#region Constants
		private const string isEditableAttributeName = "IS-EDITABLE";
		private const string isTableInternalAttributeName = "IS-TABLE-INTERNAL";
		private const string childrenNodeName = "CHILDREN";
		private const string specHierarchyNodeName = "SPEC-HIERARCHY";
		private const string alternativeIdNodeName = "ALTERNATIVE-ID";
		private const string objectNodeName = "OBJECT";
		private const string specObjectRefNodeName = "SPEC-OBJECT-REF";
		private const string editableAttsNodeName = "EDITABLE-ATTS";
		#endregion
		
		private enum ProcessingElement
		{
			Undefined,
			SpecHierarchy,
			AlternativeId,
			Children,
			Object,
			SpecObjectReference
		}
		
		private ProcessingElement processingElement;
		private bool isImportCompleted;
		
		public SpecHierarchyImporter(ref SortedList specHierarchies) : base(ref specHierarchies)
		{
			processingElement = ProcessingElement.Undefined;
			isImportCompleted = false;
		}

		public override void ProcessTextNode(string text)
		{	
			if (HasSubImporter())
			{
				SpecHierarchyImporter specHierarchySubImporter = (SpecHierarchyImporter)subImporter;
				if (! specHierarchySubImporter.IsImportCompleted())
				{
					PassTextNodeToSubImporter(text);
					return;
				}
			}
			
			if (processingElement == ProcessingElement.SpecObjectReference)
			{
				((SpecHierarchy)identifiableElementUnderConstruction).SpecObjectReference = text;
			} else {
				PassTextNodeToSubImporter(text);
			}
		}
		
		public override void ProcessAttribute(string name, string attribValue)
		{
			if (HasSubImporter())
			{
				SpecHierarchyImporter specHierarchySubImporter = (SpecHierarchyImporter)subImporter;
				if (! specHierarchySubImporter.IsImportCompleted())
				{
					PassAttributeToSubImporter(name, attribValue);
					return;
				}
			}
			
			switch (name)
			{
				case isEditableAttributeName:
					((SpecHierarchy)identifiableElementUnderConstruction).IsEditable = true;
					break;
					
				case isTableInternalAttributeName:
					((SpecHierarchy)identifiableElementUnderConstruction).IsTableInternal = true;
					break;
					
				default:
					base.ProcessAttribute(name, attribValue);
					break;
			}
		}
		
		public override void ProcessElementStartNode(string name)
		{
			if (HasSubImporter())
			{
				SpecHierarchyImporter specHierarchySubImporter = (SpecHierarchyImporter)subImporter;
				if (! specHierarchySubImporter.IsImportCompleted())
				{
					PassElementStartNodeToSubImporter(name);
					return;
				}
			}
			
			switch (name)
			{
				case specHierarchyNodeName:
					processingElement = ProcessingElement.SpecHierarchy;
					identifiableElementUnderConstruction = new SpecHierarchy();
					break;
					
				case childrenNodeName:
					if (HasSubImporter())
					{
						SpecHierarchyImporter specHierarchySubImporter = (SpecHierarchyImporter)subImporter;
						if (! specHierarchySubImporter.IsImportCompleted())
							PassElementStartNodeToSubImporter(name);
					} else {
						if (processingElement == ProcessingElement.SpecHierarchy)
						{
							processingElement = ProcessingElement.Children;
							CreateSubImporterForChildElements();
						}
					}
					break;
					
				case objectNodeName:
					if (processingElement == ProcessingElement.SpecHierarchy)
						processingElement = ProcessingElement.Object;
					break;
					
				case specObjectRefNodeName:
					if (processingElement == ProcessingElement.Object)
						processingElement = ProcessingElement.SpecObjectReference;
					break;
					
				case alternativeIdNodeName:
					if (processingElement == ProcessingElement.SpecHierarchy)
						processingElement = ProcessingElement.AlternativeId;
					break;
					
				default:
					throw new ParserFailureException(unexpectedElementNodeErrorText + name + "'.");
			}
		}
		
		public override void ProcessElementEndNode(string name)
		{
			if (HasSubImporter())
			{
				SpecHierarchyImporter specHierarchySubImporter = (SpecHierarchyImporter)subImporter;
				if (! specHierarchySubImporter.IsImportCompleted())
				{
					PassElementEndNodeToSubImporter(name);
					return;
				}
			}
			
			switch (name)
			{
				case alternativeIdNodeName:
					if (processingElement == ProcessingElement.AlternativeId)
						processingElement = ProcessingElement.SpecHierarchy;
					break;
					
				case specObjectRefNodeName:
					if (processingElement == ProcessingElement.SpecObjectReference)
						processingElement = ProcessingElement.Object;
					break;
					
				case objectNodeName:
					if (processingElement == ProcessingElement.Object)
						processingElement = ProcessingElement.SpecHierarchy;
					break;
					
				case childrenNodeName:
					if (HasSubImporter())
					{
						SpecHierarchyImporter specHierarchySubImporter = (SpecHierarchyImporter)subImporter;
						if (! specHierarchySubImporter.IsImportCompleted())
						{
							PassElementEndNodeToSubImporter(name);
						} else {
							if (processingElement == ProcessingElement.Children)
							{
								processingElement = ProcessingElement.SpecHierarchy;
								subImporter = null;
							}
						}
					} else {
						if (processingElement == ProcessingElement.Children)
							processingElement = ProcessingElement.SpecHierarchy;
					}
					break;
					
				case specHierarchyNodeName:
					if (processingElement == ProcessingElement.SpecHierarchy)
					{
						processingElement = ProcessingElement.Undefined;
						FlagImportAsCompleted();
						FinalizeIdentifiableElementUnderConstruction();
					}
					break;
					
				default:
					throw new ParserFailureException(unexpectedElementNodeErrorText + name + "'.");
			}
		}
		
		private void CreateSubImporterForChildElements()
		{
			SpecHierarchy specHierarchy = ((SpecHierarchy)identifiableElementUnderConstruction);
			specHierarchy.NestedSpecHierarchies = new SortedList();
			SortedList nestedSpecHierarchies = specHierarchy.NestedSpecHierarchies;
			subImporter = new SpecHierarchyImporter(ref nestedSpecHierarchies);
		}
		
		public bool IsImportCompleted()
		{
			if (HasSubImporter())
			{
				return false;
			}
			return isImportCompleted;
		}
		
		protected void FlagImportAsCompleted()
		{
			isImportCompleted = true;
		}
	}
}
