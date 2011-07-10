using System;
using System.Windows.Forms;
using EA;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// This is the main importer for ReqIF files.
	/// </summary>
	public class RequirementsFromReqIfFileImporter : BasicReqIfFileImporter
	{
		private Package currentPackage;
		
		public RequirementsFromReqIfFileImporter(Package rootPackage)
		{
			this.currentPackage = rootPackage;
		}
		
		public override void ProcessElementStartNode(string name)
		{
			switch (name)
			{
				case "REQ-IF-HEADER":
					EnteringReqIfHeader();
					break;

				case "REQ-IF-CONTENT":
					EnteringReqIfContent();
					break;
					
				default:
					PassElementStartNodeToSubImporter(name);
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
		
		public override void ProcessElementEndNode(string name)
		{
			switch (name)
			{
				case "REQ-IF-HEADER":
					LeavingReqIfHeader();
					break;
					
				case "REQ-IF-CONTENT":
					LeavingReqIfContent();
					break;
					
				default:
					PassElementEndNodeToSubImporter(name);
					break;
			}
		}
		
		private void EnteringReqIfHeader()
		{
			subImporter = (IReqIfParserCallbackReceiver)new ReqIfHeaderImporter(currentPackage);
		}
		
		private void LeavingReqIfHeader()
		{
			currentPackage = ((ReqIfHeaderImporter)subImporter).RequirementsPackage;
			subImporter = null;
		}
		
		private void EnteringReqIfContent()
		{
			subImporter = (IReqIfParserCallbackReceiver)new ReqIfContentImporter();
		}
		
		private void LeavingReqIfContent()
		{
			ReqIfContentImporter reqIfContentImporter = (ReqIfContentImporter)subImporter;
			BuildModelFromImportedReqIfContent(reqIfContentImporter);
			subImporter = null;
		}
		
		private void BuildModelFromImportedReqIfContent(ReqIfContentImporter reqIfContentImporter)
		{
			if (reqIfContentImporter == null)
				throw new ArgumentNullException("reqIfContentImporter");
			
			ModelBuilder modelBuilder = CreateModelBuilder(reqIfContentImporter);
			modelBuilder.Build(currentPackage);
		}

		ModelBuilder CreateModelBuilder(ReqIfContentImporter reqIfContentImporter)
		{
			if (reqIfContentImporter == null)
				throw new ArgumentNullException("reqIfContentImporter");
			
			ModelBuilder modelBuilder = new ModelBuilder();
			
			modelBuilder.SetSpecifications(reqIfContentImporter.Specifications);
			modelBuilder.SetSpecificationTypes(reqIfContentImporter.SpecificationTypes);
			modelBuilder.SetSpecificationObjects(reqIfContentImporter.SpecificationObjects);
			modelBuilder.SetSpecificationRelations(reqIfContentImporter.SpecificationRelations);
			
			return modelBuilder;
		}
	}
}
