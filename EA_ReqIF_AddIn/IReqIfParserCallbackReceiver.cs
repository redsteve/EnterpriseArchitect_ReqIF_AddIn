/*
 * $Id:$
 */
using System;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// This interface must be implemented by classes if they want to receive callback
	/// notifications while processing an ReqIF XML file.
	/// </summary>
	public interface IReqIfParserCallbackReceiver
	{
		void ProcessElementStartNode(string name);
		void ProcessTextNode(string name);
		void ProcessElementEndNode(string name);
	}
}
