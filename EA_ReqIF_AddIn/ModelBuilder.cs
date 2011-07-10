using System;
using System.Collections;
using EA;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// Description of ModelBuilder.
	/// </summary>
	public class ModelBuilder
	{
		private SortedList specifications;
		private SortedList specificationTypes;
		private SortedList specificationObjects;
		private SortedList specificationRelations;
		
		public ModelBuilder()
		{
		}
		
		public void SetSpecifications(SortedList specifications)
		{
			this.specifications = specifications;
		}
		
		public void SetSpecificationTypes(SortedList specificationTypes)
		{
			this.specificationTypes = specificationTypes;
		}
		
		public void SetSpecificationObjects(SortedList specificationObjects)
		{
			this.specificationObjects = specificationObjects;
		}
		
		public void SetSpecificationRelations(SortedList specificationRelations)
		{
			this.specificationRelations = specificationRelations;
		}
		
		public void Build(Package rootPackage)
		{
			if (rootPackage == null)
				throw new ArgumentNullException("rootPackage");
			
			CreateSpecificationPackages(rootPackage);
		}
		
		private void CreateSpecificationPackages(Package rootPackage)
		{
			foreach (DictionaryEntry specificationEntry in specifications)
			{
				Specification specification = (Specification)specificationEntry.Value;
				Package specificationPackage = CreateSpecificationPackage(specification, rootPackage);
				AddTaggedValuesToSpecificationPackage(specification, specificationPackage);
			}
		}

		private Package CreateSpecificationPackage(Specification specification, Package rootPackage)
		{
			if ((object)specification == null)
				throw new ArgumentNullException("specification");
			
			EnterpriseArchitectModelElementFactory factory = new EnterpriseArchitectModelElementFactory();
			Package specificationPackage = factory.createPackage(rootPackage, specification.LongName);
			specificationPackage.Element.Author = "<imported>";
			specificationPackage.StereotypeEx = "Specification";
			
			if (! specificationPackage.Update())
				throw new ParserFailureException(specificationPackage.GetLastError());
			
			return specificationPackage;
		}
		
		void AddTaggedValuesToSpecificationPackage(Specification specification, Package specificationPackage)
		{
			AddTaggedValueToElement(specificationPackage.Element, "identifier", "String", specification.Identifier);
		}
		
		private static void AddTaggedValueToElement(Element element, string valueName,
		                                            string valueType, string value)
		{
			if (element == null)
				throw new ArgumentNullException("element");
			
			TaggedValue taggedValue =
				(TaggedValue)element.TaggedValues.AddNew(valueName, valueType);
			
			if (taggedValue == null)
				throw new Exception("Adding a tagged value '" + valueName + "' to an element failed.");
			
			taggedValue.Value = value;
			
			if (! taggedValue.Update())
				throw new Exception(taggedValue.GetLastError());
			
			element.TaggedValues.Refresh();
		}
	}
}
