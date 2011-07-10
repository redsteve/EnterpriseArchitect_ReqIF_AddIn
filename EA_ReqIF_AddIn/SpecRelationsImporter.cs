using System;
using System.Collections;
using EA;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// Objects of this class are responsible for importing the parts of a ReqIF file between
	/// XML nodes <c>&lt;SPEC-RELATIONS&gt;</c> and <c>&lt;/SPEC-RELATIONS&gt;</c>.
	/// </summary>
	public class SpecRelationsImporter : IdentifiablesImporter
	{
		#region Constants
		private const string specRelationNodeName = "SPEC-RELATION";
		private const string alternativeIdNodeName = "ALTERNATIVE-ID";
		private const string valuesNodeName = "VALUES";
		private const string typeNodeName = "TYPE";
		private const string sourceNodeName = "SOURCE";
		private const string targetNodeName = "TARGET";
		private const string specObjectRefNodeName = "SPEC-OBJECT-REF";
		private const string specRelationTypeRefNodeName = "SPEC-RELATION-TYPE-REF";
		#endregion
		
		private enum ProcessingElement
		{
			Undefined,
			SpecRelation,
			AlternativeId,
			Values,
			Type,
			Source,
			SourceSpecObjectRef,
			Target,
			TargetSpecObjectRef,
			SpecRelationTypeRef
		}
		
		private ProcessingElement processingElement;
		
		public SpecRelationsImporter(ref SortedList specificationRelations) : base(ref specificationRelations)
		{
			processingElement = ProcessingElement.Undefined;
		}
		
		public override void ProcessTextNode(string text)
		{
			SpecRelation specRelation = (SpecRelation)identifiableElementUnderConstruction;

			switch (processingElement)
			{
				case ProcessingElement.SourceSpecObjectRef:
					specRelation.SourceSpecObjectIdentifier = text;
					break;
					
				case ProcessingElement.TargetSpecObjectRef:
					specRelation.TargetSpecObjectIdentifier = text;
					break;
					
				case ProcessingElement.SpecRelationTypeRef:
					specRelation.SpecRelationTypeIdentifier = text;
					break;
					
				default:
					throw new ParserFailureException(unexpectedTextNodeError);
			}
		}
		
		public override void ProcessElementStartNode(string name)
		{
			switch (name)
			{	
				case specRelationNodeName:
					processingElement = ProcessingElement.SpecRelation;
					identifiableElementUnderConstruction = new SpecRelation();
					break;
					
				case alternativeIdNodeName:
					if (processingElement == ProcessingElement.SpecRelation)
						processingElement = ProcessingElement.AlternativeId;
					break;
					
				case valuesNodeName:
					if (processingElement == ProcessingElement.SpecRelation)
						processingElement = ProcessingElement.Values;
					break;
					
				case typeNodeName:
					if (processingElement == ProcessingElement.SpecRelation)
						processingElement = ProcessingElement.Type;
					break;
					
				case sourceNodeName:
					if (processingElement == ProcessingElement.SpecRelation)
						processingElement = ProcessingElement.Source;
					break;
					
				case targetNodeName:
					if (processingElement == ProcessingElement.SpecRelation)
						processingElement = ProcessingElement.Target;
					break;
					
				case specObjectRefNodeName:
					if (processingElement == ProcessingElement.Source)
						processingElement = ProcessingElement.SourceSpecObjectRef;
					else if (processingElement == ProcessingElement.Target)
						processingElement = ProcessingElement.TargetSpecObjectRef;
					break;
					
				case specRelationTypeRefNodeName:
					if (processingElement == ProcessingElement.Type)
						processingElement = ProcessingElement.SpecRelationTypeRef;
					break;
					
				default:
					throw new ParserFailureException(unexpectedElementNodeErrorText + name + "'.");
			}
		}
		
		public override void ProcessElementEndNode(string name)
		{
			switch (name)
			{
				case specRelationNodeName:
					processingElement = ProcessingElement.Undefined;
					FinalizeIdentifiableElementUnderConstruction();
					break;
					
				case alternativeIdNodeName:
					if (processingElement == ProcessingElement.AlternativeId)
						processingElement = ProcessingElement.SpecRelation;
					break;
					
				case valuesNodeName:
					if (processingElement == ProcessingElement.Values)
						processingElement = ProcessingElement.SpecRelation;
					break;
					
				case typeNodeName:
					if (processingElement == ProcessingElement.Type)
						processingElement = ProcessingElement.SpecRelation;
					break;
					
				case sourceNodeName:
					if (processingElement == ProcessingElement.Source)
						processingElement = ProcessingElement.SpecRelation;
					break;
					
				case targetNodeName:
					if (processingElement == ProcessingElement.Target)
						processingElement = ProcessingElement.SpecRelation;
					break;
					
				case specObjectRefNodeName:
					if (processingElement == ProcessingElement.SourceSpecObjectRef)
						processingElement = ProcessingElement.Source;
					else if (processingElement == ProcessingElement.TargetSpecObjectRef)
						processingElement = ProcessingElement.Target;
					break;
					
				case specRelationTypeRefNodeName:
					if (processingElement == ProcessingElement.SpecRelationTypeRef)
						processingElement = ProcessingElement.Type;
					break;
					
				default:
					throw new ParserFailureException(unexpectedElementNodeErrorText + name + "'.");
			}
		}
	}
}
