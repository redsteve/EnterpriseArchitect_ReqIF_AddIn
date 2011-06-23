using System;
using EA;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// Description of ReqIfHeaderImporter.
	/// </summary>
	public class ReqIfHeaderImporter
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
		
		public ReqIfHeaderImporter(Package rootPackage)
		{
			processingElement = ProcessingElement.Undefined;
			
			if (rootPackage == null)
			{
				throw new Exception();
			}

			createPackage(rootPackage);
		}
		
		private void createPackage(Package rootPackage)
		{
			EnterpriseArchitectModelElementFactory factory =
				new EnterpriseArchitectModelElementFactory();
			requirementsPackage = factory.createPackage(rootPackage, "Requirements");
			requirementsPackage.StereotypeEx = "ExchangeDocument";
			if (! requirementsPackage.Update())
			{
				
			}
		}
		
		public void ProcessElementStartNode(string name)
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
					throw new InvalidOperationException();
			}
		}
		
		public void ProcessTextNode(string text)
		{
			switch (processingElement)
			{
				case ProcessingElement.Comment:
					requirementsPackage.Notes = text;
					break;
					
				case ProcessingElement.CreationTime:
					DateTime creationTime = DateTime.Parse(text);
					requirementsPackage.Created = creationTime;
					requirementsPackage.Modified = creationTime;
					break;
					
				case ProcessingElement.RepositoryId:
					break;
					
				case ProcessingElement.ReqIfToolId:
					break;
					
				case ProcessingElement.ReqIfVersion:
					break;
					
				case ProcessingElement.SourceToolId:
					break;
					
				case ProcessingElement.Title:
					requirementsPackage.Name = text;
					break;
					
				default:
					throw new InvalidOperationException();
			}
		}
	}
}
