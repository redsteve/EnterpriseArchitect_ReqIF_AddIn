using System;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// This interface must be implemented by classes if they want to receive callback
	/// notifications while processing an ReqIF XML file.
	/// </summary>
	public interface IReqIfParserCallbackReceiver
	{
		/// <summary>This method is called if a start-tag of an XML element occurs during
		/// ReqIF DOM tree traversal. An element is a logical component of a DOM which
		/// either begins with a start-tag and ends with a matching end-tag, or consists
		/// only of an empty-element tag.</summary>
		/// <param name="name">A string containing the name of the element.</param>
		void ProcessElementStartNode(string name);
		
		/// <summary>This method is called if an XML attribute occurs during ReqIF DOM tree
		/// traversal, consisting of a name/value pair that exists within a start-tag or
		/// empty-element tag.</summary>
		/// <param name="name">A string containing the name of the attribute.</param> 
		/// <param name="attribValue">A string containing the value of the attribute.</param>
		void ProcessAttribute(string name, string attribValue);
		
		/// <summary>This method is called if an XML element's content (text between
		/// start-tag and end-tag) occurs during ReqIF DOM tree traversal.</summary>
		/// <param name="text">A string containing the text.</param>
		void ProcessTextNode(string text);
		
		/// <summary>This method is called if a end-tag of an XML element occurs during
		/// ReqIF DOM tree traversal.</summary>
		/// <param name="name">A string containing the name of the element.</param>
		void ProcessElementEndNode(string name);
	}
}
