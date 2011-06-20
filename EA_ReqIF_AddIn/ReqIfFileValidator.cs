using System;
using System.Collections;
using System.Xml;
using System.Xml.Schema;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// Description of ReqIfFileValidator.
	/// </summary>
	public class ReqIfFileValidator
	{
		private static ArrayList validationMessages = new ArrayList();
		
		public static ArrayList ValidationResultMessages
		{
			get { return validationMessages; }
		}
		
		public bool Validate(string reqIfFilename, string xsdURI)
		{
			XmlReaderSettings xmlReaderSettings = RetrieveSettingsForValidatingXmlReader(xsdURI);
			XmlReader validatingXmlReader = XmlReader.Create(reqIfFilename, xmlReaderSettings);
			
			while(validatingXmlReader.Read())
			{ }
			
			return true;
		}
		
		protected XmlReaderSettings RetrieveSettingsForValidatingXmlReader(string xsdFilename)
		{
			XmlReaderSettings settings = new XmlReaderSettings();
			settings.ValidationEventHandler += new ValidationEventHandler(XmlSchemaValidationCallback);
			settings.ValidationType = ValidationType.Schema;
			settings.Schemas.Add(null, xsdFilename);
			
			settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
			settings.IgnoreWhitespace = true;
			settings.IgnoreComments = true;
			settings.ConformanceLevel = ConformanceLevel.Auto;

			return settings;
		}
		
		private static void XmlSchemaValidationCallback(object sender, ValidationEventArgs args)
		{
			validationMessages.Add("[" + args.Exception.GetType().ToString() + "]: " + args.Message);
		}
	}
}
