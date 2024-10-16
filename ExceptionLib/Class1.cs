namespace ExceptionLib
{

	[Serializable]
	public class EmployeeNotFoundException : Exception
	{
		public EmployeeNotFoundException() { }
		public EmployeeNotFoundException(string message) : base(message) { }
		public EmployeeNotFoundException(string message, Exception inner) : base(message, inner) { }
		protected EmployeeNotFoundException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}   
}
