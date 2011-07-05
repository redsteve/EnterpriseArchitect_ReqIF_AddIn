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
		private const string specificationNodeName = "SPECIFICATION";
		private const string alternativeIdNodeName = "ALTERNATIVE-ID";
		private const string valuesNodeName = "VALUES";
		private const string typeNodeName = "TYPE";
		private const string specificationTypeRefNodeName = "SPECIFICATION-TYPE-REF";
		private const string childrenNodeName = "CHILDREN";
		
		private bool ignoreChildren;
		
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
		
		public SpecificationsImporter(ref Hashtable specifications) : base(ref specifications)
		{
			ignoreChildren = false;
			processingElement = ProcessingElement.Undefined;
		}
		
//		private void createPackage(Package rootPackage)
//		{
//			EnterpriseArchitectModelElementFactory factory =
//				new EnterpriseArchitectModelElementFactory();
//			specificationPackage = factory.createPackage(rootPackage, "Specification");
//			specificationPackage.Element.Author = "<imported>";
//			specificationPackage.StereotypeEx = "Specification";
//			if (! specificationPackage.Update())
//			{
//				throw new ParserFailureException(specificationPackage.GetLastError());
//			}
//		}
		
		public override void ProcessTextNode(string text)
		{
			if (processingElement == ProcessingElement.SpecificationTypeRef)
			{
				((Specification)identifiableElementUnderConstruction).SpecificationTypeIdentifier = text;
			} else {
				if (! ignoreChildren)
					throw new ParserFailureException(unexpectedTextNodeError);
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
					if (processingElement == ProcessingElement.Specification)
						processingElement = ProcessingElement.Children;
					ignoreChildren = true;
					break;
					
				default:
					if (! ignoreChildren)
						throw new ParserFailureException(unexpectedElementNodeErrorText + name + "'.");
					break;
			}
		}
		
		public override void ProcessElementEndNode(string name)
		{
			switch (name)
			{
				case specificationNodeName:
					FinalizeIdentifiableElementUnderConstruction();
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
					if (processingElement == ProcessingElement.Children)
						processingElement = ProcessingElement.Specification;
					ignoreChildren = false;
					break;
					
				default:
					if (! ignoreChildren)
						throw new ParserFailureException(unexpectedElementNodeErrorText + name + "'.");
					break;
			}
		}
	}
}
