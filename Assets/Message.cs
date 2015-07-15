using System;
namespace AssemblyCSharp
{
	[Serializable]
	public class Message
	{
		private String message;
		private Entity sender;

		public Message (String message, Entity sender) {

			this.message = message;
			this.sender = sender;
		}

		public String getMessage() {

			return message;
		}

		public Entity getSender() {

			return sender;
		}

		public override string ToString ()
		{
			return sender.getID() + ":" + message;
		}
	}
}
