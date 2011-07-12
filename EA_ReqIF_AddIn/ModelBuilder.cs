using System;
using System.Collections;
using System.Windows.Forms;
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
			EnterpriseArchitectModelElementFactory factory = new EnterpriseArchitectModelElementFactory();
			
			foreach (DictionaryEntry specificationEntry in specifications)
			{
				Specification specification = (Specification)specificationEntry.Value;
				Package specificationPackage = CreateSpecificationPackage(specification, rootPackage, factory);
				CreateRequirements(specificationPackage, specification.SpecHierarchies, factory);
				AddTaggedValuesToSpecificationPackage(specification, specificationPackage);
			}
		}
		
		private Package CreateSpecificationPackage(Specification specification,
		                                           Package rootPackage,
		                                           EnterpriseArchitectModelElementFactory factory)
		{
			if ((object)specification == null)
				throw new ArgumentNullException("specification");

			Package specificationPackage = factory.createPackage(rootPackage, specification.LongName);
			specificationPackage.Notes = specification.Description;
			specificationPackage.Element.Author = "<imported>";
			specificationPackage.StereotypeEx = "Specification";
			
			if (! specificationPackage.Update())
				throw new ParserFailureException(specificationPackage.GetLastError());
			
			return specificationPackage;
		}
		
		private void CreateRequirements(Package specificationPackage,
		                                SortedList specHierarchies,
		                                EnterpriseArchitectModelElementFactory factory)
		{
			if (specHierarchies.Count > 0)
			{
				foreach(DictionaryEntry specHierarchyEntry in specHierarchies)
				{
					SpecHierarchy specHierarchy = (SpecHierarchy)specHierarchyEntry.Value;
					SpecObject specObject = (SpecObject)specificationObjects[specHierarchy.SpecObjectReference];
					if ((object)specObject != null)
					{
						Element requirement = factory.CreateRequirement(specificationPackage, specObject.LongName);
						AddTaggedValuesToRequirement(specObject, requirement);
					} else {
						throw new ParserFailureException();
					}
				}
			}
		}
		
		void AddTaggedValuesToSpecificationPackage(Specification specification, Package specificationPackage)
		{
			AddTaggedValueToElement(specificationPackage.Element, "identifier", "String", specification.Identifier);
		}
		
		void AddTaggedValuesToRequirement(SpecObject specObject, Element requirement)
		{
			AddTaggedValueToElement(requirement, "identifier", "String", specObject.Identifier);
		}
		
		private static void AddTaggedValueToElement(Element element, string valueName,
		                                            string valueType, string value)
		{
			if (element == null)
				throw new ArgumentNullException("element");
			
			TaggedValue taggedValue =
				(TaggedValue)element.TaggedValues.AddNew(valueName, valueType);
			
			if (taggedValue == null)
				throw new EnterpriseArchitectInteropFailure("Adding a tagged value '" + valueName + "' to an element failed.");
			
			taggedValue.Value = value;
			
			if (! taggedValue.Update())
				throw new EnterpriseArchitectInteropFailure(taggedValue.GetLastError());
			
			element.TaggedValues.Refresh();
		}
	}
}
