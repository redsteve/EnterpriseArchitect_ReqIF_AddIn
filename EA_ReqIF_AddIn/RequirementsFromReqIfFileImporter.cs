using System;
using EA;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// Description of RequirementsIntoModelImporter.
	/// </summary>
	public class RequirementsFromReqIfFileImporter : BasicReqIfFileImporter
	{
		private Package rootPackage;
		
		public RequirementsFromReqIfFileImporter(Package rootPackage)
		{
			this.rootPackage = rootPackage;
		}
		
		public override void ProcessElementStartNode(string name)
		{
			switch (name)
			{
				case "REQ-IF-HEADER":
					EnteringReqIfHeader();
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
					
				default:
					PassElementEndNodeToSubImporter(name);
					break;
			}
		}
		
		private void EnteringReqIfHeader()
		{
			subImporter = (IReqIfParserCallbackReceiver)new ReqIfHeaderImporter(rootPackage);
		}
		
		private void LeavingReqIfHeader()
		{
			subImporter = null;
		}
	}
}
