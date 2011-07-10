using System;
using System.Collections;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// Objects of this class are responsible for importing the parts of a ReqIF file between
	/// XML nodes <c>&lt;SPEC-OBJECTS&gt;</c> and <c>&lt;/SPEC-OBJECTS&gt;</c>.
	/// </summary>
	public class SpecObjectsImporter : IdentifiablesImporter
	{
		#region Constants
		private const string specObjectNodeName = "SPEC-OBJECT";
		private const string alternativeIdNodeName = "ALTERNATIVE-ID";
		private const string valuesNodeName = "VALUES";
		private const string typeNodeName = "TYPE";
		private const string specObjectTypeRefNodeName = "SPEC-OBJECT-TYPE-REF";
		#endregion
		
		private enum ProcessingElement
		{
			Undefined,
			SpecObject,
			AlternativeId,
			Values,
			Type,
			SpecObjectTypeRef
		}
		
		private ProcessingElement processingElement;
		
		public SpecObjectsImporter(ref SortedList specificationObjects) : base(ref specificationObjects)
		{
			processingElement = ProcessingElement.Undefined;
		}
		
		public override void ProcessTextNode(string text)
		{
			if (processingElement == ProcessingElement.SpecObjectTypeRef)
			{
				((SpecObject)identifiableElementUnderConstruction).SpecObjectTypeIdentifier = text;
			} else {
				throw new ParserFailureException(unexpectedTextNodeError);
			}
		}
		
		public override void ProcessElementStartNode(string name)
		{
			switch (name)
			{	
				case specObjectNodeName:
					processingElement = ProcessingElement.SpecObject;
					identifiableElementUnderConstruction = new SpecObject();
					break;
					
				case alternativeIdNodeName:
					if (processingElement == ProcessingElement.SpecObject)
						processingElement = ProcessingElement.AlternativeId;
					break;
					
				case valuesNodeName:
					if (processingElement == ProcessingElement.SpecObject)
						processingElement = ProcessingElement.Values;
					break;
					
				case typeNodeName:
					if (processingElement == ProcessingElement.SpecObject)
						processingElement = ProcessingElement.Type;
					break;
					
				case specObjectTypeRefNodeName:
					if (processingElement == ProcessingElement.Type)
						processingElement = ProcessingElement.SpecObjectTypeRef;
					break;
					
				default:
					throw new ParserFailureException(unexpectedElementNodeErrorText + name + "'.");
			}
		}
		
		public override void ProcessElementEndNode(string name)
		{
			switch (name)
			{
				case specObjectNodeName:
					FinalizeIdentifiableElementUnderConstruction();
					break;
					
				case alternativeIdNodeName:
					if (processingElement == ProcessingElement.AlternativeId)
						processingElement = ProcessingElement.SpecObject;
					break;
					
				case valuesNodeName:
					if (processingElement == ProcessingElement.Values)
						processingElement = ProcessingElement.SpecObject;
					break;
					
				case typeNodeName:
					if (processingElement == ProcessingElement.Type)
						processingElement = ProcessingElement.SpecObject;
					break;
					
				case specObjectTypeRefNodeName:
					if (processingElement == ProcessingElement.SpecObjectTypeRef)
						processingElement = ProcessingElement.Type;
					break;
					
				default:
					throw new ParserFailureException(unexpectedElementNodeErrorText + name + "'.");
			}
		}
	}
}
