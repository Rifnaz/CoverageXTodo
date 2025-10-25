namespace DbLayer.Helper
{
	public class Response
	{
		public Response(bool succeed, string message)
		{
			Succeed = succeed;
			Message = message;
		}

		public bool Succeed { get; set; }

		public string Message { get; set; }
	}
}
