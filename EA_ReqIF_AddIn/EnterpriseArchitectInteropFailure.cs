using System;
using System.Runtime.Serialization;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// The exception that is thrown when an error occurs while Enterprise Architect API is invoked
	/// by thie Add-In.
	/// </summary>
	public class EnterpriseArchitectInteropFailure : ApplicationException
	{
		/// <summary>
		/// Initializes a new instance of the EnterpriseArchitectInteropFailure class with default properties.
		/// </summary>
		public EnterpriseArchitectInteropFailure() : base("An error has occured while Enterprise Architect API was invoked!")
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the EnterpriseArchitectInteropFailure class with a specified error message.
		/// </summary>
		/// <param name="message">A message that describes the error.</param>
		public EnterpriseArchitectInteropFailure(string message) : base(message)
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the EnterpriseArchitectInteropFailure class with serialized data.
		/// </summary>
		/// <param name="info">The object that holds the serialized object data.</param>
		/// <param name="context">The contextual information about the source or destination.</param>
		public EnterpriseArchitectInteropFailure(SerializationInfo info, StreamingContext context) :
			base(info, context)
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the EnterpriseArchitectInteropFailure class with a specified error message
		/// and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception. If the
		/// innerException parameter is not a null reference, the current exception is raised in a catch block
		/// that handles the inner exception.</param>
		public EnterpriseArchitectInteropFailure(string message, Exception innerException) :
			base(message, innerException)
		{
		}
	}
}
