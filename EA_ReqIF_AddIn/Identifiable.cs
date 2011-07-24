using System;

namespace EA_ReqIF_AddIn
{
	/// <summary>
	/// This abstract base class provides an identification concept for ReqIF elements.
	/// See OMG ReqIF specification chapter 10.8.32 for more information.
	/// </summary>
	public abstract class Identifiable : IEquatable<Identifiable>
	{
		private string identifier;
		private string longName;
		private DateTime lastChange;
		private string description;
		
		#region Properties
		/// <summary>
		/// The lifetime immutable identifier for an instance of a ReqIF element.
		/// This field is mandatory!
		/// </summary>
		public string Identifier {
			get { return identifier; }
			set { identifier = value; }
		}
		
		/// <summary>
		/// A human-readable name for the ReqIF element.
		/// This field is optional.
		/// </summary>
		public string LongName {
			get { return longName; }
			set { longName = value; }
		}
		
		/// <summary>
		/// The date and time of the last change or creation of the ReqIF element.
		/// This field is mandatory!
		/// </summary>
		public DateTime LastChange {
			get { return lastChange; }
			set { lastChange = value; }
		}
		
		/// <summary>
		/// An additional description or comment for the ReqIF element.
		/// This field is optional. IMPORTANT: Do not use this field to carry
		/// the requirements text or any other user defined content. Use
		/// AttributeValue instances instead!
		/// </summary>
		public string Description {
			get { return description; }
			set { description = value; }
		}
		#endregion
		
		#region Equals, GetHashCode and comparison operator implementation
		public override bool Equals(object obj)
		{
			if (obj is Identifiable)
				return Equals((Identifiable)obj);
			else
				return false;
		}
		
		public bool Equals(Identifiable other)
		{
			// Due to a constraint in the ReqIF specification that the value of
			// an identifier must be globally unique, this should be enough:
			return this.identifier == other.identifier;
		}
		
		public override int GetHashCode()
		{
			int hash = 7;
			if (identifier != null)
			{
				hash ^= identifier.GetHashCode();
			}
			return hash;
		}
		
		public static bool operator ==(Identifiable left, Identifiable right)
		{
			return left.Equals(right);
		}
		
		public static bool operator !=(Identifiable left, Identifiable right)
		{
			return ! left.Equals(right);
		}
		#endregion
	}
}
