using System;
using System.Collections;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// Objects of this class are responsible for importing the parts of a ReqIF file between
	/// XML nodes <c>&lt;SPECIFICATIONS&gt;</c> and <c>&lt;/SPECIFICATIONS&gt;</c>.
	/// </summary>
	public class SpecificationsImporter : IdentifiablesImporter
	{
		#region Constants
		private const string specificationNodeName = "SPECIFICATION";
		private const string alternativeIdNodeName = "ALTERNATIVE-ID";
		private const string valuesNodeName = "VALUES";
		private const string typeNodeName = "TYPE";
		private const string specificationTypeRefNodeName = "SPECIFICATION-TYPE-REF";
		private const string childrenNodeName = "CHILDREN";
		private const string specHierarchyNodeName = "SPEC-HIERARCHY";
		#endregion
		
		private enum ProcessingElement
		{
			Undefined,
			Specification,
			AlternativeId,
			Values,
			Type,
			SpecificationTypeRef,
			Children
		}
		
		private ProcessingElement processingElement;
		
		public SpecificationsImporter(ref SortedList specifications) : base(ref specifications)
		{
			processingElement = ProcessingElement.Undefined;
		}
		
		public override void ProcessTextNode(string text)
		{
			if (processingElement == ProcessingElement.SpecificationTypeRef)
			{
				((Specification)identifiableElementUnderConstruction).SpecificationTypeIdentifier = text;
			} else {
				PassTextNodeToSubImporter(text);
			}
		}
		
		public override void ProcessElementStartNode(string name)
		{		
			switch (name)
			{
				case specificationNodeName:
					processingElement = ProcessingElement.Specification;
					identifiableElementUnderConstruction = new Specification();
					break;
					
				case alternativeIdNodeName:
					if (processingElement == ProcessingElement.Specification)
						processingElement = ProcessingElement.AlternativeId;
					break;
					
				case valuesNodeName:
					if (processingElement == ProcessingElement.Specification)
						processingElement = ProcessingElement.Values;
					break;
					
				case typeNodeName:
					if (processingElement == ProcessingElement.Specification)
						processingElement = ProcessingElement.Type;
					break;
					
				case specificationTypeRefNodeName:
					if (processingElement == ProcessingElement.Type)
						processingElement = ProcessingElement.SpecificationTypeRef;
					break;
					
				case childrenNodeName:
					{
						if (HasSubImporter())
						{
							SpecHierarchyImporter specHierarchySubImporter = (SpecHierarchyImporter)subImporter;
							if (! specHierarchySubImporter.IsImportCompleted())
								PassElementStartNodeToSubImporter(name);
						} else {
							if (processingElement == ProcessingElement.Specification)
							{
								processingElement = ProcessingElement.Children;
								CreateSubImporterForChildElements();
							}
						}
					}
					break;

				default:
					if (HasSubImporter())
					{
						PassElementStartNodeToSubImporter(name);
						break;
					} else {
						throw new ParserFailureException(unexpectedElementNodeErrorText + name + "'.");
					}
			}
		}
		
		public override void ProcessElementEndNode(string name)
		{
			switch (name)
			{
				case specificationNodeName:
					if (processingElement == ProcessingElement.Specification)
					{
						processingElement = ProcessingElement.Undefined;
						FinalizeIdentifiableElementUnderConstruction();
					}
					break;
					
				case alternativeIdNodeName:
					if (processingElement == ProcessingElement.AlternativeId)
						processingElement = ProcessingElement.Specification;
					break;
					
				case valuesNodeName:
					if (processingElement == ProcessingElement.Values)
						processingElement = ProcessingElement.Specification;
					break;
					
				case typeNodeName:
					if (processingElement == ProcessingElement.Type)
						processingElement = ProcessingElement.Specification;
					break;
					
				case specificationTypeRefNodeName:
					if (processingElement == ProcessingElement.SpecificationTypeRef)
						processingElement = ProcessingElement.Type;
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
								processingElement = ProcessingElement.Specification;
								subImporter = null;
							}
						}
					} else {
						if (processingElement == ProcessingElement.Children)
							processingElement = ProcessingElement.Specification;
					}
					break;
					
				default:
					if (HasSubImporter())
					{
						PassElementEndNodeToSubImporter(name);
						break;
					} else {
						throw new ParserFailureException(unexpectedElementNodeErrorText + name + "'.");
					}
			}
		}
		
		private void CreateSubImporterForChildElements()
		{
			Specification specification = ((Specification)identifiableElementUnderConstruction);
			specification.SpecHierarchies = new SortedList();
			SortedList nestedSpecHierarchies = specification.SpecHierarchies;
			subImporter = new SpecHierarchyImporter(ref nestedSpecHierarchies);
		}
	}
}
