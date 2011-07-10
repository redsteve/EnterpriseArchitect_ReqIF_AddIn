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
		#region Constants
		private const string commentElementName = "COMMENT";
		private const string creationTimeElementName = "CREATION-TIME";
		private const string repositoryIdElementName = "REPOSITORY-ID";
		private const string reqIfTollIdElementName = "REQ-IF-TOOL-ID";
		private const string reqIfVersionElementName = "REQ-IF-VERSION";
		private const string sourceToolIdElementName = "SOURCE-TOOL-ID";
		private const string titleElementName = "TITLE";
		#endregion
		
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
			if (rootPackage == null)
				throw new ArgumentNullException("rootPackage");

			processingElement = ProcessingElement.Undefined;
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
				case commentElementName:
					processingElement = ProcessingElement.Comment;
					break;
					
				case creationTimeElementName:
					processingElement = ProcessingElement.CreationTime;
					break;
					
				case repositoryIdElementName:
					processingElement = ProcessingElement.RepositoryId;
					break;
					
				case reqIfTollIdElementName:
					processingElement = ProcessingElement.ReqIfToolId;
					break;
					
				case reqIfVersionElementName:
					processingElement = ProcessingElement.ReqIfVersion;
					break;
					
				case sourceToolIdElementName:
					processingElement = ProcessingElement.SourceToolId;
					break;
					
				case titleElementName:
					processingElement = ProcessingElement.Title;
					break;
					
				default:
					throw new ParserFailureException(unexpectedElementNodeErrorText + name + ".");
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
					throw new ParserFailureException(unexpectedTextNodeError + text + ".");
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
					throw new ParserFailureException(unexpectedAttributeError + name + ".");
			}
		}
	}
}
