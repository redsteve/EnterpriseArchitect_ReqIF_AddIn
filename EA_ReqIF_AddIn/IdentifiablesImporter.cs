using System;
using System.Collections;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// This is the abstract base class of all specialiced xxxImporter classes.
	/// </summary>
	public abstract class IdentifiablesImporter : BasicReqIfFileImporter
	{
		#region Constants
		private const string identifierAttributeName = "IDENTIFIER";
		private const string descriptionAttributeName = "DESC";
		private const string longNameAttributeName = "LONG-NAME";
		private const string lastChangeAttributeName = "LAST-CHANGE";
		#endregion
		
		private SortedList identifiables;
		protected Identifiable identifiableElementUnderConstruction;
		
		public IdentifiablesImporter(ref SortedList identifiables)
		{
			if (identifiables == null)
				throw new ArgumentNullException("identifiables");
			this.identifiables = identifiables;
		}
		
		public override void ProcessTextNode(string text)
		{
			throw new NotImplementedException("Text node must be processed in derived class!");
		}
		
		public override void ProcessElementStartNode(string name)
		{
			throw new NotImplementedException("Element start node '" + name +
			                                  "' must be processed in derived class!");
		}
		
		public override void ProcessElementEndNode(string name)
		{
			throw new NotImplementedException("Element end node '" + name +
			                                  "' must be processed in derived class!");
		}
		
		public override void ProcessAttribute(string name, string attribValue)
		{
			bool attributeWasProcessedBySubImporter = PassAttributeToSubImporter(name, attribValue);
			if (attributeWasProcessedBySubImporter)
				return;
			
			switch (name)
			{
				case identifierAttributeName:
					identifiableElementUnderConstruction.Identifier = attribValue;
					break;
					
				case descriptionAttributeName:
					identifiableElementUnderConstruction.Description = attribValue;
					break;
					
				case longNameAttributeName:
					identifiableElementUnderConstruction.LongName = attribValue;
					break;
					
				case lastChangeAttributeName:
					identifiableElementUnderConstruction.LastChange = ConvertStringifiedDateTime(attribValue);
					break;
					
				default:
					throw new ParserFailureException(unexpectedAttributeError + name + "'.");
			}
		}
		
		protected void FinalizeIdentifiableElementUnderConstruction()
		{
			if (((object)identifiableElementUnderConstruction) != null &&
			   identifiableElementUnderConstruction.Identifier != string.Empty)
			{
				identifiables.Add(identifiableElementUnderConstruction.Identifier,
				                  identifiableElementUnderConstruction);
			}
		}
	}
}
