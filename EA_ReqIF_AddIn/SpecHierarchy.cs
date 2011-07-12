using System;
using System.Collections;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// This class represents an ReqIF element <c>&lt;SPEC-HIERARCHY&gt;</c>...<c>&lt;/SPEC-HIERARCHY&gt;</c>.
	/// See OMG ReqIF specification chapter 10.8.36 for more information.
	/// </summary>
	/// <description>
	/// A SPEC-HIERARCHY represents a node in a hierarchically structured requirements specification.
	/// They can have a "recursive nature", i.e. a SPEC-HIERARCHY can contain 0..1 nested
	/// SPEC-HIERARCHY elements.
	/// </description>
	public class SpecHierarchy : Identifiable
	{
		private bool isEditable;
		private bool isTableInternal;
		private string specObjectReference;

		private SortedList nestedSpecHierarchies;
		
		#region Properties
		public bool IsEditable {
			get { return isEditable; }
			set { isEditable = value; }
		}
		
		public bool IsTableInternal {
			get { return isTableInternal; }
			set { isTableInternal = value; }
		}
		
		public SortedList NestedSpecHierarchies {
			get { return nestedSpecHierarchies; }
			set { nestedSpecHierarchies = value; }
		}
		
		public string SpecObjectReference {
			get { return specObjectReference; }
			set { specObjectReference = value; }
		}
		#endregion
		
		/// <summary>
		/// The default constructor.
		/// </summary>
		public SpecHierarchy()
		{
			isEditable = true;
			isTableInternal = false;
		}
	}
}
