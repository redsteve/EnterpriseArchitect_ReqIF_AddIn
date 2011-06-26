using System;
using EA;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// Objects of this class are responsible for importing the parts of a ReqIF file between
	/// XML nodes <c>&lt;DATATYPES&gt;</c> and <c>&lt;/DATATYPES&gt;</c>.
	/// </summary>
	public class DatatypesImporter : BasicReqIfFileImporter
	{
		public DatatypesImporter()
		{

		}
		
		public override void ProcessTextNode(string text)
		{
			throw new NotImplementedException();
		}
		
		public override void ProcessElementStartNode(string name)
		{
			throw new NotImplementedException();
		}
		
		public override void ProcessElementEndNode(string name)
		{
			throw new NotImplementedException();
		}
		
		public override void ProcessAttribute(string name, string value)
		{
			throw new NotImplementedException();
		}
	}
}
