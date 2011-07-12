using System;
using System.Runtime.Serialization;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// The exception that is thrown when an error occurs while Enterprise Architect API.
	/// </summary>
	public class EnterpriseArchitectInteropFailure : ApplicationException
	{
		public EnterpriseArchitectInteropFailure() : base("An error has occured while parsing the file!")
		{
		}
		
		public EnterpriseArchitectInteropFailure(string message) : base(message)
		{
		}
		
		public EnterpriseArchitectInteropFailure(SerializationInfo info, StreamingContext context) :
			base(info, context)
		{
		}
		
		public EnterpriseArchitectInteropFailure(string message, Exception innerException) :
			base(message, innerException)
		{
		}
	}
}
