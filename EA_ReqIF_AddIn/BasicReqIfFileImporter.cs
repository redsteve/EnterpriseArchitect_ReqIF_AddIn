using System;
using System.Globalization;
using EA;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// This is the abstract base class of all concrete importer classes.
	/// </summary>
	public abstract class BasicReqIfFileImporter : IReqIfParserCallbackReceiver
	{
		private const string xsdDateTimeFormat = "yyyy-MM-ddThh:mm:sszzz";
		
		protected IReqIfParserCallbackReceiver subImporter;

		protected BasicReqIfFileImporter()
		{
			subImporter = null;
		}
		
		public abstract void ProcessElementStartNode(string name);
		public abstract void ProcessAttribute(string name, string value);
		public abstract void ProcessTextNode(string text);
		public abstract void ProcessElementEndNode(string name);
		
		protected void PassElementStartNodeToSubImporter(string name)
		{
			if (subImporter != null)
			{
				subImporter.ProcessElementStartNode(name);
			}
		}

		protected void PassAttributeToSubImporter(string name, string value)
		{
			if (subImporter != null)
			{
				subImporter.ProcessAttribute(name, value);
			}
		}

		protected void PassTextNodeToSubImporter(string text)
		{
			if (subImporter != null)
			{
				subImporter.ProcessTextNode(text);
			}
		}
		
		protected void PassElementEndNodeToSubImporter(string name)
		{
			if (subImporter != null)
			{
				subImporter.ProcessElementEndNode(name);
			}
		}
		
		protected static void SetElementsCreatedAndModifiedTimeStamps(Package package, string text)
		{
			CultureInfo formatProvider = CultureInfo.InvariantCulture;
			DateTime creationTime = DateTime.ParseExact(text, xsdDateTimeFormat, formatProvider);
			package.Created = creationTime;
			package.Modified = creationTime;
		}
				
		protected static void AddTaggedValueToElement(Element element, string valueName,
		                                              string valueType, string value)
		{
			TaggedValue taggedValue =
				(TaggedValue)element.TaggedValues.AddNew(valueName, valueType);
			
			if (taggedValue == null)
			{
				throw new Exception("Adding a tagged value '" + valueName + "' to an element failed.");
			}
			
			taggedValue.Value = value;
			
			if (! taggedValue.Update())
			{
				throw new Exception(taggedValue.GetLastError());
			}
			
			element.TaggedValues.Refresh();
		}
	}
}