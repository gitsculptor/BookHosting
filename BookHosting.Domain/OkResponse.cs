using System;
namespace BookHosting.Domain
{
	public class OkResponse<T>
	{
		public OkResponse() { }
		

		public double StatusCode { get; set; }
		public T Result { get; set; }
		public string Etag { get; set; }
		public List<string> Errors { get; set; }
		public string Message { get; set; }
	}
}

