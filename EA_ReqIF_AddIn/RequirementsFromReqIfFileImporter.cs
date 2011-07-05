using System;
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
			// TODO: interact with EA and create the model here!
			subImporter = null;
		}
	}
}
