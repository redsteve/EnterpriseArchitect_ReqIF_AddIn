using System;
using System.Xml;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// Description of ReqIfDocument.
	/// </summary>
	public class ReqIfDocument : XmlDocument
	{
		private XmlDeclaration xmlDeclaration;
		
		public ReqIfDocument()
		{
			xmlDeclaration = CreateXmlDeclaration("1.0", "UTF-8", null);
		}
		
		public ReqIfDocument(string filename)
		{
			Load(filename);
		}
	}
}
