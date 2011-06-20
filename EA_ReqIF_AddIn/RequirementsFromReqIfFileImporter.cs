using System;
using EA;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// Description of RequirementsIntoModelImporter.
	/// </summary>
	public class RequirementsFromReqIfFileImporter : IReqIfParserCallbackReceiver
	{
		private enum ProcessingStage
		{
			Start,
			ProcessingReqIfDocument,
			ProcessingReqIfHeader,
		}
		
		private ProcessingStage stage;
		
		public RequirementsFromReqIfFileImporter()
		{
			stage = ProcessingStage.Start;
		}
		
		public void ProcessElementStartNode(string name)
		{
			switch (name)
			{
				case "REQ-IF":
					EnteringReqIfDocument();
					break;
					
				case "REQ-IF-HEADER":
					EnteringReqIfHeader();
					break;
			}
		}
		
		public void ProcessTextNode(string name)
		{
			// throw new NotImplementedException();
		}
		
		public void ProcessElementEndNode(string name)
		{
			switch (name)
			{
				case "REQ-IF-HEADER":
					LeavingReqIfHeader();
					break;
					
				case "REQ-IF":
					LeavingReqIfDocument();
					break;
			}
		}
		
		private void EnteringReqIfDocument()
		{
			switch (stage)
			{
				case ProcessingStage.Start:
					stage = ProcessingStage.ProcessingReqIfDocument;
					break;
					
				default:
					throw new InvalidOperationException();
					
			}
		}
		
		private void LeavingReqIfDocument()
		{
			switch (stage)
			{
				case ProcessingStage.Start:
					stage = ProcessingStage.ProcessingReqIfDocument;
					break;
					
				default:
					throw new InvalidOperationException();
					
			}
		}
		
		private void EnteringReqIfHeader()
		{
			switch (stage)
			{
				case ProcessingStage.ProcessingReqIfDocument:
					stage = ProcessingStage.ProcessingReqIfHeader;
					break;
					
				default:
					throw new InvalidOperationException();
					
			}
		}
		
		private void LeavingReqIfHeader()
		{
			switch (stage)
			{
				case ProcessingStage.ProcessingReqIfHeader:
					stage = ProcessingStage.ProcessingReqIfDocument;
					break;
					
//				default:
//					throw new InvalidOperationException();
					
			}
		}
	}
}
