using System;
using System.IO;
using System.Collections;
using System.Xml;
using System.Xml.Schema;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// This class represents a validating Requirements Interchange Format (ReqIF) Parser.
	/// </summary>
	public sealed class ReqIfParser
	{
		private XmlReader xmlReader;
		private static string xsdURI = "reqif.xsd";
		private static ArrayList validationMessages = new ArrayList();
		
		/// <summary>
		/// An initialization constructor.
		/// </summary>
		/// <param name="filename">A string containing the path and the name of the ReqIF file.</param>
		/// <param name="doValidate">Set this to <c>true</c> to validate the ReqIF file.</param>
		public ReqIfParser(String filename, bool doValidate)
		{
			CheckFilenameArgument(filename);
			xmlReader = XmlTextReader.Create(filename);
			if (doValidate)
			{
				ValidateXmlDocument(filename);
			}
		}
		
		public void Parse(IReqIfParserCallbackReceiver callbackReceiver)
		{
			if (xmlReader != null)
			{
				while (xmlReader.Read())
				{
					string xmlString = xmlReader.ReadString();
				}
			}
		}

		public static ArrayList ValidationResultMessages
		{
			get { return validationMessages; }
		}
		
		private void CheckFilenameArgument(String filename)
		{
			if (filename == null) {
				throw new System.ArgumentNullException("The filename must not be null!");
			}
			if (filename == String.Empty) {
				throw new System.ArgumentException("The filename must not be empty!");
			}
		}

		private void ValidateXmlDocument(String filename)
		{
			StreamReader xsdStreamReader = new StreamReader(xsdURI);
			XmlSchema schema = new XmlSchema();
			
			schema = XmlSchema.Read(xsdStreamReader,
			                        new ValidationEventHandler(XmlSchemaValidationCallBack));
			XmlReaderSettings xmlReaderSettings = RetrieveXmlReaderSettings(schema);
			XmlReader validationXmlReader = XmlReader.Create(xmlReader, xmlReaderSettings);

			while (validationXmlReader.Read())
			{ /* Empty loop */ }
		}
		
		private XmlReaderSettings RetrieveXmlReaderSettings(XmlSchema schemaForValidation)
		{
			XmlReaderSettings settings = new XmlReaderSettings();
			settings.ValidationEventHandler += new ValidationEventHandler(XmlSchemaValidationCallBack);
			settings.Schemas = new XmlSchemaSet();
			
			settings.ValidationType = ValidationType.Schema;
			settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
			settings.Schemas.Add(schemaForValidation);
			settings.ConformanceLevel = ConformanceLevel.Auto;
			settings.IgnoreWhitespace = true;
			settings.IgnoreComments = true;

			return settings;
		}

		private XmlSchemaSet createXmlSchemaSetForValidation()
		{
			XmlSchemaSet xmlSchemaSet = new XmlSchemaSet();
			xmlSchemaSet.XmlResolver = new XmlUrlResolver();
			xmlSchemaSet.Add(null, xsdURI);
			return xmlSchemaSet;
		}

		private static void XmlSchemaValidationCallBack(object sender, ValidationEventArgs args)
		{
			validationMessages.Add("[" + args.Exception.GetType().ToString() + "]: " + args.Message);
		}
	}
}
