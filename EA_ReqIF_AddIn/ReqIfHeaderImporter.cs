using System;
using EA;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// Objects of this class are responsible for importing the parts of a ReqIF file between
	/// XML nodes <c>&lt;REQ-IF-HEADER&gt;</c> and <c>&lt;/REQ-IF-HEADER&gt;</c>.
	/// </summary>
	public class ReqIfHeaderImporter : BasicReqIfFileImporter
	{
		private enum ProcessingElement
		{
			Undefined,
			Comment,
			CreationTime,
			RepositoryId,
			ReqIfToolId,
			ReqIfVersion,
			SourceToolId,
			Title
		}
		
		private ProcessingElement processingElement;
		private Package requirementsPackage;
		
		public Package RequirementsPackage
		{
			get { return requirementsPackage; }
		}
		
		public ReqIfHeaderImporter(Package rootPackage)
		{
			processingElement = ProcessingElement.Undefined;
			
			if (rootPackage == null)
			{
				throw new ArgumentNullException("rootPackage, Class: ReqIfHeaderImporter");
			}

			createPackage(rootPackage);
		}
		
		private void createPackage(Package rootPackage)
		{
			EnterpriseArchitectModelElementFactory factory =
				new EnterpriseArchitectModelElementFactory();
			requirementsPackage = factory.createPackage(rootPackage, "Requirements");
			requirementsPackage.Element.Author = "<imported>";
			requirementsPackage.StereotypeEx = "ExchangeDocument";
			if (! requirementsPackage.Update())
			{
				throw new ParserFailureException(requirementsPackage.GetLastError());
			}
		}
		
		public override void ProcessElementStartNode(string name)
		{
			switch (name)
			{
				case "COMMENT":
					processingElement = ProcessingElement.Comment;
					break;
					
				case "CREATION-TIME":
					processingElement = ProcessingElement.CreationTime;
					break;
					
				case "REPOSITORY-ID":
					processingElement = ProcessingElement.RepositoryId;
					break;
					
				case "REQ-IF-TOOL-ID":
					processingElement = ProcessingElement.ReqIfToolId;
					break;
					
				case "REQ-IF-VERSION":
					processingElement = ProcessingElement.ReqIfVersion;
					break;
					
				case "SOURCE-TOOL-ID":
					processingElement = ProcessingElement.SourceToolId;
					break;
					
				case "TITLE":
					processingElement = ProcessingElement.Title;
					break;
					
				default:
					throw new ParserFailureException("Unexpected or unknown element node: " + name + ".");
			}
		}
		
		public override void ProcessTextNode(string text)
		{
			switch (processingElement)
			{
				case ProcessingElement.Comment:
					requirementsPackage.Notes = text;
					break;
					
				case ProcessingElement.CreationTime:
					DateTime createAndModifiedDateTime = ConvertStringifiedDateTime(text);
					SetElementsCreatedAndModifiedTimeStamps(requirementsPackage, createAndModifiedDateTime);
					break;
					
				case ProcessingElement.RepositoryId:
					AddTaggedValueToElement(requirementsPackage.Element, "repositoryId", "String", text);
					break;
					
				case ProcessingElement.ReqIfToolId:
					AddTaggedValueToElement(requirementsPackage.Element, "reqIfToolId", "String", text);
					break;
					
				case ProcessingElement.ReqIfVersion:
					AddTaggedValueToElement(requirementsPackage.Element, "reqIfVersion", "String", text);
					break;
					
				case ProcessingElement.SourceToolId:
					AddTaggedValueToElement(requirementsPackage.Element, "sourceToolId", "String", text);
					break;
					
				case ProcessingElement.Title:
					requirementsPackage.Name = text;
					break;
					
				default:
					throw new ParserFailureException("Unexpected or unknown text node: " + text + ".");
			}
			
			if (! requirementsPackage.Update())
			{
				throw new ParserFailureException(requirementsPackage.GetLastError());
			}
		}

		public override void ProcessElementEndNode(string name)
		{
			// Nothing to do here!
		}
		
		public override void ProcessAttribute(string name, string value)
		{
			switch (name)
			{
				case "IDENTIFIER":
					AddTaggedValueToElement(requirementsPackage.Element, "identifier", "String", value);
					break;
					
				default:
					throw new ParserFailureException("Unexpected or unknown attribute: " + name + ".");
			}
		}
	}
}
