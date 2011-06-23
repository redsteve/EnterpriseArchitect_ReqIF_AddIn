using System;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// Description of BasicReqIfFileImporter.
	/// </summary>
	public abstract class BasicReqIfFileImporter : IReqIfParserCallbackReceiver
	{
		protected IReqIfParserCallbackReceiver subImporter;
		
		protected BasicReqIfFileImporter()
		{
			subImporter = null;
		}
		
		public abstract void ProcessElementStartNode(string name);
		public abstract void ProcessAttribute(string name, string value);
		public abstract void ProcessTextNode(string name);
		public abstract void ProcessElementEndNode(string name);
		
		protected void PassElementStartNodeToSubImporter(string name)
		{
			if (subImporter != null)
			{
				subImporter.ProcessElementStartNode(name);
			}
		}

		protected void PassAttributeToSubImporter(string name, string value)
		{
			if (subImporter != null)
			{
				subImporter.ProcessAttribute(name, value);
			}
		}

		protected void PassTextNodeToSubImporter(string text)
		{
			if (subImporter != null)
			{
				subImporter.ProcessTextNode(text);
			}
		}
		
		protected void PassElementEndNodeToSubImporter(string name)
		{
			if (subImporter != null)
			{
				subImporter.ProcessElementEndNode(name);
			}
		}
	}
}