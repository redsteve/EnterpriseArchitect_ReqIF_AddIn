using System;
using System.Runtime.Serialization;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// The exception that is thrown when a parser error occurs.
	/// </summary>
	public class ParserFailureException : ApplicationException
	{
		public ParserFailureException() : base("An error has occured while parsing the file!")
		{
		}
		
		public ParserFailureException(string message) : base(message)
		{
		}
		
		public ParserFailureException(SerializationInfo info, StreamingContext context) :
			base(info, context)
		{
		}
		
		public ParserFailureException(string message, Exception innerException) :
			base(message, innerException)
		{
		}
	}
}
