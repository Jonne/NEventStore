namespace EventStore.Serialization
{
	using System.IO;
	using Newtonsoft.Json;

	public class JsonSerializer : ISerialize
	{
		private readonly Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer
		{
			TypeNameHandling = TypeNameHandling.All,
			DefaultValueHandling = DefaultValueHandling.Ignore,
			NullValueHandling = NullValueHandling.Ignore
		};

		public void Serialize(Stream output, object graph)
		{
			using (var streamWriter = new StreamWriter(output))
			using (var writer = new JsonTextWriter(streamWriter))
				this.serializer.Serialize(writer, graph);
		}
		public object Deserialize(Stream input)
		{
			using (var streamReader = new StreamReader(input))
			using (var reader = new JsonTextReader(streamReader))
				return this.serializer.Deserialize(reader);
		}
	}
}