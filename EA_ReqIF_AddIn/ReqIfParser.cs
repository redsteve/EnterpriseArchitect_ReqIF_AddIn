/*
 * $Id:$
 */

using System;
using System.Xml;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// This class represents the Requirements Interchange Format (ReqIF) Parser.
	/// </summary>
	public sealed class ReqIfParser
	{
		private XmlReader xmlReader;
		
		/// <summary>
		/// An initialization constructor.
		/// </summary>
		/// <param name="filename">A string containing the path and the name of the RIF file.</param>
		public ReqIfParser(ref String filename)
		{
			checkFilenameArgument(ref filename);
			XmlReaderSettings settings = retrieveXmlReaderSettings();
			
			xmlReader = XmlReader.Create(filename, settings);
		}

		public void parse(IReqIfParserCallbackReceiver callbackReceiver)
		{
			if (xmlReader != null)
			{
				while (xmlReader.Read())
				{
					System.Console.WriteLine(xmlReader.Name);
				}
			}
		}
		
		private void checkFilenameArgument(ref String filename)
		{
			if (filename == null) {
				throw new System.ArgumentNullException("The filename must not be null!");
			}
			if (filename.Length == 0) {
				throw new System.ArgumentException("The filename must not be empty!");
			}
		}

		private XmlReaderSettings retrieveXmlReaderSettings()
		{
			XmlReaderSettings settings = new XmlReaderSettings();
			settings.ConformanceLevel = ConformanceLevel.Fragment;
			settings.IgnoreWhitespace = true;
			settings.IgnoreComments = true;
			return settings;
		}
	}
}
